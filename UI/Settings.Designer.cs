﻿namespace ProcessMash.UI
{
    sealed partial class Settings
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
            this.KeyTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitButton = new System.Windows.Forms.Button();
            this.FormTabControl = new System.Windows.Forms.TabControl();
            this.KeysTabPage = new System.Windows.Forms.TabPage();
            this.OtherTabPage = new System.Windows.Forms.TabPage();
            this.MinimizeCheckbox = new System.Windows.Forms.CheckBox();
            this.AboutTabPage = new System.Windows.Forms.TabPage();
            this.ResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxErrorProvider)).BeginInit();
            this.ModifiersGroupBox.SuspendLayout();
            this.TrayContextMenu.SuspendLayout();
            this.FormTabControl.SuspendLayout();
            this.KeysTabPage.SuspendLayout();
            this.OtherTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeyTextbox
            // 
            this.TextBoxErrorProvider.SetIconPadding(this.KeyTextbox, 5);
            this.KeyTextbox.Location = new System.Drawing.Point(112, 87);
            this.KeyTextbox.Name = "KeyTextbox";
            this.KeyTextbox.ReadOnly = true;
            this.KeyTextbox.Size = new System.Drawing.Size(121, 20);
            this.KeyTextbox.TabIndex = 4;
            this.KeyTextbox.TabStop = false;
            this.KeyTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.KeyTextbox.TextChanged += new System.EventHandler(this.KeyTextbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(112, 169);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.TabStop = false;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseMnemonic = false;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TextBoxErrorProvider
            // 
            this.TextBoxErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.TextBoxErrorProvider.ContainerControl = this;
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
            this.ModifiersGroupBox.TabIndex = 6;
            this.ModifiersGroupBox.TabStop = false;
            this.ModifiersGroupBox.Text = "Modifiers";
            // 
            // ShiftCheckBox
            // 
            this.ShiftCheckBox.AutoSize = true;
            this.ShiftCheckBox.Location = new System.Drawing.Point(158, 26);
            this.ShiftCheckBox.Name = "ShiftCheckBox";
            this.ShiftCheckBox.Size = new System.Drawing.Size(47, 17);
            this.ShiftCheckBox.TabIndex = 3;
            this.ShiftCheckBox.Tag = "4";
            this.ShiftCheckBox.Text = "Shift";
            this.ShiftCheckBox.UseVisualStyleBackColor = true;
            this.ShiftCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // WinCheckBox
            // 
            this.WinCheckBox.AutoSize = true;
            this.WinCheckBox.Location = new System.Drawing.Point(233, 26);
            this.WinCheckBox.Name = "WinCheckBox";
            this.WinCheckBox.Size = new System.Drawing.Size(45, 17);
            this.WinCheckBox.TabIndex = 2;
            this.WinCheckBox.Tag = "8";
            this.WinCheckBox.Text = "Win";
            this.WinCheckBox.UseVisualStyleBackColor = true;
            this.WinCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // ControlCheckBox
            // 
            this.ControlCheckBox.AutoSize = true;
            this.ControlCheckBox.Location = new System.Drawing.Point(89, 26);
            this.ControlCheckBox.Name = "ControlCheckBox";
            this.ControlCheckBox.Size = new System.Drawing.Size(41, 17);
            this.ControlCheckBox.TabIndex = 1;
            this.ControlCheckBox.Tag = "2";
            this.ControlCheckBox.Text = "Ctrl";
            this.ControlCheckBox.UseVisualStyleBackColor = true;
            this.ControlCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // AltCheckBox
            // 
            this.AltCheckBox.AutoSize = true;
            this.AltCheckBox.Location = new System.Drawing.Point(23, 26);
            this.AltCheckBox.Name = "AltCheckBox";
            this.AltCheckBox.Size = new System.Drawing.Size(38, 17);
            this.AltCheckBox.TabIndex = 0;
            this.AltCheckBox.Tag = "1";
            this.AltCheckBox.Text = "Alt";
            this.AltCheckBox.UseVisualStyleBackColor = true;
            this.AltCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // TrayNotification
            // 
            this.TrayNotification.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayNotification.BalloonTipText = "Click to open settings";
            this.TrayNotification.BalloonTipTitle = "Minimized to taskbar";
            this.TrayNotification.ContextMenuStrip = this.TrayContextMenu;
            this.TrayNotification.Text = "End Task-Shortcut";
            this.TrayNotification.Visible = true;
            this.TrayNotification.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayNotification_MouseClick);
            // 
            // TrayContextMenu
            // 
            this.TrayContextMenu.ImageScalingSize = new System.Drawing.Size(30, 16);
            this.TrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsContextMenuItem,
            this.toolStripSeparator1,
            this.ExitContextMenuItem});
            this.TrayContextMenu.Name = "TrayContextMenu";
            this.TrayContextMenu.ShowImageMargin = false;
            this.TrayContextMenu.Size = new System.Drawing.Size(92, 54);
            // 
            // SettingsContextMenuItem
            // 
            this.SettingsContextMenuItem.Name = "SettingsContextMenuItem";
            this.SettingsContextMenuItem.Size = new System.Drawing.Size(91, 22);
            this.SettingsContextMenuItem.Text = "Settings";
            this.SettingsContextMenuItem.Click += new System.EventHandler(this.OpenContextMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(88, 6);
            // 
            // ExitContextMenuItem
            // 
            this.ExitContextMenuItem.Name = "ExitContextMenuItem";
            this.ExitContextMenuItem.Size = new System.Drawing.Size(91, 22);
            this.ExitContextMenuItem.Text = "Exit";
            this.ExitContextMenuItem.Click += new System.EventHandler(this.ExitContextMenuItem_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(274, 169);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "Exit";
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
            this.FormTabControl.TabIndex = 7;
            // 
            // KeysTabPage
            // 
            this.KeysTabPage.Controls.Add(this.ModifiersGroupBox);
            this.KeysTabPage.Controls.Add(this.KeyTextbox);
            this.KeysTabPage.Controls.Add(this.label2);
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
            this.OtherTabPage.Controls.Add(this.MinimizeCheckbox);
            this.OtherTabPage.Location = new System.Drawing.Point(4, 22);
            this.OtherTabPage.Name = "OtherTabPage";
            this.OtherTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OtherTabPage.Size = new System.Drawing.Size(336, 127);
            this.OtherTabPage.TabIndex = 1;
            this.OtherTabPage.Text = "Other";
            this.OtherTabPage.UseVisualStyleBackColor = true;
            // 
            // MinimizeCheckbox
            // 
            this.MinimizeCheckbox.AutoSize = true;
            this.MinimizeCheckbox.Location = new System.Drawing.Point(15, 19);
            this.MinimizeCheckbox.Name = "MinimizeCheckbox";
            this.MinimizeCheckbox.Size = new System.Drawing.Size(116, 17);
            this.MinimizeCheckbox.TabIndex = 2;
            this.MinimizeCheckbox.Text = "Minimize on startup";
            this.MinimizeCheckbox.UseVisualStyleBackColor = true;
            this.MinimizeCheckbox.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // AboutTabPage
            // 
            this.AboutTabPage.Location = new System.Drawing.Point(4, 22);
            this.AboutTabPage.Name = "AboutTabPage";
            this.AboutTabPage.Size = new System.Drawing.Size(336, 127);
            this.AboutTabPage.TabIndex = 2;
            this.AboutTabPage.Text = "About";
            this.AboutTabPage.UseVisualStyleBackColor = true;
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.Enabled = false;
            this.ResetButton.Location = new System.Drawing.Point(193, 169);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 8;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Settings
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
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyDown);
            this.Resize += new System.EventHandler(this.Settings_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxErrorProvider)).EndInit();
            this.ModifiersGroupBox.ResumeLayout(false);
            this.ModifiersGroupBox.PerformLayout();
            this.TrayContextMenu.ResumeLayout(false);
            this.FormTabControl.ResumeLayout(false);
            this.KeysTabPage.ResumeLayout(false);
            this.KeysTabPage.PerformLayout();
            this.OtherTabPage.ResumeLayout(false);
            this.OtherTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox KeyTextbox;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl FormTabControl;
        private System.Windows.Forms.TabPage KeysTabPage;
        private System.Windows.Forms.TabPage OtherTabPage;
        private System.Windows.Forms.TabPage AboutTabPage;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.CheckBox MinimizeCheckbox;
    }
}

