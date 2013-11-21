namespace AdminTools
{
    partial class Form1
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
            this.generateModList = new System.Windows.Forms.Button();
            this.generateConfigList = new System.Windows.Forms.Button();
            this.generateAssetsList = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.generateLibrariesList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generateModList
            // 
            this.generateModList.Location = new System.Drawing.Point(12, 12);
            this.generateModList.Name = "generateModList";
            this.generateModList.Size = new System.Drawing.Size(121, 23);
            this.generateModList.TabIndex = 0;
            this.generateModList.Text = "Generate Mods List";
            this.generateModList.UseVisualStyleBackColor = true;
            this.generateModList.Click += new System.EventHandler(this.generateModList_Click);
            // 
            // generateConfigList
            // 
            this.generateConfigList.Location = new System.Drawing.Point(13, 42);
            this.generateConfigList.Name = "generateConfigList";
            this.generateConfigList.Size = new System.Drawing.Size(120, 23);
            this.generateConfigList.TabIndex = 1;
            this.generateConfigList.Text = "Generate Config List";
            this.generateConfigList.UseVisualStyleBackColor = true;
            this.generateConfigList.Click += new System.EventHandler(this.generateConfigList_Click);
            // 
            // generateAssetsList
            // 
            this.generateAssetsList.Location = new System.Drawing.Point(13, 72);
            this.generateAssetsList.Name = "generateAssetsList";
            this.generateAssetsList.Size = new System.Drawing.Size(120, 23);
            this.generateAssetsList.TabIndex = 2;
            this.generateAssetsList.Text = "Generate Assets List";
            this.generateAssetsList.UseVisualStyleBackColor = true;
            this.generateAssetsList.Click += new System.EventHandler(this.generateAssetsList_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            // 
            // generateLibrariesList
            // 
            this.generateLibrariesList.Location = new System.Drawing.Point(13, 102);
            this.generateLibrariesList.Name = "generateLibrariesList";
            this.generateLibrariesList.Size = new System.Drawing.Size(120, 23);
            this.generateLibrariesList.TabIndex = 3;
            this.generateLibrariesList.Text = "Generate Libraries List";
            this.generateLibrariesList.UseVisualStyleBackColor = true;
            this.generateLibrariesList.Click += new System.EventHandler(this.generateLibrariesList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.generateLibrariesList);
            this.Controls.Add(this.generateAssetsList);
            this.Controls.Add(this.generateConfigList);
            this.Controls.Add(this.generateModList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Admin Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generateModList;
        private System.Windows.Forms.Button generateConfigList;
        private System.Windows.Forms.Button generateAssetsList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button generateLibrariesList;
    }
}

