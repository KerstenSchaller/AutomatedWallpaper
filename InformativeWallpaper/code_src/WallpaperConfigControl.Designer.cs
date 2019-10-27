namespace InformativeWallpaper
{
    partial class WallpaperConfigControl
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
            this.radioButton_leftScreen_StaticImage = new System.Windows.Forms.RadioButton();
            this.radioButton_leftScreen_ImageFromFolder = new System.Windows.Forms.RadioButton();
            this.LeftScreenGroupBox = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.RightScreenGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton_rightScreen_staticImage = new System.Windows.Forms.RadioButton();
            this.radioButton_rightScreen_ImageFromFolder = new System.Windows.Forms.RadioButton();
            this.LeftScreenGroupBox.SuspendLayout();
            this.RightScreenGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton_leftScreen_StaticImage
            // 
            this.radioButton_leftScreen_StaticImage.AutoSize = true;
            this.radioButton_leftScreen_StaticImage.Location = new System.Drawing.Point(6, 19);
            this.radioButton_leftScreen_StaticImage.Name = "radioButton_leftScreen_StaticImage";
            this.radioButton_leftScreen_StaticImage.Size = new System.Drawing.Size(84, 17);
            this.radioButton_leftScreen_StaticImage.TabIndex = 2;
            this.radioButton_leftScreen_StaticImage.TabStop = true;
            this.radioButton_leftScreen_StaticImage.Text = "Static Image";
            this.radioButton_leftScreen_StaticImage.UseVisualStyleBackColor = true;
            this.radioButton_leftScreen_StaticImage.CheckedChanged += new System.EventHandler(this.radioButton_leftScreen_StaticImage_CheckedChanged);
            // 
            // radioButton_leftScreen_ImageFromFolder
            // 
            this.radioButton_leftScreen_ImageFromFolder.AutoSize = true;
            this.radioButton_leftScreen_ImageFromFolder.Location = new System.Drawing.Point(6, 42);
            this.radioButton_leftScreen_ImageFromFolder.Name = "radioButton_leftScreen_ImageFromFolder";
            this.radioButton_leftScreen_ImageFromFolder.Size = new System.Drawing.Size(112, 17);
            this.radioButton_leftScreen_ImageFromFolder.TabIndex = 3;
            this.radioButton_leftScreen_ImageFromFolder.TabStop = true;
            this.radioButton_leftScreen_ImageFromFolder.Text = "Image From Folder";
            this.radioButton_leftScreen_ImageFromFolder.UseVisualStyleBackColor = true;
            this.radioButton_leftScreen_ImageFromFolder.CheckedChanged += new System.EventHandler(this.radioButton_leftScreen_ImageFromFolder_CheckedChanged);
            // 
            // LeftScreenGroupBox
            // 
            this.LeftScreenGroupBox.Controls.Add(this.radioButton_leftScreen_StaticImage);
            this.LeftScreenGroupBox.Controls.Add(this.radioButton_leftScreen_ImageFromFolder);
            this.LeftScreenGroupBox.Location = new System.Drawing.Point(13, 12);
            this.LeftScreenGroupBox.Name = "LeftScreenGroupBox";
            this.LeftScreenGroupBox.Size = new System.Drawing.Size(228, 153);
            this.LeftScreenGroupBox.TabIndex = 6;
            this.LeftScreenGroupBox.TabStop = false;
            this.LeftScreenGroupBox.Text = "LeftScreen";
            // 
            // RightScreenGroupBox
            // 
            this.RightScreenGroupBox.Controls.Add(this.radioButton_rightScreen_staticImage);
            this.RightScreenGroupBox.Controls.Add(this.radioButton_rightScreen_ImageFromFolder);
            this.RightScreenGroupBox.Location = new System.Drawing.Point(257, 12);
            this.RightScreenGroupBox.Name = "RightScreenGroupBox";
            this.RightScreenGroupBox.Size = new System.Drawing.Size(228, 153);
            this.RightScreenGroupBox.TabIndex = 7;
            this.RightScreenGroupBox.TabStop = false;
            this.RightScreenGroupBox.Text = "RightScreen";
            // 
            // radioButton_rightScreen_staticImage
            // 
            this.radioButton_rightScreen_staticImage.AutoSize = true;
            this.radioButton_rightScreen_staticImage.Location = new System.Drawing.Point(6, 19);
            this.radioButton_rightScreen_staticImage.Name = "radioButton_rightScreen_staticImage";
            this.radioButton_rightScreen_staticImage.Size = new System.Drawing.Size(84, 17);
            this.radioButton_rightScreen_staticImage.TabIndex = 2;
            this.radioButton_rightScreen_staticImage.TabStop = true;
            this.radioButton_rightScreen_staticImage.Text = "Static Image";
            this.radioButton_rightScreen_staticImage.UseVisualStyleBackColor = true;
            this.radioButton_rightScreen_staticImage.CheckedChanged += new System.EventHandler(this.radioButton_rightScreen_staticImage_CheckedChanged_1);
            // 
            // radioButton_rightScreen_ImageFromFolder
            // 
            this.radioButton_rightScreen_ImageFromFolder.AutoSize = true;
            this.radioButton_rightScreen_ImageFromFolder.Location = new System.Drawing.Point(6, 42);
            this.radioButton_rightScreen_ImageFromFolder.Name = "radioButton_rightScreen_ImageFromFolder";
            this.radioButton_rightScreen_ImageFromFolder.Size = new System.Drawing.Size(112, 17);
            this.radioButton_rightScreen_ImageFromFolder.TabIndex = 3;
            this.radioButton_rightScreen_ImageFromFolder.TabStop = true;
            this.radioButton_rightScreen_ImageFromFolder.Text = "Image From Folder";
            this.radioButton_rightScreen_ImageFromFolder.UseVisualStyleBackColor = true;
            this.radioButton_rightScreen_ImageFromFolder.CheckedChanged += new System.EventHandler(this.radioButton_rightScreen_ImageFromFolder_CheckedChanged_1);
            // 
            // WallpaperConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RightScreenGroupBox);
            this.Controls.Add(this.LeftScreenGroupBox);
            this.Name = "WallpaperConfigControl";
            this.Size = new System.Drawing.Size(498, 330);
            this.LeftScreenGroupBox.ResumeLayout(false);
            this.LeftScreenGroupBox.PerformLayout();
            this.RightScreenGroupBox.ResumeLayout(false);
            this.RightScreenGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton_leftScreen_StaticImage;
        private System.Windows.Forms.RadioButton radioButton_leftScreen_ImageFromFolder;
        private System.Windows.Forms.GroupBox LeftScreenGroupBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox RightScreenGroupBox;
        private System.Windows.Forms.RadioButton radioButton_rightScreen_staticImage;
        private System.Windows.Forms.RadioButton radioButton_rightScreen_ImageFromFolder;
    }
}
