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
        private TextBox textBox_leftScreen_YRes;
        private Label label8;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox_leftScreen_XRes;
        private TextBox textBox__leftScreen_path_Folder;
        private TextBox textBox__leftScreen_path_staticImage;
        private TextBox textBox_rightScreen_YRes;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox textBox_rightScreen_XRes;
        private TextBox textBox__rightScreen_path_Folder;
        private Label label1;
        private TextBox textBox__rightScreen_path_staticImage;
        private Button button_start;
        private Button button_stop;
        private GroupBox RightScreenGroupBox;

        private bool leftScreen_static;
        private int leftScreen_XRes;
        private int leftScreen_YRes;
        private string lefttScreen_staticPath;
        private string lefttScreen_FolderPath;

        private bool rightScreen_static;
        private int rightScreen_XRes;
        private int rightScreen_YRes;
        private string rightScreen_staticPath;
        private Label label10;
        private TextBox textBox_Intervall_seconds;
        private string rightScreen_FolderPath;

        private Int32 ChangeIntervallinSeconds;

        private WallPaperManager wallpapermanager;

        public WallpaperConfigControl()
        {
            InitializeComponent();
        }


        private void radioButton_leftScreen_StaticImage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_leftScreen_StaticImage.Checked == true)
            {
                this.leftScreen_static = true;
                this.textBox__leftScreen_path_Folder.Enabled = false;
                this.textBox__leftScreen_path_staticImage.Enabled = true;
            }
        }

        private void radioButton_leftScreen_ImageFromFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_leftScreen_ImageFromFolder.Checked == true)
            {
                this.leftScreen_static = false;
                this.textBox__leftScreen_path_Folder.Enabled = true;
                this.textBox__leftScreen_path_staticImage.Enabled = false;
            }
        }

        private void radioButton_RightScreen_ImageFromFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_rightScreen_staticImage.Checked == true)
            {
                this.rightScreen_static = true;
                this.textBox__rightScreen_path_Folder.Enabled = false;
                this.textBox__rightScreen_path_staticImage.Enabled = true;
            }
        }

        private void radioButton_RightScreen_StaticImage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_rightScreen_ImageFromFolder.Checked == true)
            {
                this.rightScreen_static = false;
                this.textBox__rightScreen_path_Folder.Enabled = true;
                this.textBox__rightScreen_path_staticImage.Enabled = false;
            }
        }
        
        private void InitializeComponent()
        {
            this.LeftScreenGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox_leftScreen_YRes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_leftScreen_XRes = new System.Windows.Forms.TextBox();
            this.textBox__leftScreen_path_Folder = new System.Windows.Forms.TextBox();
            this.textBox__leftScreen_path_staticImage = new System.Windows.Forms.TextBox();
            this.radioButton_leftScreen_ImageFromFolder = new System.Windows.Forms.RadioButton();
            this.radioButton_leftScreen_StaticImage = new System.Windows.Forms.RadioButton();
            this.RightScreenGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox_rightScreen_YRes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_rightScreen_XRes = new System.Windows.Forms.TextBox();
            this.radioButton_rightScreen_staticImage = new System.Windows.Forms.RadioButton();
            this.textBox__rightScreen_path_Folder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_rightScreen_ImageFromFolder = new System.Windows.Forms.RadioButton();
            this.textBox__rightScreen_path_staticImage = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Intervall_seconds = new System.Windows.Forms.TextBox();
            this.LeftScreenGroupBox.SuspendLayout();
            this.RightScreenGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftScreenGroupBox
            // 
            this.LeftScreenGroupBox.Controls.Add(this.textBox_leftScreen_YRes);
            this.LeftScreenGroupBox.Controls.Add(this.label8);
            this.LeftScreenGroupBox.Controls.Add(this.label4);
            this.LeftScreenGroupBox.Controls.Add(this.label3);
            this.LeftScreenGroupBox.Controls.Add(this.label2);
            this.LeftScreenGroupBox.Controls.Add(this.textBox_leftScreen_XRes);
            this.LeftScreenGroupBox.Controls.Add(this.textBox__leftScreen_path_Folder);
            this.LeftScreenGroupBox.Controls.Add(this.textBox__leftScreen_path_staticImage);
            this.LeftScreenGroupBox.Controls.Add(this.radioButton_leftScreen_ImageFromFolder);
            this.LeftScreenGroupBox.Controls.Add(this.radioButton_leftScreen_StaticImage);
            this.LeftScreenGroupBox.Location = new System.Drawing.Point(11, 3);
            this.LeftScreenGroupBox.Name = "LeftScreenGroupBox";
            this.LeftScreenGroupBox.Size = new System.Drawing.Size(294, 195);
            this.LeftScreenGroupBox.TabIndex = 0;
            this.LeftScreenGroupBox.TabStop = false;
            this.LeftScreenGroupBox.Text = "Left Screen";
            // 
            // textBox_leftScreen_YRes
            // 
            this.textBox_leftScreen_YRes.Location = new System.Drawing.Point(129, 158);
            this.textBox_leftScreen_YRes.Name = "textBox_leftScreen_YRes";
            this.textBox_leftScreen_YRes.Size = new System.Drawing.Size(100, 20);
            this.textBox_leftScreen_YRes.TabIndex = 10;
            this.textBox_leftScreen_YRes.TextChanged += new System.EventHandler(this.textBox_leftScreen_YRes_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Screen Resolution Y: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Path to Folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Screen Resolution X: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Path to static Image: ";
            // 
            // textBox_leftScreen_XRes
            // 
            this.textBox_leftScreen_XRes.Location = new System.Drawing.Point(129, 132);
            this.textBox_leftScreen_XRes.Name = "textBox_leftScreen_XRes";
            this.textBox_leftScreen_XRes.Size = new System.Drawing.Size(100, 20);
            this.textBox_leftScreen_XRes.TabIndex = 5;
            this.textBox_leftScreen_XRes.TextChanged += new System.EventHandler(this.textBox_leftScreen_XRes_TextChanged);
            // 
            // textBox__leftScreen_path_Folder
            // 
            this.textBox__leftScreen_path_Folder.Location = new System.Drawing.Point(129, 106);
            this.textBox__leftScreen_path_Folder.Name = "textBox__leftScreen_path_Folder";
            this.textBox__leftScreen_path_Folder.Size = new System.Drawing.Size(100, 20);
            this.textBox__leftScreen_path_Folder.TabIndex = 4;
            this.textBox__leftScreen_path_Folder.TextChanged += new System.EventHandler(this.textBox__leftScreen_path_Folder_TextChanged);
            // 
            // textBox__leftScreen_path_staticImage
            // 
            this.textBox__leftScreen_path_staticImage.Location = new System.Drawing.Point(129, 80);
            this.textBox__leftScreen_path_staticImage.Name = "textBox__leftScreen_path_staticImage";
            this.textBox__leftScreen_path_staticImage.Size = new System.Drawing.Size(100, 20);
            this.textBox__leftScreen_path_staticImage.TabIndex = 3;
            this.textBox__leftScreen_path_staticImage.TextChanged += new System.EventHandler(this.textBox__leftScreen_path_staticImage_TextChanged);
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
            this.RightScreenGroupBox.Controls.Add(this.textBox_rightScreen_YRes);
            this.RightScreenGroupBox.Controls.Add(this.label7);
            this.RightScreenGroupBox.Controls.Add(this.label6);
            this.RightScreenGroupBox.Controls.Add(this.label5);
            this.RightScreenGroupBox.Controls.Add(this.textBox_rightScreen_XRes);
            this.RightScreenGroupBox.Controls.Add(this.radioButton_rightScreen_staticImage);
            this.RightScreenGroupBox.Controls.Add(this.textBox__rightScreen_path_Folder);
            this.RightScreenGroupBox.Controls.Add(this.label1);
            this.RightScreenGroupBox.Controls.Add(this.radioButton_rightScreen_ImageFromFolder);
            this.RightScreenGroupBox.Controls.Add(this.textBox__rightScreen_path_staticImage);
            this.RightScreenGroupBox.Location = new System.Drawing.Point(311, 3);
            this.RightScreenGroupBox.Name = "RightScreenGroupBox";
            this.RightScreenGroupBox.Size = new System.Drawing.Size(294, 195);
            this.RightScreenGroupBox.TabIndex = 1;
            this.RightScreenGroupBox.TabStop = false;
            this.RightScreenGroupBox.Text = "Right Screen";
            this.RightScreenGroupBox.Enter += new System.EventHandler(this.groupBox_RightScreen_Enter);
            // 
            // textBox_rightScreen_YRes
            // 
            this.textBox_rightScreen_YRes.Location = new System.Drawing.Point(119, 158);
            this.textBox_rightScreen_YRes.Name = "textBox_rightScreen_YRes";
            this.textBox_rightScreen_YRes.Size = new System.Drawing.Size(100, 20);
            this.textBox_rightScreen_YRes.TabIndex = 12;
            this.textBox_rightScreen_YRes.TextChanged += new System.EventHandler(this.textBox_rightScreen_YRes_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Screen Resolution Y: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Screen Resolution X: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Path to Folder:";
            // 
            // textBox_rightScreen_XRes
            // 
            this.textBox_rightScreen_XRes.Location = new System.Drawing.Point(119, 132);
            this.textBox_rightScreen_XRes.Name = "textBox_rightScreen_XRes";
            this.textBox_rightScreen_XRes.Size = new System.Drawing.Size(100, 20);
            this.textBox_rightScreen_XRes.TabIndex = 8;
            this.textBox_rightScreen_XRes.TextChanged += new System.EventHandler(this.textBox_rightScreen_XRes_TextChanged);
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
            // textBox__rightScreen_path_Folder
            // 
            this.textBox__rightScreen_path_Folder.Location = new System.Drawing.Point(119, 106);
            this.textBox__rightScreen_path_Folder.Name = "textBox__rightScreen_path_Folder";
            this.textBox__rightScreen_path_Folder.Size = new System.Drawing.Size(100, 20);
            this.textBox__rightScreen_path_Folder.TabIndex = 7;
            this.textBox__rightScreen_path_Folder.TextChanged += new System.EventHandler(this.textBox__rightScreen_path_Folder_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Path to static Image: ";
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
            // textBox__rightScreen_path_staticImage
            // 
            this.textBox__rightScreen_path_staticImage.Enabled = false;
            this.textBox__rightScreen_path_staticImage.Location = new System.Drawing.Point(119, 80);
            this.textBox__rightScreen_path_staticImage.Name = "textBox__rightScreen_path_staticImage";
            this.textBox__rightScreen_path_staticImage.Size = new System.Drawing.Size(100, 20);
            this.textBox__rightScreen_path_staticImage.TabIndex = 6;
            this.textBox__rightScreen_path_staticImage.TextChanged += new System.EventHandler(this.textBox__rightScreen_path_staticImage_TextChanged);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(11, 230);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(594, 37);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(11, 273);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(594, 37);
            this.button_stop.TabIndex = 4;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Change Intervall in Seconds: ";
            // 
            // textBox_Intervall_seconds
            // 
            this.textBox_Intervall_seconds.Location = new System.Drawing.Point(167, 203);
            this.textBox_Intervall_seconds.Name = "textBox_Intervall_seconds";
            this.textBox_Intervall_seconds.Size = new System.Drawing.Size(100, 20);
            this.textBox_Intervall_seconds.TabIndex = 7;
            this.textBox_Intervall_seconds.TextChanged += new System.EventHandler(this.textBox_Intervall_seconds_TextChanged);
            // 
            // WallpaperConfigControl
            // 
            this.Controls.Add(this.textBox_Intervall_seconds);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.RightScreenGroupBox);
            this.Controls.Add(this.LeftScreenGroupBox);
            this.Name = "WallpaperConfigControl";
            this.Size = new System.Drawing.Size(616, 325);
            this.Load += new System.EventHandler(this.WallpaperConfigControl_Load);
            this.LeftScreenGroupBox.ResumeLayout(false);
            this.LeftScreenGroupBox.PerformLayout();
            this.RightScreenGroupBox.ResumeLayout(false);
            this.RightScreenGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void WallpaperConfigControl_Load(object sender, EventArgs e)
        {
            radioButton_leftScreen_ImageFromFolder.Checked = true;
            radioButton_rightScreen_ImageFromFolder.Checked = true;
            textBox_Intervall_seconds.Text = "15";
            textBox_leftScreen_XRes.Text = "1000";
            textBox_leftScreen_YRes.Text = "1000";
            textBox_rightScreen_XRes.Text = "1000";
            textBox_rightScreen_YRes.Text = "1000";
        }

        private void groupBox_RightScreen_Enter(object sender, EventArgs e)
        {

        }

        private void textBox__leftScreen_path_staticImage_TextChanged(object sender, EventArgs e)
        {
            this.lefttScreen_staticPath = textBox__leftScreen_path_staticImage.Text;
        }

        private void textBox__rightScreen_path_staticImage_TextChanged(object sender, EventArgs e)
        {
            this.rightScreen_staticPath = textBox__rightScreen_path_staticImage.Text;
        }

        private void textBox__leftScreen_path_Folder_TextChanged(object sender, EventArgs e)
        {
            this.lefttScreen_FolderPath = textBox__leftScreen_path_Folder.Text;
        }

        private void textBox__rightScreen_path_Folder_TextChanged(object sender, EventArgs e)
        {
            this.rightScreen_FolderPath = textBox__rightScreen_path_Folder.Text;
        }

        private void textBox_leftScreen_XRes_TextChanged(object sender, EventArgs e)
        {
            this.leftScreen_XRes = int.Parse(textBox_leftScreen_XRes.Text);
        }

        private void textBox_rightScreen_XRes_TextChanged(object sender, EventArgs e)
        {
            this.rightScreen_XRes = int.Parse(textBox_rightScreen_XRes.Text);
        }

        private void textBox_leftScreen_YRes_TextChanged(object sender, EventArgs e)
        {
            this.leftScreen_YRes = int.Parse(textBox_leftScreen_YRes.Text);
        }

        private void textBox_rightScreen_YRes_TextChanged(object sender, EventArgs e)
        {
            this.rightScreen_YRes = int.Parse(textBox_rightScreen_YRes.Text);
        }

        private void button_start_Click(object sender, EventArgs e)
        {

            WallPaperConfigurationValues config = new WallPaperConfigurationValues();
            config.intervall_in_seconds = this.ChangeIntervallinSeconds;
            if (leftScreen_static == false)
            {
                config.leftScreenStatic = false;
                config.leftScreenImageSource = this.lefttScreen_FolderPath;
            }
            else
            {
                config.leftScreenStatic = true;
                config.leftScreenImageSource = this.lefttScreen_staticPath;
            }
            if (rightScreen_static == false)
            {
                config.rightScreenStatic = false;
                config.rightScreenImageSource = this.rightScreen_FolderPath;
            }
            else
            {
                config.rightScreenStatic = true;
                config.rightScreenImageSource = this.rightScreen_staticPath;
            }
            config.x_resolution_left_screen = this.leftScreen_XRes;
            config.x_resolution_right_screen = this.rightScreen_XRes;
            config.y_resolution_left_screen = this.leftScreen_YRes;
            config.y_resolution_right_screen = this.rightScreen_YRes;


            
            this.wallpapermanager = new WallPaperManager(config);
            this.wallpapermanager.startTimer();
            
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            this.wallpapermanager.stopTimer();
            this.wallpapermanager = null;
        }

        private void textBox_Intervall_seconds_TextChanged(object sender, EventArgs e)
        {
            this.ChangeIntervallinSeconds = Int32.Parse(textBox_Intervall_seconds.Text);
        }


    }
}
