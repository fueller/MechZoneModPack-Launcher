namespace vBoxingModPack
{
    partial class downloadMsg
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
            this.cancel = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.downloadFiles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(303, 42);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Abbrechen";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(13, 13);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(365, 23);
            this.progress.TabIndex = 1;
            // 
            // downloadFiles
            // 
            this.downloadFiles.AutoSize = true;
            this.downloadFiles.Location = new System.Drawing.Point(13, 43);
            this.downloadFiles.Name = "downloadFiles";
            this.downloadFiles.Size = new System.Drawing.Size(0, 13);
            this.downloadFiles.TabIndex = 2;
            // 
            // downloadMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 76);
            this.Controls.Add(this.downloadFiles);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "downloadMsg";
            this.Text = "Download";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label downloadFiles;
    }
}