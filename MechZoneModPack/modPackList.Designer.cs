namespace MechZoneModPack
{
    partial class modPackList
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.modInfoImage = new System.Windows.Forms.PictureBox();
            this.modInfoName = new System.Windows.Forms.Label();
            this.modInfoDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.modInfoImage)).BeginInit();
            this.SuspendLayout();
            // 
            // modInfoImage
            // 
            this.modInfoImage.Location = new System.Drawing.Point(3, 3);
            this.modInfoImage.Name = "modInfoImage";
            this.modInfoImage.Size = new System.Drawing.Size(101, 101);
            this.modInfoImage.TabIndex = 0;
            this.modInfoImage.TabStop = false;
            // 
            // modInfoName
            // 
            this.modInfoName.AutoSize = true;
            this.modInfoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modInfoName.Location = new System.Drawing.Point(110, 3);
            this.modInfoName.Name = "modInfoName";
            this.modInfoName.Size = new System.Drawing.Size(41, 13);
            this.modInfoName.TabIndex = 1;
            this.modInfoName.Text = "label1";
            // 
            // modInfoDescription
            // 
            this.modInfoDescription.AutoSize = true;
            this.modInfoDescription.Location = new System.Drawing.Point(113, 20);
            this.modInfoDescription.Name = "modInfoDescription";
            this.modInfoDescription.Size = new System.Drawing.Size(35, 13);
            this.modInfoDescription.TabIndex = 2;
            this.modInfoDescription.Text = "label1";
            // 
            // modPackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.modInfoDescription);
            this.Controls.Add(this.modInfoName);
            this.Controls.Add(this.modInfoImage);
            this.Name = "modPackList";
            this.Size = new System.Drawing.Size(332, 107);
            this.Load += new System.EventHandler(this.modPackList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modInfoImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox modInfoImage;
        private System.Windows.Forms.Label modInfoName;
        private System.Windows.Forms.Label modInfoDescription;
    }
}
