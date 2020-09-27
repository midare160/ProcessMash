using System.Windows.Forms;

namespace ProcessMash.UI
{
    sealed partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.KeyTextbox = new System.Windows.Forms.TextBox();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TextBoxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ModifiersGroupBox = new System.Windows.Forms.GroupBox();
            this.ShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.WinCheckBox = new System.Windows.Forms.CheckBox();
            this.ControlCheckBox = new System.Windows.Forms.CheckBox();
            this.AltCheckBox = new System.Windows.Forms.CheckBox();
            this.TrayNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SettingsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitButton = new System.Windows.Forms.Button();
            this.FormTabControl = new System.Windows.Forms.TabControl();
            this.KeysTabPage = new System.Windows.Forms.TabPage();
            this.OtherTabPage = new System.Windows.Forms.TabPage();
            this.SecondsUntilKilledNumeric = new System.Windows.Forms.NumericUpDown();
            this.SecondsUntilKliledLabel = new System.Windows.Forms.Label();
            this.MinimizeCheckbox = new System.Windows.Forms.CheckBox();
            this.AboutTabPage = new System.Windows.Forms.TabPage();
            this.GithubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.CreatorLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.LinkToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxErrorProvider)).BeginInit();
            this.ModifiersGroupBox.SuspendLayout();
            this.TrayContextMenu.SuspendLayout();
            this.FormTabControl.SuspendLayout();
            this.KeysTabPage.SuspendLayout();
            this.OtherTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsUntilKilledNumeric)).BeginInit();
            this.AboutTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeyTextbox
            // 
            this.TextBoxErrorProvider.SetIconPadding(this.KeyTextbox, 5);
            this.KeyTextbox.Location = new System.Drawing.Point(112, 87);
            this.KeyTextbox.Name = "KeyTextbox";
            this.KeyTextbox.ReadOnly = true;
            this.KeyTextbox.Size = new System.Drawing.Size(121, 20);
            this.KeyTextbox.TabIndex = 2;
            this.KeyTextbox.TabStop = false;
            this.KeyTextbox.Text = "Press a key!";
            this.KeyTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.KeyTextbox.WordWrap = false;
            this.KeyTextbox.TextChanged += new System.EventHandler(this.KeyTextbox_TextChanged);
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Location = new System.Drawing.Point(81, 90);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(25, 13);
            this.KeyLabel.TabIndex = 1;
            this.KeyLabel.Text = "&Key";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(112, 169);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.TabStop = false;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TextBoxErrorProvider
            // 
            this.TextBoxErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.TextBoxErrorProvider.ContainerControl = this;
            this.TextBoxErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("TextBoxErrorProvider.Icon")));
            // 
            // ModifiersGroupBox
            // 
            this.ModifiersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModifiersGroupBox.Controls.Add(this.ShiftCheckBox);
            this.ModifiersGroupBox.Controls.Add(this.WinCheckBox);
            this.ModifiersGroupBox.Controls.Add(this.ControlCheckBox);
            this.ModifiersGroupBox.Controls.Add(this.AltCheckBox);
            this.ModifiersGroupBox.Location = new System.Drawing.Point(6, 6);
            this.ModifiersGroupBox.Name = "ModifiersGroupBox";
            this.ModifiersGroupBox.Size = new System.Drawing.Size(324, 61);
            this.ModifiersGroupBox.TabIndex = 0;
            this.ModifiersGroupBox.TabStop = false;
            this.ModifiersGroupBox.Text = "&Modifiers";
            // 
            // ShiftCheckBox
            // 
            this.ShiftCheckBox.AutoSize = true;
            this.ShiftCheckBox.Location = new System.Drawing.Point(158, 26);
            this.ShiftCheckBox.Name = "ShiftCheckBox";
            this.ShiftCheckBox.Size = new System.Drawing.Size(47, 17);
            this.ShiftCheckBox.TabIndex = 2;
            this.ShiftCheckBox.TabStop = false;
            this.ShiftCheckBox.Tag = "4";
            this.ShiftCheckBox.Text = "S&hift";
            this.ShiftCheckBox.UseVisualStyleBackColor = true;
            this.ShiftCheckBox.CheckedChanged += new System.EventHandler(this.SettingsForm_ValuesChanged);
            // 
            // WinCheckBox
            // 
            this.WinCheckBox.AutoSize = true;
            this.WinCheckBox.Location = new System.Drawing.Point(233, 26);
            this.WinCheckBox.Name = "WinCheckBox";
            this.WinCheckBox.Size = new System.Drawing.Size(45, 17);
            this.WinCheckBox.TabIndex = 3;
            this.WinCheckBox.TabStop = false;
            this.WinCheckBox.Tag = "8";
            this.WinCheckBox.Text = "&Win";
            this.WinCheckBox.UseVisualStyleBackColor = true;
            this.WinCheckBox.CheckedChanged += new System.EventHandler(this.SettingsForm_ValuesChanged);
            // 
            // ControlCheckBox
            // 
            this.ControlCheckBox.AutoSize = true;
            this.ControlCheckBox.Location = new System.Drawing.Point(89, 26);
            this.ControlCheckBox.Name = "ControlCheckBox";
            this.ControlCheckBox.Size = new System.Drawing.Size(41, 17);
            this.ControlCheckBox.TabIndex = 1;
            this.ControlCheckBox.TabStop = false;
            this.ControlCheckBox.Tag = "2";
            this.ControlCheckBox.Text = "&Ctrl";
            this.ControlCheckBox.UseVisualStyleBackColor = true;
            this.ControlCheckBox.CheckedChanged += new System.EventHandler(this.SettingsForm_ValuesChanged);
            // 
            // AltCheckBox
            // 
            this.AltCheckBox.AutoSize = true;
            this.AltCheckBox.Location = new System.Drawing.Point(23, 26);
            this.AltCheckBox.Name = "AltCheckBox";
            this.AltCheckBox.Size = new System.Drawing.Size(38, 17);
            this.AltCheckBox.TabIndex = 0;
            this.AltCheckBox.TabStop = false;
            this.AltCheckBox.Tag = "1";
            this.AltCheckBox.Text = "&Alt";
            this.AltCheckBox.UseVisualStyleBackColor = true;
            this.AltCheckBox.CheckedChanged += new System.EventHandler(this.SettingsForm_ValuesChanged);
            // 
            // TrayNotification
            // 
            this.TrayNotification.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayNotification.BalloonTipText = "Click to open settings";
            this.TrayNotification.BalloonTipTitle = "Minimized to taskbar";
            this.TrayNotification.ContextMenuStrip = this.TrayContextMenu;
            this.TrayNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayNotification.Icon")));
            this.TrayNotification.Text = "ProcessMash";
            this.TrayNotification.Visible = true;
            this.TrayNotification.BalloonTipClicked += new System.EventHandler(this.TrayNotification_BalloonTipClicked_SettingsContextMenuItem_Click);
            this.TrayNotification.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayNotification_MouseClick);
            // 
            // TrayContextMenu
            // 
            this.TrayContextMenu.ImageScalingSize = new System.Drawing.Size(30, 16);
            this.TrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsContextMenuItem,
            this.ExitContextMenuItem});
            this.TrayContextMenu.Name = "TrayContextMenu";
            this.TrayContextMenu.Size = new System.Drawing.Size(117, 48);
            // 
            // SettingsContextMenuItem
            // 
            this.SettingsContextMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SettingsContextMenuItem.Name = "SettingsContextMenuItem";
            this.SettingsContextMenuItem.Size = new System.Drawing.Size(116, 22);
            this.SettingsContextMenuItem.Text = "Settings";
            this.SettingsContextMenuItem.Click += new System.EventHandler(this.TrayNotification_BalloonTipClicked_SettingsContextMenuItem_Click);
            // 
            // ExitContextMenuItem
            // 
            this.ExitContextMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExitContextMenuItem.Name = "ExitContextMenuItem";
            this.ExitContextMenuItem.Size = new System.Drawing.Size(116, 22);
            this.ExitContextMenuItem.Text = "Exit";
            this.ExitContextMenuItem.Click += new System.EventHandler(this.ExitContextMenuItem_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(274, 169);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "&Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // FormTabControl
            // 
            this.FormTabControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FormTabControl.Controls.Add(this.KeysTabPage);
            this.FormTabControl.Controls.Add(this.OtherTabPage);
            this.FormTabControl.Controls.Add(this.AboutTabPage);
            this.FormTabControl.Location = new System.Drawing.Point(5, 5);
            this.FormTabControl.Name = "FormTabControl";
            this.FormTabControl.SelectedIndex = 0;
            this.FormTabControl.Size = new System.Drawing.Size(344, 153);
            this.FormTabControl.TabIndex = 0;
            this.FormTabControl.TabStop = false;
            // 
            // KeysTabPage
            // 
            this.KeysTabPage.Controls.Add(this.ModifiersGroupBox);
            this.KeysTabPage.Controls.Add(this.KeyTextbox);
            this.KeysTabPage.Controls.Add(this.KeyLabel);
            this.KeysTabPage.Location = new System.Drawing.Point(4, 22);
            this.KeysTabPage.Name = "KeysTabPage";
            this.KeysTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeysTabPage.Size = new System.Drawing.Size(336, 127);
            this.KeysTabPage.TabIndex = 0;
            this.KeysTabPage.Text = "Keys";
            this.KeysTabPage.UseVisualStyleBackColor = true;
            // 
            // OtherTabPage
            // 
            this.OtherTabPage.Controls.Add(this.SecondsUntilKilledNumeric);
            this.OtherTabPage.Controls.Add(this.SecondsUntilKliledLabel);
            this.OtherTabPage.Controls.Add(this.MinimizeCheckbox);
            this.OtherTabPage.Location = new System.Drawing.Point(4, 22);
            this.OtherTabPage.Name = "OtherTabPage";
            this.OtherTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OtherTabPage.Size = new System.Drawing.Size(336, 127);
            this.OtherTabPage.TabIndex = 1;
            this.OtherTabPage.Text = "Other";
            this.OtherTabPage.UseVisualStyleBackColor = true;
            // 
            // SecondsUntilKilledNumeric
            // 
            this.SecondsUntilKilledNumeric.Location = new System.Drawing.Point(15, 42);
            this.SecondsUntilKilledNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.SecondsUntilKilledNumeric.Name = "SecondsUntilKilledNumeric";
            this.SecondsUntilKilledNumeric.Size = new System.Drawing.Size(34, 20);
            this.SecondsUntilKilledNumeric.TabIndex = 2;
            this.SecondsUntilKilledNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SecondsUntilKilledNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SecondsUntilKilledNumeric.ValueChanged += new System.EventHandler(this.SettingsForm_ValuesChanged);
            this.SecondsUntilKilledNumeric.Enter += new System.EventHandler(this.SecondsUntilKilledNumeric_Enter);
            // 
            // SecondsUntilKliledLabel
            // 
            this.SecondsUntilKliledLabel.AutoSize = true;
            this.SecondsUntilKliledLabel.Location = new System.Drawing.Point(51, 44);
            this.SecondsUntilKliledLabel.Name = "SecondsUntilKliledLabel";
            this.SecondsUntilKliledLabel.Size = new System.Drawing.Size(180, 13);
            this.SecondsUntilKliledLabel.TabIndex = 1;
            this.SecondsUntilKliledLabel.Text = "seconds to &wait until process is killed";
            // 
            // MinimizeCheckbox
            // 
            this.MinimizeCheckbox.AutoSize = true;
            this.MinimizeCheckbox.Location = new System.Drawing.Point(15, 19);
            this.MinimizeCheckbox.Name = "MinimizeCheckbox";
            this.MinimizeCheckbox.Size = new System.Drawing.Size(116, 17);
            this.MinimizeCheckbox.TabIndex = 0;
            this.MinimizeCheckbox.Text = "&Minimize on startup";
            this.MinimizeCheckbox.UseVisualStyleBackColor = true;
            this.MinimizeCheckbox.CheckedChanged += new System.EventHandler(this.SettingsForm_ValuesChanged);
            // 
            // AboutTabPage
            // 
            this.AboutTabPage.Controls.Add(this.GithubLinkLabel);
            this.AboutTabPage.Controls.Add(this.CreatorLabel);
            this.AboutTabPage.Controls.Add(this.VersionLabel);
            this.AboutTabPage.Location = new System.Drawing.Point(4, 22);
            this.AboutTabPage.Name = "AboutTabPage";
            this.AboutTabPage.Size = new System.Drawing.Size(336, 127);
            this.AboutTabPage.TabIndex = 2;
            this.AboutTabPage.Text = "About";
            this.AboutTabPage.UseVisualStyleBackColor = true;
            // 
            // GithubLinkLabel
            // 
            this.GithubLinkLabel.AutoSize = true;
            this.GithubLinkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GithubLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.GithubLinkLabel.Location = new System.Drawing.Point(149, 80);
            this.GithubLinkLabel.Name = "GithubLinkLabel";
            this.GithubLinkLabel.Size = new System.Drawing.Size(38, 13);
            this.GithubLinkLabel.TabIndex = 2;
            this.GithubLinkLabel.TabStop = true;
            this.GithubLinkLabel.Text = "Github";
            this.GithubLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GithubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubLinkLabel_LinkClicked);
            // 
            // CreatorLabel
            // 
            this.CreatorLabel.AutoSize = true;
            this.CreatorLabel.Location = new System.Drawing.Point(120, 57);
            this.CreatorLabel.Name = "CreatorLabel";
            this.CreatorLabel.Size = new System.Drawing.Size(97, 13);
            this.CreatorLabel.TabIndex = 1;
            this.CreatorLabel.Text = "©2020 MIDARE16";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(144, 34);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(49, 13);
            this.VersionLabel.TabIndex = 0;
            this.VersionLabel.Text = "v.1.0.0.0";
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.Enabled = false;
            this.ResetButton.Location = new System.Drawing.Point(193, 169);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.TabStop = false;
            this.ResetButton.Text = "&Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 204);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.FormTabControl);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SaveButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProcessMash - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
            this.Resize += new System.EventHandler(this.SettingsForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxErrorProvider)).EndInit();
            this.ModifiersGroupBox.ResumeLayout(false);
            this.ModifiersGroupBox.PerformLayout();
            this.TrayContextMenu.ResumeLayout(false);
            this.FormTabControl.ResumeLayout(false);
            this.KeysTabPage.ResumeLayout(false);
            this.KeysTabPage.PerformLayout();
            this.OtherTabPage.ResumeLayout(false);
            this.OtherTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsUntilKilledNumeric)).EndInit();
            this.AboutTabPage.ResumeLayout(false);
            this.AboutTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox KeyTextbox;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ErrorProvider TextBoxErrorProvider;
        private System.Windows.Forms.GroupBox ModifiersGroupBox;
        private System.Windows.Forms.CheckBox ControlCheckBox;
        private System.Windows.Forms.CheckBox AltCheckBox;
        private System.Windows.Forms.CheckBox ShiftCheckBox;
        private System.Windows.Forms.CheckBox WinCheckBox;
        private System.Windows.Forms.NotifyIcon TrayNotification;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ContextMenuStrip TrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SettingsContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitContextMenuItem;
        private System.Windows.Forms.TabControl FormTabControl;
        private System.Windows.Forms.TabPage KeysTabPage;
        private System.Windows.Forms.TabPage OtherTabPage;
        private System.Windows.Forms.TabPage AboutTabPage;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.CheckBox MinimizeCheckbox;
        private System.Windows.Forms.NumericUpDown SecondsUntilKilledNumeric;
        private System.Windows.Forms.Label SecondsUntilKliledLabel;
        private LinkLabel GithubLinkLabel;
        private Label CreatorLabel;
        private Label VersionLabel;
        private ToolTip LinkToolTip;
    }
}
