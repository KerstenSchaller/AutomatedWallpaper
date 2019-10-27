using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformativeWallpaper
{
    public partial class WallpaperConfigControl : UserControl
    {
        private GroupBox LeftScreenGroupBox;
        private RadioButton radioButton_leftScreen_ImageFromFolder;
        private RadioButton radioButton_leftScreen_StaticImage;
        private RadioButton radioButton_rightScreen_staticImage;
        private RadioButton radioButton_rightScreen_ImageFromFolder;
        private GroupBox RightScreenGroupBox;

        public WallpaperConfigControl()
        {
            InitializeComponent();
        }


        private void radioButton_leftScreen_StaticImage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_leftScreen_ImageFromFolder_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_RightScreen_ImageFromFolder_CheckedChanged(object sender, EventArgs e)
        {
            e = e;
        }

        private void radioButton_RightScreen_StaticImage_CheckedChanged(object sender, EventArgs e)
        {
            e = e;
        }

        private void radioButton_rightScreen_staticImage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_rightScreen_ImageFromFolder_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.LeftScreenGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton_leftScreen_ImageFromFolder = new System.Windows.Forms.RadioButton();
            this.radioButton_leftScreen_StaticImage = new System.Windows.Forms.RadioButton();
            this.RightScreenGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton_rightScreen_staticImage = new System.Windows.Forms.RadioButton();
            this.radioButton_rightScreen_ImageFromFolder = new System.Windows.Forms.RadioButton();
            this.LeftScreenGroupBox.SuspendLayout();
            this.RightScreenGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftScreenGroupBox
            // 
            this.LeftScreenGroupBox.Controls.Add(this.radioButton_leftScreen_ImageFromFolder);
            this.LeftScreenGroupBox.Controls.Add(this.radioButton_leftScreen_StaticImage);
            this.LeftScreenGroupBox.Location = new System.Drawing.Point(11, 3);
            this.LeftScreenGroupBox.Name = "LeftScreenGroupBox";
            this.LeftScreenGroupBox.Size = new System.Drawing.Size(294, 305);
            this.LeftScreenGroupBox.TabIndex = 0;
            this.LeftScreenGroupBox.TabStop = false;
            this.LeftScreenGroupBox.Text = "Left Screen";
            // 
            // radioButton_leftScreen_ImageFromFolder
            // 
            this.radioButton_leftScreen_ImageFromFolder.AutoSize = true;
            this.radioButton_leftScreen_ImageFromFolder.Location = new System.Drawing.Point(3, 39);
            this.radioButton_leftScreen_ImageFromFolder.Name = "radioButton_leftScreen_ImageFromFolder";
            this.radioButton_leftScreen_ImageFromFolder.Size = new System.Drawing.Size(111, 17);
            this.radioButton_leftScreen_ImageFromFolder.TabIndex = 2;
            this.radioButton_leftScreen_ImageFromFolder.TabStop = true;
            this.radioButton_leftScreen_ImageFromFolder.Text = "Images from folder";
            this.radioButton_leftScreen_ImageFromFolder.UseVisualStyleBackColor = true;
            this.radioButton_leftScreen_ImageFromFolder.CheckedChanged += new System.EventHandler(this.radioButton_leftScreen_ImageFromFolder_CheckedChanged);
            // 
            // radioButton_leftScreen_StaticImage
            // 
            this.radioButton_leftScreen_StaticImage.AutoSize = true;
            this.radioButton_leftScreen_StaticImage.Location = new System.Drawing.Point(3, 16);
            this.radioButton_leftScreen_StaticImage.Name = "radioButton_leftScreen_StaticImage";
            this.radioButton_leftScreen_StaticImage.Size = new System.Drawing.Size(84, 17);
            this.radioButton_leftScreen_StaticImage.TabIndex = 0;
            this.radioButton_leftScreen_StaticImage.TabStop = true;
            this.radioButton_leftScreen_StaticImage.Text = "Static Image";
            this.radioButton_leftScreen_StaticImage.UseVisualStyleBackColor = true;
            this.radioButton_leftScreen_StaticImage.CheckedChanged += new System.EventHandler(this.radioButton_leftScreen_StaticImage_CheckedChanged);
            // 
            // RightScreenGroupBox
            // 
            this.RightScreenGroupBox.Controls.Add(this.radioButton_rightScreen_staticImage);
            this.RightScreenGroupBox.Controls.Add(this.radioButton_rightScreen_ImageFromFolder);
            this.RightScreenGroupBox.Location = new System.Drawing.Point(332, 3);
            this.RightScreenGroupBox.Name = "RightScreenGroupBox";
            this.RightScreenGroupBox.Size = new System.Drawing.Size(294, 305);
            this.RightScreenGroupBox.TabIndex = 1;
            this.RightScreenGroupBox.TabStop = false;
            this.RightScreenGroupBox.Text = "Right Screen";
            this.RightScreenGroupBox.Enter += new System.EventHandler(this.groupBox_RightScreen_Enter);
            // 
            // radioButton_rightScreen_staticImage
            // 
            this.radioButton_rightScreen_staticImage.AutoSize = true;
            this.radioButton_rightScreen_staticImage.Location = new System.Drawing.Point(6, 16);
            this.radioButton_rightScreen_staticImage.Name = "radioButton_rightScreen_staticImage";
            this.radioButton_rightScreen_staticImage.Size = new System.Drawing.Size(84, 17);
            this.radioButton_rightScreen_staticImage.TabIndex = 3;
            this.radioButton_rightScreen_staticImage.TabStop = true;
            this.radioButton_rightScreen_staticImage.Text = "Static Image";
            this.radioButton_rightScreen_staticImage.UseVisualStyleBackColor = true;
            this.radioButton_rightScreen_staticImage.CheckedChanged += new System.EventHandler(this.radioButton_RightScreen_StaticImage_CheckedChanged);
            // 
            // radioButton_rightScreen_ImageFromFolder
            // 
            this.radioButton_rightScreen_ImageFromFolder.AutoSize = true;
            this.radioButton_rightScreen_ImageFromFolder.Location = new System.Drawing.Point(6, 39);
            this.radioButton_rightScreen_ImageFromFolder.Name = "radioButton_rightScreen_ImageFromFolder";
            this.radioButton_rightScreen_ImageFromFolder.Size = new System.Drawing.Size(111, 17);
            this.radioButton_rightScreen_ImageFromFolder.TabIndex = 4;
            this.radioButton_rightScreen_ImageFromFolder.TabStop = true;
            this.radioButton_rightScreen_ImageFromFolder.Text = "Images from folder";
            this.radioButton_rightScreen_ImageFromFolder.UseVisualStyleBackColor = true;
            this.radioButton_rightScreen_ImageFromFolder.CheckedChanged += new System.EventHandler(this.radioButton_RightScreen_ImageFromFolder_CheckedChanged);
            // 
            // WallpaperConfigControl
            // 
            this.Controls.Add(this.RightScreenGroupBox);
            this.Controls.Add(this.LeftScreenGroupBox);
            this.Name = "WallpaperConfigControl";
            this.Size = new System.Drawing.Size(647, 431);
            this.Load += new System.EventHandler(this.WallpaperConfigControl_Load);
            this.LeftScreenGroupBox.ResumeLayout(false);
            this.LeftScreenGroupBox.PerformLayout();
            this.RightScreenGroupBox.ResumeLayout(false);
            this.RightScreenGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        private void WallpaperConfigControl_Load(object sender, EventArgs e)
        {

        }

        private void groupBox_RightScreen_Enter(object sender, EventArgs e)
        {

        }
    }
}
