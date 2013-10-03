namespace vBoxingModPack
{
	partial class mainForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.savePasswordCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.realmStatus = new System.Windows.Forms.PictureBox();
            this.skinsStatus = new System.Windows.Forms.PictureBox();
            this.sessionStatus = new System.Windows.Forms.PictureBox();
            this.loginStatus = new System.Windows.Forms.PictureBox();
            this.websiteStatus = new System.Windows.Forms.PictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.noServerCheckOnStart = new System.Windows.Forms.CheckBox();
            this.process1 = new System.Diagnostics.Process();
            this.showConsole = new System.Windows.Forms.CheckBox();
            this.updateStatus = new System.Windows.Forms.Button();
            this.welcomeMessage = new System.Windows.Forms.Label();
            this.optionenPanel = new System.Windows.Forms.Panel();
            this.ramComb = new System.Windows.Forms.CheckBox();
            this.ramSelect = new System.Windows.Forms.ComboBox();
            this.resX = new System.Windows.Forms.Label();
            this.resHeight = new System.Windows.Forms.NumericUpDown();
            this.resWidth = new System.Windows.Forms.NumericUpDown();
            this.resolutionComb = new System.Windows.Forms.CheckBox();
            this.optionEnable = new System.Windows.Forms.CheckBox();
            this.mojangStatus = new System.Windows.Forms.Label();
            this.infosMain = new System.Windows.Forms.TabControl();
            this.infosTabPage = new System.Windows.Forms.TabPage();
            this.infosBrowser = new System.Windows.Forms.WebBrowser();
            this.changelogTabPage = new System.Windows.Forms.TabPage();
            this.changelogBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.realmStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.websiteStatus)).BeginInit();
            this.optionenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resWidth)).BeginInit();
            this.infosMain.SuspendLayout();
            this.infosTabPage.SuspendLayout();
            this.changelogTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(844, 430);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(118, 23);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(677, 456);
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '*';
            this.passwordText.Size = new System.Drawing.Size(161, 20);
            this.passwordText.TabIndex = 2;
            this.passwordText.TextChanged += new System.EventHandler(this.passwordText_TextChanged);
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(677, 430);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(161, 20);
            this.usernameText.TabIndex = 1;
            this.usernameText.TextChanged += new System.EventHandler(this.usernameText_TextChanged);
            // 
            // savePasswordCheck
            // 
            this.savePasswordCheck.AutoSize = true;
            this.savePasswordCheck.Location = new System.Drawing.Point(844, 459);
            this.savePasswordCheck.Name = "savePasswordCheck";
            this.savePasswordCheck.Size = new System.Drawing.Size(118, 17);
            this.savePasswordCheck.TabIndex = 3;
            this.savePasswordCheck.TabStop = false;
            this.savePasswordCheck.Text = "speichere Passwort";
            this.savePasswordCheck.UseVisualStyleBackColor = true;
            this.savePasswordCheck.CheckedChanged += new System.EventHandler(this.savePasswordCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(596, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Benutzername";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(621, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Passwort";
            // 
            // realmStatus
            // 
            this.realmStatus.Image = global::vBoxingModPack.Properties.Resources.statusOff;
            this.realmStatus.Location = new System.Drawing.Point(892, 12);
            this.realmStatus.Name = "realmStatus";
            this.realmStatus.Size = new System.Drawing.Size(32, 32);
            this.realmStatus.TabIndex = 6;
            this.realmStatus.TabStop = false;
            // 
            // skinsStatus
            // 
            this.skinsStatus.Image = global::vBoxingModPack.Properties.Resources.statusOff;
            this.skinsStatus.Location = new System.Drawing.Point(854, 12);
            this.skinsStatus.Name = "skinsStatus";
            this.skinsStatus.Size = new System.Drawing.Size(32, 32);
            this.skinsStatus.TabIndex = 7;
            this.skinsStatus.TabStop = false;
            // 
            // sessionStatus
            // 
            this.sessionStatus.Image = global::vBoxingModPack.Properties.Resources.statusOff;
            this.sessionStatus.Location = new System.Drawing.Point(778, 12);
            this.sessionStatus.Name = "sessionStatus";
            this.sessionStatus.Size = new System.Drawing.Size(32, 32);
            this.sessionStatus.TabIndex = 8;
            this.sessionStatus.TabStop = false;
            // 
            // loginStatus
            // 
            this.loginStatus.Image = global::vBoxingModPack.Properties.Resources.statusOff;
            this.loginStatus.Location = new System.Drawing.Point(930, 12);
            this.loginStatus.Name = "loginStatus";
            this.loginStatus.Size = new System.Drawing.Size(32, 32);
            this.loginStatus.TabIndex = 9;
            this.loginStatus.TabStop = false;
            // 
            // websiteStatus
            // 
            this.websiteStatus.Image = global::vBoxingModPack.Properties.Resources.statusOff;
            this.websiteStatus.Location = new System.Drawing.Point(816, 12);
            this.websiteStatus.Name = "websiteStatus";
            this.websiteStatus.Size = new System.Drawing.Size(32, 32);
            this.websiteStatus.TabIndex = 10;
            this.websiteStatus.TabStop = false;
            // 
            // ToolTip
            // 
            this.ToolTip.IsBalloon = true;
            // 
            // noServerCheckOnStart
            // 
            this.noServerCheckOnStart.AutoSize = true;
            this.noServerCheckOnStart.Location = new System.Drawing.Point(3, 125);
            this.noServerCheckOnStart.Name = "noServerCheckOnStart";
            this.noServerCheckOnStart.Size = new System.Drawing.Size(175, 17);
            this.noServerCheckOnStart.TabIndex = 21;
            this.noServerCheckOnStart.Text = "Kein Server Check beim starten";
            this.ToolTip.SetToolTip(this.noServerCheckOnStart, "Checkt beim starten nicht ob die Minecraft Server Online sind\r\n(Das Programm star" +
        "tet schneller)");
            this.noServerCheckOnStart.UseVisualStyleBackColor = true;
            this.noServerCheckOnStart.CheckedChanged += new System.EventHandler(this.noServerCheckOnStart_CheckedChanged);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.FileName = resources.GetString("resource.FileName");
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // showConsole
            // 
            this.showConsole.AutoSize = true;
            this.showConsole.Location = new System.Drawing.Point(5, 3);
            this.showConsole.Name = "showConsole";
            this.showConsole.Size = new System.Drawing.Size(94, 17);
            this.showConsole.TabIndex = 12;
            this.showConsole.Text = "Zeige Konsole";
            this.showConsole.UseVisualStyleBackColor = true;
            this.showConsole.CheckedChanged += new System.EventHandler(this.showConsole_CheckedChanged);
            // 
            // updateStatus
            // 
            this.updateStatus.Location = new System.Drawing.Point(778, 50);
            this.updateStatus.Name = "updateStatus";
            this.updateStatus.Size = new System.Drawing.Size(184, 23);
            this.updateStatus.TabIndex = 14;
            this.updateStatus.Text = "Update Server Status";
            this.updateStatus.UseVisualStyleBackColor = true;
            this.updateStatus.Click += new System.EventHandler(this.updateStatus_Click);
            // 
            // welcomeMessage
            // 
            this.welcomeMessage.AutoSize = true;
            this.welcomeMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMessage.Location = new System.Drawing.Point(12, 12);
            this.welcomeMessage.Name = "welcomeMessage";
            this.welcomeMessage.Size = new System.Drawing.Size(606, 39);
            this.welcomeMessage.TabIndex = 15;
            this.welcomeMessage.Text = "mmmmmmmmmmmmmmmmmmm";
            this.welcomeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // optionenPanel
            // 
            this.optionenPanel.AutoScroll = true;
            this.optionenPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionenPanel.Controls.Add(this.noServerCheckOnStart);
            this.optionenPanel.Controls.Add(this.ramComb);
            this.optionenPanel.Controls.Add(this.ramSelect);
            this.optionenPanel.Controls.Add(this.resX);
            this.optionenPanel.Controls.Add(this.resHeight);
            this.optionenPanel.Controls.Add(this.resWidth);
            this.optionenPanel.Controls.Add(this.resolutionComb);
            this.optionenPanel.Controls.Add(this.showConsole);
            this.optionenPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.optionenPanel.Location = new System.Drawing.Point(12, 327);
            this.optionenPanel.Name = "optionenPanel";
            this.optionenPanel.Size = new System.Drawing.Size(200, 149);
            this.optionenPanel.TabIndex = 16;
            // 
            // ramComb
            // 
            this.ramComb.AutoSize = true;
            this.ramComb.Location = new System.Drawing.Point(4, 78);
            this.ramComb.Name = "ramComb";
            this.ramComb.Size = new System.Drawing.Size(98, 17);
            this.ramComb.TabIndex = 20;
            this.ramComb.Text = "Arbeitsspeicher";
            this.ramComb.UseVisualStyleBackColor = true;
            this.ramComb.CheckedChanged += new System.EventHandler(this.ramComb_CheckedChanged);
            // 
            // ramSelect
            // 
            this.ramSelect.Enabled = false;
            this.ramSelect.FormattingEnabled = true;
            this.ramSelect.Location = new System.Drawing.Point(21, 100);
            this.ramSelect.Name = "ramSelect";
            this.ramSelect.Size = new System.Drawing.Size(121, 21);
            this.ramSelect.TabIndex = 19;
            this.ramSelect.Text = "1024 MB";
            this.ramSelect.SelectedIndexChanged += new System.EventHandler(this.ramSelect_SelectedIndexChanged);
            this.ramSelect.SelectionChangeCommitted += new System.EventHandler(this.ramSelect_SelectionChangeCommitted);
            // 
            // resX
            // 
            this.resX.AutoSize = true;
            this.resX.Enabled = false;
            this.resX.Location = new System.Drawing.Point(72, 52);
            this.resX.Name = "resX";
            this.resX.Size = new System.Drawing.Size(12, 13);
            this.resX.TabIndex = 18;
            this.resX.Text = "x";
            // 
            // resHeight
            // 
            this.resHeight.Enabled = false;
            this.resHeight.Location = new System.Drawing.Point(87, 50);
            this.resHeight.Maximum = new decimal(new int[] {
            2160,
            0,
            0,
            0});
            this.resHeight.Name = "resHeight";
            this.resHeight.Size = new System.Drawing.Size(47, 20);
            this.resHeight.TabIndex = 15;
            this.resHeight.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.resHeight.ValueChanged += new System.EventHandler(this.resHeight_ValueChanged);
            // 
            // resWidth
            // 
            this.resWidth.Enabled = false;
            this.resWidth.Location = new System.Drawing.Point(21, 50);
            this.resWidth.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
            this.resWidth.Name = "resWidth";
            this.resWidth.Size = new System.Drawing.Size(47, 20);
            this.resWidth.TabIndex = 14;
            this.resWidth.Value = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            this.resWidth.ValueChanged += new System.EventHandler(this.resWidth_ValueChanged);
            // 
            // resolutionComb
            // 
            this.resolutionComb.AutoSize = true;
            this.resolutionComb.Location = new System.Drawing.Point(4, 27);
            this.resolutionComb.Name = "resolutionComb";
            this.resolutionComb.Size = new System.Drawing.Size(73, 17);
            this.resolutionComb.TabIndex = 13;
            this.resolutionComb.Text = "Auflösung";
            this.resolutionComb.UseVisualStyleBackColor = true;
            this.resolutionComb.CheckedChanged += new System.EventHandler(this.resolutionComb_CheckedChanged);
            // 
            // optionEnable
            // 
            this.optionEnable.AutoSize = true;
            this.optionEnable.Checked = true;
            this.optionEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optionEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionEnable.Location = new System.Drawing.Point(53, 293);
            this.optionEnable.Name = "optionEnable";
            this.optionEnable.Size = new System.Drawing.Size(115, 28);
            this.optionEnable.TabIndex = 17;
            this.optionEnable.Text = "Optionen";
            this.optionEnable.UseVisualStyleBackColor = true;
            this.optionEnable.CheckedChanged += new System.EventHandler(this.optionEnable_CheckedChanged);
            // 
            // mojangStatus
            // 
            this.mojangStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.mojangStatus.Location = new System.Drawing.Point(778, 47);
            this.mojangStatus.Name = "mojangStatus";
            this.mojangStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mojangStatus.Size = new System.Drawing.Size(184, 39);
            this.mojangStatus.TabIndex = 18;
            // 
            // infosMain
            // 
            this.infosMain.Controls.Add(this.infosTabPage);
            this.infosMain.Controls.Add(this.changelogTabPage);
            this.infosMain.ItemSize = new System.Drawing.Size(58, 18);
            this.infosMain.Location = new System.Drawing.Point(19, 63);
            this.infosMain.Name = "infosMain";
            this.infosMain.SelectedIndex = 0;
            this.infosMain.Size = new System.Drawing.Size(753, 224);
            this.infosMain.TabIndex = 19;
            // 
            // infosTabPage
            // 
            this.infosTabPage.Controls.Add(this.infosBrowser);
            this.infosTabPage.Location = new System.Drawing.Point(4, 22);
            this.infosTabPage.Name = "infosTabPage";
            this.infosTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.infosTabPage.Size = new System.Drawing.Size(745, 198);
            this.infosTabPage.TabIndex = 0;
            this.infosTabPage.Text = "Infos";
            this.infosTabPage.UseVisualStyleBackColor = true;
            // 
            // infosBrowser
            // 
            this.infosBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infosBrowser.Location = new System.Drawing.Point(3, 3);
            this.infosBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.infosBrowser.Name = "infosBrowser";
            this.infosBrowser.Size = new System.Drawing.Size(739, 192);
            this.infosBrowser.TabIndex = 0;
            // 
            // changelogTabPage
            // 
            this.changelogTabPage.Controls.Add(this.changelogBrowser);
            this.changelogTabPage.Location = new System.Drawing.Point(4, 22);
            this.changelogTabPage.Name = "changelogTabPage";
            this.changelogTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.changelogTabPage.Size = new System.Drawing.Size(745, 198);
            this.changelogTabPage.TabIndex = 1;
            this.changelogTabPage.Text = "Changelog";
            this.changelogTabPage.UseVisualStyleBackColor = true;
            // 
            // changelogBrowser
            // 
            this.changelogBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changelogBrowser.Location = new System.Drawing.Point(3, 3);
            this.changelogBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.changelogBrowser.Name = "changelogBrowser";
            this.changelogBrowser.Size = new System.Drawing.Size(739, 192);
            this.changelogBrowser.TabIndex = 0;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 488);
            this.Controls.Add(this.infosMain);
            this.Controls.Add(this.optionEnable);
            this.Controls.Add(this.optionenPanel);
            this.Controls.Add(this.welcomeMessage);
            this.Controls.Add(this.updateStatus);
            this.Controls.Add(this.websiteStatus);
            this.Controls.Add(this.loginStatus);
            this.Controls.Add(this.sessionStatus);
            this.Controls.Add(this.skinsStatus);
            this.Controls.Add(this.realmStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savePasswordCheck);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.mojangStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.Text = "vBoxing.de Mod Pack";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Shown += new System.EventHandler(this.mainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.realmStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinsStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.websiteStatus)).EndInit();
            this.optionenPanel.ResumeLayout(false);
            this.optionenPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resWidth)).EndInit();
            this.infosMain.ResumeLayout(false);
            this.infosTabPage.ResumeLayout(false);
            this.changelogTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.CheckBox savePasswordCheck;
        private System.Windows.Forms.PictureBox realmStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox websiteStatus;
        private System.Windows.Forms.PictureBox loginStatus;
        private System.Windows.Forms.PictureBox sessionStatus;
        private System.Windows.Forms.PictureBox skinsStatus;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.CheckBox showConsole;
        private System.Windows.Forms.Button updateStatus;
        private System.Windows.Forms.Label welcomeMessage;
        private System.Windows.Forms.Panel optionenPanel;
        private System.Windows.Forms.CheckBox optionEnable;
        private System.Windows.Forms.Label resX;
        private System.Windows.Forms.NumericUpDown resHeight;
        private System.Windows.Forms.NumericUpDown resWidth;
        private System.Windows.Forms.CheckBox resolutionComb;
        private System.Windows.Forms.CheckBox ramComb;
        private System.Windows.Forms.ComboBox ramSelect;
        private System.Windows.Forms.Label mojangStatus;
        private System.Windows.Forms.CheckBox noServerCheckOnStart;
        private System.Windows.Forms.TabControl infosMain;
        private System.Windows.Forms.TabPage infosTabPage;
        private System.Windows.Forms.TabPage changelogTabPage;
        private System.Windows.Forms.WebBrowser infosBrowser;
        private System.Windows.Forms.WebBrowser changelogBrowser;
	}
}

