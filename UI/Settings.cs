using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using ProcessMash.Extensions;
using ProcessMash.Tools;

namespace ProcessMash.UI
{
    public sealed partial class Settings : Form
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
        public Settings()
        {
            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Application.ExecutablePath)).Length > 1)
            {
                MessageBox.Show(
                    "Application is already running!",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // 1056 = "An instance of the service is already running." src: https://bit.ly/2FDDWds
                Environment.Exit(1056);
            }

            InitializeComponent();
            _hotkeys = new Hotkeys(this.GetHashCode(), this.Handle);

            // TODO check if started from autostart => minimze
        }
        #endregion

        #region Events
        private void Settings_Load(object sender, EventArgs e)
        {
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

            this.Icon = IconExtractor.Extract("imageres.dll", 228, true); // two spinning blue arrows
            TextBoxErrorProvider.Icon = IconExtractor.Extract("imageres.dll", 93, false); // red circle with white cross
            TrayNotification.Icon = IconExtractor.Extract("shell32.dll", 152, false); // white task list with red cross in bottom right corner
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            switch (RegisterHotKey())
            {
                case false:
                    SetError();
                    return;
                case null:
                    return;
            }

            Configurations.Modifiers = GetModifierCheckBoxes();
            Configurations.Key = (int)KeyTextbox.Text.ToKey();
            Configurations.MinimizeOnStartup = MinimizeCheckbox.Checked;
            Configurations.Save();
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

        private void CheckBoxes_CheckedChanged(object sender, EventArgs e) 
            => SetChangeFlag(true);

        private void KeyTextbox_TextChanged(object sender, EventArgs e)
        {
            TextBoxErrorProvider.Clear();
            KeyTextbox.SelectionStart = KeyTextbox.Text.Length;

            SetChangeFlag(true);
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ActiveControl == KeyTextbox)
            {
                if (e.Modifiers == Keys.None)
                {
                    KeyTextbox.Text = e.KeyCode.ToString();
                }

                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Settings_Resize(object sender, EventArgs e)
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

        private void TrayNotification_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show(true);
            }
        }

        private void OpenContextMenuItem_Click(object sender, EventArgs e)
            => this.Show(true);

        private void ExitContextMenuItem_Click(object sender, EventArgs e)
            => CloseForm();

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MoveToTray();
        }
        #endregion

        #region Private Procedures
        private void LoadConfig()
        {
            try
            {
                var keyValue = Configurations.Key;
                KeyTextbox.Text = keyValue.HasValue ? ((Keys) keyValue).ToString() : KeyTextBoxPlaceholder;

                foreach (CheckBox checkBox in ModifiersGroupBox.Controls)
                {
                    checkBox.Checked = Configurations.Modifiers.Any(key => key == Convert.ToInt32(checkBox.Tag));
                }

                MinimizeCheckbox.Checked = Configurations.MinimizeOnStartup;
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Stop fucking around with config files if you dont know what youre doing!",
                    "For fucks sake!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Configurations.Reset();
            }
        }

        private void SetChangeFlag(bool changed)
        {
            if (_changeIntern) return;

            _changed = changed;
            SaveButton.Enabled = changed;
            ResetButton.Enabled = changed;
        }

        private void MoveToTray()
        {
            _moveToTray = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void SetError()
        {
            TextBoxErrorProvider.SetError(KeyTextbox, "Please specify a key!");
            FormTabControl.SelectTab(KeysTabPage);
            this.ActiveControl = KeyTextbox;

            SystemSounds.Asterisk.Play();
        }

        private bool? RegisterHotKey()
        {
            if (string.Equals(KeyTextbox.Text, KeyTextBoxPlaceholder)) return false;

            if (_isRegistered)
            {
                _hotkeys.Unregister();
                _isRegistered = false;
            }

            if (!_hotkeys.Register(GetModifierCheckBoxes().Sum(), (int)KeyTextbox.Text.ToKey()))
            {
                MessageBox.Show(
                    "Hotkey is already taken by another application!",
                    "Warning!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return null;
            }

            SetChangeFlag(false);
            _isRegistered = true;

            return true;
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
                    "Do you really want to exit? You will loose all unsaved changes.",
                    "Are you sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            _hotkeys.Unregister();
            Environment.Exit(0);
        }
        #endregion

        #region Overrides
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 0x0312 && msg.WParam.ToInt32() == _hotkeys.ID)
            {
                foreach (var process in Process.GetProcessesByName(Window.GetActiveProcessFileName()))
                {
                    process.Destroy();
                }
            }

            base.WndProc(ref msg);
        }
        #endregion
    }
}
