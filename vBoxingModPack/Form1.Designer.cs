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
            this.ramComb = new System.Windows.Forms.CheckBox();
            this.ramSelect = new System.Windows.Forms.ComboBox();
            this.resX = new System.Windows.Forms.Label();
            this.resHeight = new System.Windows.Forms.NumericUpDown();
            this.resWidth = new System.Windows.Forms.NumericUpDown();
            this.resolutionComb = new System.Windows.Forms.CheckBox();
            this.mojangStatus = new System.Windows.Forms.Label();
            this.infosMain = new System.Windows.Forms.TabControl();
            this.infosTabPage = new System.Windows.Forms.TabPage();
            this.infosBrowser = new System.Windows.Forms.WebBrowser();
            this.changelogTabPage = new System.Windows.Forms.TabPage();
            this.changelogBrowser = new System.Windows.Forms.WebBrowser();
            this.optionTabPage = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.themeSelecter = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openDirectory = new System.Windows.Forms.Button();
            this.modlistTabPage = new System.Windows.Forms.TabPage();
            this.modListTable = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.website = new System.Windows.Forms.DataGridViewLinkColumn();
            this.contactTabPage = new System.Windows.Forms.TabPage();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.realmStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.websiteStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resWidth)).BeginInit();
            this.infosMain.SuspendLayout();
            this.infosTabPage.SuspendLayout();
            this.changelogTabPage.SuspendLayout();
            this.optionTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.modlistTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modListTable)).BeginInit();
            this.contactTabPage.SuspendLayout();
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
            this.savePasswordCheck.BackColor = System.Drawing.Color.Transparent;
            this.savePasswordCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePasswordCheck.Location = new System.Drawing.Point(844, 459);
            this.savePasswordCheck.Name = "savePasswordCheck";
            this.savePasswordCheck.Size = new System.Drawing.Size(136, 17);
            this.savePasswordCheck.TabIndex = 3;
            this.savePasswordCheck.TabStop = false;
            this.savePasswordCheck.Text = "speichere Passwort";
            this.savePasswordCheck.UseVisualStyleBackColor = false;
            this.savePasswordCheck.CheckedChanged += new System.EventHandler(this.savePasswordCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(584, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Benutzername";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(613, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
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
            this.noServerCheckOnStart.Location = new System.Drawing.Point(12, 124);
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
            this.showConsole.Location = new System.Drawing.Point(12, 6);
            this.showConsole.Name = "showConsole";
            this.showConsole.Size = new System.Drawing.Size(94, 17);
            this.showConsole.TabIndex = 12;
            this.showConsole.Text = "Zeige Konsole";
            this.showConsole.UseVisualStyleBackColor = true;
            this.showConsole.CheckedChanged += new System.EventHandler(this.showConsole_CheckedChanged);
            // 
            // updateStatus
            // 
            this.updateStatus.BackColor = System.Drawing.SystemColors.Control;
            this.updateStatus.Location = new System.Drawing.Point(778, 50);
            this.updateStatus.Name = "updateStatus";
            this.updateStatus.Size = new System.Drawing.Size(184, 23);
            this.updateStatus.TabIndex = 14;
            this.updateStatus.Text = "Update Server Status";
            this.updateStatus.UseVisualStyleBackColor = false;
            this.updateStatus.Click += new System.EventHandler(this.updateStatus_Click);
            // 
            // welcomeMessage
            // 
            this.welcomeMessage.AutoSize = true;
            this.welcomeMessage.BackColor = System.Drawing.Color.Transparent;
            this.welcomeMessage.Font = new System.Drawing.Font("Asimov", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMessage.ForeColor = System.Drawing.Color.White;
            this.welcomeMessage.Location = new System.Drawing.Point(12, 12);
            this.welcomeMessage.Name = "welcomeMessage";
            this.welcomeMessage.Size = new System.Drawing.Size(511, 37);
            this.welcomeMessage.TabIndex = 15;
            this.welcomeMessage.Text = "mmmmmmmmmmmmmmmmmmm";
            this.welcomeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ramComb
            // 
            this.ramComb.AutoSize = true;
            this.ramComb.Location = new System.Drawing.Point(12, 78);
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
            this.ramSelect.Location = new System.Drawing.Point(22, 97);
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
            this.resX.Location = new System.Drawing.Point(65, 54);
            this.resX.Name = "resX";
            this.resX.Size = new System.Drawing.Size(12, 13);
            this.resX.TabIndex = 18;
            this.resX.Text = "x";
            // 
            // resHeight
            // 
            this.resHeight.Enabled = false;
            this.resHeight.Location = new System.Drawing.Point(83, 52);
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
            this.resWidth.Location = new System.Drawing.Point(12, 52);
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
            this.resolutionComb.Location = new System.Drawing.Point(12, 29);
            this.resolutionComb.Name = "resolutionComb";
            this.resolutionComb.Size = new System.Drawing.Size(73, 17);
            this.resolutionComb.TabIndex = 13;
            this.resolutionComb.Text = "Auflösung";
            this.resolutionComb.UseVisualStyleBackColor = true;
            this.resolutionComb.CheckedChanged += new System.EventHandler(this.resolutionComb_CheckedChanged);
            // 
            // mojangStatus
            // 
            this.mojangStatus.BackColor = System.Drawing.Color.Transparent;
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
            this.infosMain.Controls.Add(this.optionTabPage);
            this.infosMain.Controls.Add(this.modlistTabPage);
            this.infosMain.Controls.Add(this.contactTabPage);
            this.infosMain.ItemSize = new System.Drawing.Size(58, 18);
            this.infosMain.Location = new System.Drawing.Point(19, 63);
            this.infosMain.Name = "infosMain";
            this.infosMain.SelectedIndex = 0;
            this.infosMain.Size = new System.Drawing.Size(753, 361);
            this.infosMain.TabIndex = 19;
            // 
            // infosTabPage
            // 
            this.infosTabPage.Controls.Add(this.infosBrowser);
            this.infosTabPage.Location = new System.Drawing.Point(4, 22);
            this.infosTabPage.Name = "infosTabPage";
            this.infosTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.infosTabPage.Size = new System.Drawing.Size(745, 335);
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
            this.infosBrowser.Size = new System.Drawing.Size(739, 329);
            this.infosBrowser.TabIndex = 0;
            // 
            // changelogTabPage
            // 
            this.changelogTabPage.Controls.Add(this.changelogBrowser);
            this.changelogTabPage.Location = new System.Drawing.Point(4, 22);
            this.changelogTabPage.Name = "changelogTabPage";
            this.changelogTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.changelogTabPage.Size = new System.Drawing.Size(745, 335);
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
            this.changelogBrowser.Size = new System.Drawing.Size(739, 329);
            this.changelogBrowser.TabIndex = 0;
            // 
            // optionTabPage
            // 
            this.optionTabPage.Controls.Add(this.label9);
            this.optionTabPage.Controls.Add(this.themeSelecter);
            this.optionTabPage.Controls.Add(this.pictureBox1);
            this.optionTabPage.Controls.Add(this.openDirectory);
            this.optionTabPage.Controls.Add(this.noServerCheckOnStart);
            this.optionTabPage.Controls.Add(this.showConsole);
            this.optionTabPage.Controls.Add(this.ramSelect);
            this.optionTabPage.Controls.Add(this.ramComb);
            this.optionTabPage.Controls.Add(this.resolutionComb);
            this.optionTabPage.Controls.Add(this.resWidth);
            this.optionTabPage.Controls.Add(this.resHeight);
            this.optionTabPage.Controls.Add(this.resX);
            this.optionTabPage.Location = new System.Drawing.Point(4, 22);
            this.optionTabPage.Name = "optionTabPage";
            this.optionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.optionTabPage.Size = new System.Drawing.Size(745, 335);
            this.optionTabPage.TabIndex = 2;
            this.optionTabPage.Text = "Optionen";
            this.optionTabPage.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Theme";
            // 
            // themeSelecter
            // 
            this.themeSelecter.FormattingEnabled = true;
            this.themeSelecter.Items.AddRange(new object[] {
            "Dark",
            "Light",
            "Keins"});
            this.themeSelecter.Location = new System.Drawing.Point(253, 7);
            this.themeSelecter.Name = "themeSelecter";
            this.themeSelecter.Size = new System.Drawing.Size(121, 21);
            this.themeSelecter.TabIndex = 24;
            this.themeSelecter.SelectedIndexChanged += new System.EventHandler(this.themeSelecter_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(202, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 323);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // openDirectory
            // 
            this.openDirectory.Location = new System.Drawing.Point(12, 148);
            this.openDirectory.Name = "openDirectory";
            this.openDirectory.Size = new System.Drawing.Size(108, 23);
            this.openDirectory.TabIndex = 22;
            this.openDirectory.Text = "Installations Ordner";
            this.openDirectory.UseVisualStyleBackColor = true;
            this.openDirectory.Click += new System.EventHandler(this.openDirectory_Click);
            // 
            // modlistTabPage
            // 
            this.modlistTabPage.Controls.Add(this.modListTable);
            this.modlistTabPage.Location = new System.Drawing.Point(4, 22);
            this.modlistTabPage.Name = "modlistTabPage";
            this.modlistTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.modlistTabPage.Size = new System.Drawing.Size(745, 335);
            this.modlistTabPage.TabIndex = 4;
            this.modlistTabPage.Text = "Mod List";
            this.modlistTabPage.UseVisualStyleBackColor = true;
            // 
            // modListTable
            // 
            this.modListTable.AllowUserToAddRows = false;
            this.modListTable.AllowUserToDeleteRows = false;
            this.modListTable.AllowUserToResizeColumns = false;
            this.modListTable.AllowUserToResizeRows = false;
            this.modListTable.BackgroundColor = System.Drawing.Color.White;
            this.modListTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.modListTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.modListTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.version,
            this.website});
            this.modListTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modListTable.Location = new System.Drawing.Point(3, 3);
            this.modListTable.Name = "modListTable";
            this.modListTable.ReadOnly = true;
            this.modListTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.modListTable.ShowEditingIcon = false;
            this.modListTable.Size = new System.Drawing.Size(739, 329);
            this.modListTable.TabIndex = 0;
            this.modListTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modListTable_CellContentClick);
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // version
            // 
            this.version.HeaderText = "Version";
            this.version.Name = "version";
            this.version.ReadOnly = true;
            // 
            // website
            // 
            this.website.HeaderText = "Website";
            this.website.Name = "website";
            this.website.ReadOnly = true;
            // 
            // contactTabPage
            // 
            this.contactTabPage.Controls.Add(this.linkLabel3);
            this.contactTabPage.Controls.Add(this.label8);
            this.contactTabPage.Controls.Add(this.linkLabel2);
            this.contactTabPage.Controls.Add(this.label7);
            this.contactTabPage.Controls.Add(this.linkLabel1);
            this.contactTabPage.Controls.Add(this.label6);
            this.contactTabPage.Controls.Add(this.label5);
            this.contactTabPage.Controls.Add(this.label4);
            this.contactTabPage.Controls.Add(this.label3);
            this.contactTabPage.Location = new System.Drawing.Point(4, 22);
            this.contactTabPage.Name = "contactTabPage";
            this.contactTabPage.Size = new System.Drawing.Size(745, 335);
            this.contactTabPage.TabIndex = 5;
            this.contactTabPage.Text = "Kontakt / Bug Reports";
            this.contactTabPage.UseVisualStyleBackColor = true;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(143, 102);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(64, 13);
            this.linkLabel3.TabIndex = 7;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "über GitHub";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Bug-Reports: Per Email oder ";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(105, 89);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(40, 13);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "GitHub";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "GitHub SourceCode:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(35, 76);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(98, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "fueller@vboxing.de";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Kontakt:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Jede andere Benutzung ist nicht zulässig!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dieses Programm wurde für den Minecraft Server vBoxing.de Programmiert.";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::vBoxingModPack.Properties.Resources.T_nw;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(974, 488);
            this.Controls.Add(this.infosMain);
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
            this.DoubleBuffered = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.resHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resWidth)).EndInit();
            this.infosMain.ResumeLayout(false);
            this.infosTabPage.ResumeLayout(false);
            this.changelogTabPage.ResumeLayout(false);
            this.optionTabPage.ResumeLayout(false);
            this.optionTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.modlistTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modListTable)).EndInit();
            this.contactTabPage.ResumeLayout(false);
            this.contactTabPage.PerformLayout();
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
        private System.Windows.Forms.TabPage optionTabPage;
        private System.Windows.Forms.TabPage modlistTabPage;
        private System.Windows.Forms.DataGridView modListTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn version;
        private System.Windows.Forms.DataGridViewLinkColumn website;
        private System.Windows.Forms.TabPage contactTabPage;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button openDirectory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox themeSelecter;
	}
}

