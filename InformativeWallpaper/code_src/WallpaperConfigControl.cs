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
        public WallpaperConfigControl()
        {
            InitializeComponent();
        }


        private void radioButton_leftScreen_StaticImage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_leftScreen_StaticImage.Checked == false)
            {
                radioButton_leftScreen_ImageFromFolder.Checked = true;
            }
            else
            {
                radioButton_leftScreen_ImageFromFolder.Checked = false;
            }
        }

        private void radioButton_leftScreen_ImageFromFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_leftScreen_ImageFromFolder.Checked == false)
            {
                radioButton_leftScreen_StaticImage.Checked = true;
            }
            else
            {
                radioButton_leftScreen_StaticImage.Checked = false;
            }
        }

        private void radioButton_RightScreen_ImageFromFolder_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_RightScreen_StaticImage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_rightScreen_staticImage_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton_rightScreen_ImageFromFolder_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
