using ProcessMash.ContextMenu;
using ProcessMash.Extensions;
using ProcessMash.Properties;
using ProcessMash.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace ProcessMash.UI
{
    public sealed partial class SettingsForm : Form
    {
        #region Static
        private const string KeyTextBoxPlaceholder = "Press a key";
        #endregion

        #region Declarations
        private readonly Hotkeys _hotkeys;
        private bool _changed;
        private bool _changeIntern;
        private bool _moveToTray;
        private bool _firstMinimized;
        private bool _isRegistered;
        #endregion

        #region Constructors
        public SettingsForm()
        {
            InitializeComponent();

            _hotkeys = new Hotkeys(this.GetHashCode());
            TrayContextMenu.Renderer = new ContextMenuRenderer();

            // TODO check if started from autostart => minimze
        }
        #endregion

        #region Events
        private void Settings_Load(object sender, EventArgs e)
        {
            // TODO extract and save in "Images" folder
            this.Icon = IconExtractor.Extract("imageres.dll", 228, true); // two spinning blue arrows
            TextBoxErrorProvider.Icon = IconExtractor.Extract("imageres.dll", 93, false); // red circle with white cross
            TrayNotification.Icon = IconExtractor.Extract("shell32.dll", 152, false); // white task list with red cross in bottom right corner

            CheckIfAlreadyRunning();

            try
            {
                _changeIntern = true;

                LoadConfig();
                RegisterHotKey();
            }
            finally
            {
                _changeIntern = false;
            }

            if (MinimizeCheckbox.Checked)
            {
                MoveToTray();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            switch (RegisterHotKey())
            {
                case HotkeyRegistered.Success:
                    SetChangeFlag(false);
                    break;
                case HotkeyRegistered.NotSpecified:
                    SetError();
                    return;
                case HotkeyRegistered.AlreadyTaken:
                    return;
                default:
                    throw new InvalidEnumArgumentException();
            }

            Settings.Default.Modifiers = GetModifierCheckBoxes().ToArray();
            Settings.Default.Key = (int)KeyTextbox.Text.ToKey();
            Settings.Default.MinimizeOnStartup = MinimizeCheckbox.Checked;
            Settings.Default.SecondsUntilKilled = SecondsUntilKilledNumeric.Value;
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            LoadConfig();
            SetChangeFlag(false);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CloseForm();
        }

        private void KeyTextbox_TextChanged(object sender, EventArgs e)
        {
            TextBoxErrorProvider.Clear();
            KeyTextbox.SelectionStart = KeyTextbox.Text.Length;

            SetChangeFlag(true);
        }

        private void SecondsUntilKilledNumeric_Enter(object sender, EventArgs e)
            => SecondsUntilKilledNumeric.Select(0, SecondsUntilKilledNumeric.Text.Length);

        private void SettingsForm_ValuesChanged(object sender, EventArgs e)
            => SetChangeFlag(true);

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ActiveControl == KeyTextbox)
            {
                if (e.Modifiers == Keys.None)
                {
                    KeyTextbox.Text = e.KeyCode.ToString();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized || !_moveToTray) return;

            _moveToTray = false;

            if (!_firstMinimized)
            {
                TrayNotification.ShowBalloonTip(3000);
                _firstMinimized = true;
            }

            this.Hide(false);
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MoveToTray();
        }

        private void TrayNotification_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show(true);
            }
        }

        private void TrayNotification_BalloonTipClicked_SettingsContextMenuItem_Click(object sender, EventArgs e)
            => this.Show(true);

        private void ExitContextMenuItem_Click(object sender, EventArgs e)
            => CloseForm();
        #endregion

        #region Private Procedures
        private void CheckIfAlreadyRunning()
        {
            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Application.ExecutablePath)).Length > 1)
            {
                MessageBox.Show(
                    "Application is already running!",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Dispose();
            }
        }

        private void LoadConfig()
        {
            MinimizeCheckbox.Checked = Settings.Default.MinimizeOnStartup;
            SecondsUntilKilledNumeric.Value = Settings.Default.SecondsUntilKilled;

            var keyValue = Settings.Default.Key;
            KeyTextbox.Text = keyValue > 0 ? ((Keys)keyValue).ToString() : KeyTextBoxPlaceholder;

            var modifiers = Settings.Default.Modifiers;
            if (modifiers == null) return;

            foreach (CheckBox checkBox in ModifiersGroupBox.Controls)
            {
                checkBox.Checked = modifiers.Any(key => key == Convert.ToInt32(checkBox.Tag));
            }
        }

        private void SetChangeFlag(bool changed)
        {
            if (_changeIntern) return;

            _changed = changed;
            SaveButton.Enabled = changed;
            ResetButton.Enabled = changed;

            var changedText = _changed ? "*" : null;
            this.Text = $"{changedText}{Application.ProductName} - Settings";
        }

        private void SetError()
        {
            FormTabControl.SelectTab(KeysTabPage);
            TextBoxErrorProvider.SetError(KeyTextbox, "Please specify a key!");
            this.ActiveControl = KeyTextbox;

            SystemSounds.Asterisk.Play();
        }

        private void MoveToTray()
        {
            _moveToTray = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private HotkeyRegistered RegisterHotKey()
        {
            if (string.Equals(KeyTextbox.Text, KeyTextBoxPlaceholder)) return HotkeyRegistered.NotSpecified;

            if (_isRegistered)
            {
                _hotkeys.Unregister(this.Handle);
                _isRegistered = false;
            }

            if (!_hotkeys.Register(this.Handle, GetModifierCheckBoxes().Sum(), (int)KeyTextbox.Text.ToKey()))
            {
                MessageBox.Show(
                    "Hotkey is already taken by another application!",
                    "Warning!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return HotkeyRegistered.AlreadyTaken;
            }

            _isRegistered = true;

            return HotkeyRegistered.Success;
        }

        private IEnumerable<int> GetModifierCheckBoxes()
        {
            foreach (CheckBox checkBox in ModifiersGroupBox.Controls)
            {
                if (checkBox.Checked)
                {
                    yield return Convert.ToInt32(checkBox.Tag);
                }
            }
        }

        private void CloseForm()
        {
            if (_changed)
            {
                var dialogResult = MessageBox.Show(
                    "Do you really want to exit? All unsaved changes will be lost.",
                    "Are you sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            _hotkeys.Unregister(this.Handle);
            this.Dispose();
        }
        #endregion

        #region Overrides
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 0x0312 && msg.WParam.ToInt32() == _hotkeys.ID)
            {
                foreach (var process in Process.GetProcessesByName(Window.GetActiveProcessFileName()))
                {
                    // TODO bring back parent process from git and only destroy that = sub processes take long time
                    process.Destroy(SecondsUntilKilledNumeric.Value);
                }
            }

            base.WndProc(ref msg);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            RegisterHotKey();
            base.OnHandleCreated(e);
        }
        #endregion
    }
}
