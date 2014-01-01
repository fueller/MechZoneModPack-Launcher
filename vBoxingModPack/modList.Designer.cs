namespace MechZoneModPack
{
    partial class modList
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
            this.modListTable = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.website = new System.Windows.Forms.DataGridViewLinkColumn();
            this.autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beschreibung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.modListTable)).BeginInit();
            this.SuspendLayout();
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
            this.website,
            this.autor,
            this.beschreibung});
            this.modListTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modListTable.Location = new System.Drawing.Point(0, 0);
            this.modListTable.Name = "modListTable";
            this.modListTable.ReadOnly = true;
            this.modListTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.modListTable.ShowEditingIcon = false;
            this.modListTable.Size = new System.Drawing.Size(1157, 635);
            this.modListTable.TabIndex = 1;
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
            // autor
            // 
            this.autor.HeaderText = "Author";
            this.autor.Name = "autor";
            this.autor.ReadOnly = true;
            // 
            // beschreibung
            // 
            this.beschreibung.HeaderText = "Description";
            this.beschreibung.Name = "beschreibung";
            this.beschreibung.ReadOnly = true;
            // 
            // modList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 635);
            this.Controls.Add(this.modListTable);
            this.Name = "modList";
            this.Text = "Mod List";
            this.Load += new System.EventHandler(this.modList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modListTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView modListTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn version;
        private System.Windows.Forms.DataGridViewLinkColumn website;
        private System.Windows.Forms.DataGridViewTextBoxColumn autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn beschreibung;
    }
}