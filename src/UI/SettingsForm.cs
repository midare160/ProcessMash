﻿using ProcessMash.ContextMenu;
using ProcessMash.Extensions;
using ProcessMash.Properties;
using ProcessMash.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        }
        #endregion

        #region Overrides
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 0x0312 && msg.WParam.ToInt32() == _hotkeys.ID)
            {
                Window.GetActiveProcess().Destroy((int)SecondsUntilKilledNumeric.Value);
            }

            base.WndProc(ref msg);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            RegisterHotKey();
            base.OnHandleCreated(e);
        }
        #endregion

        #region Events
        #region Events-Form
        private void Settings_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName(Application.ProductName).Length > 1)
            {
                MessageBox.Show(
                    "Application is already running!",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
                return;
            }

            try
            {
                _changeIntern = true;

                LoadConfig();
                RegisterHotKey();
                LinkToolTip.SetToolTip(GithubLinkLabel, $"https://www.github.com/midare160/{Application.ProductName}");
            }
            finally
            {
                _changeIntern = false;
            }

            if (MinimizeCheckbox.Checked) MoveToTray();
        }

        private void SettingsForm_ValuesChanged(object sender, EventArgs e)
            => SetChangeFlag(true);

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ActiveControl == KeyTextbox && e.Modifiers == Keys.None)
            {
                KeyTextbox.Text = e.KeyCode.ToString();
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
            if (e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.WindowsShutDown) return;

            e.Cancel = true;
            MoveToTray();
        }
        #endregion

        #region Events-MainButtons
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
            Settings.Default.SecondsUntilKilled = (int)SecondsUntilKilledNumeric.Value;
            Settings.Default.Save(true);
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
        #endregion

        #region Events-KeysTabPage
        private void KeyTextbox_TextChanged(object sender, EventArgs e)
        {
            TextBoxErrorProvider.Clear();
            KeyTextbox.SelectionStart = KeyTextbox.Text.Length;

            SetChangeFlag(true);
        }

        private void SecondsUntilKilledNumeric_Enter(object sender, EventArgs e)
            => SecondsUntilKilledNumeric.Select(0, SecondsUntilKilledNumeric.Text.Length);
        #endregion

        #region Events-AboutTabPage
        private void GithubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Process.Start($"https://www.github.com/midare160/{Application.ProductName}");
            GithubLinkLabel.LinkVisited = true;
        }
        #endregion

        #region Events-TrayContextMenu
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
        #endregion

        #region Private Procedures
        private void LoadConfig()
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save(true);
            }

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
            Application.Exit();
        }
        #endregion
    }
}
