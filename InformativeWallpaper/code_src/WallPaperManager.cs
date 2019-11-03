using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;

using DailyDilbertViewer;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace InformativeWallpaper
{
    class WallPaperManager
    {
 
        /* function load images from folder */
        Bitmap wallpaper;
        WallPaperConfigurationValues config = new WallPaperConfigurationValues();
        WallpaperController wp_controller = new WallpaperController();
        int loop_cntr_left = 0;
        int loop_cntr_right = 0;

        System.Timers.Timer timer = new System.Timers.Timer();


        public WallPaperManager(WallPaperConfigurationValues _config)
        {
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            config = _config;
            WallpaperConfiguration.saveNewConfig(config);
            timer.Interval = config.intervall_in_seconds * 1000;
            timer.Start();
            updateWallpaper();
        }

        public WallPaperManager()
        {
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            config = WallpaperConfiguration.getWallpaperConfigurationValues();
            timer.Interval = config.intervall_in_seconds * 1000;
            updateWallpaper();
        }

        private Bitmap[] createBitmapsAccordingtoConfig()
        {
            Bitmap[] bitmaps;
            string[] right_screen_images= { "" };
            if (config.rightScreenActive == true)
            { 
                if (config.rightScreenStatic == false)
                {
                    right_screen_images = getImagesfromFolder(config.rightScreenImageSource);                
                }
                else
                {
                    right_screen_images = new string[] { config.rightScreenImageSource };
                }
            }

            string[] left_screen_images = {"" };
            if (config.leftScreenComic == false)
            { 
                if (config.leftScreenStatic == false)
                {
                    left_screen_images = getImagesfromFolder(config.leftScreenImageSource);
                }
                else
                {
                    left_screen_images = new string[] { config.leftScreenImageSource };
                }
            }
            
            try
            {
                Bitmap leftimage;
                if (config.leftScreenComic == true)
                {
                    DilbertReceiver comicReceiver = new DilbertReceiver();
                    leftimage = (Bitmap)comicReceiver.getDilbertComicImageByDate(DateTime.Now);
                }
                else
                {
                    leftimage = new Bitmap(left_screen_images[loop_cntr_left]);
                }
                Bitmap rightimage = new Bitmap(100,100);
                if (config.rightScreenActive)
                { 
                     rightimage = new Bitmap(right_screen_images[loop_cntr_right]);
                }
                bitmaps = new Bitmap[] { leftimage, rightimage };
            }
            catch (Exception e)
            {
                string message = "Something went wrong while opening the Images: " + e.ToString();
                string caption = "Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                return null;
            }

            
            if (config.leftScreenComic == false)
            {
                bitmaps[0] = ImageProcessor.ResizeImage(bitmaps[0], config.x_resolution_left_screen, config.y_resolution_left_screen);
            }
            else
            {
                bitmaps[0] = this.embeddImage(bitmaps[0]);
                
            }
            if (config.rightScreenComic == false && config.rightScreenActive)
            {
                bitmaps[1] = ImageProcessor.ResizeImage(bitmaps[1], config.x_resolution_right_screen, config.y_resolution_right_screen);
            }
            else
            {
                bitmaps[1] = this.embeddImage(bitmaps[1]);
            }


            if (loop_cntr_left == left_screen_images.Length-1)
            {
                loop_cntr_left = 0;
            }
            else
            {
                loop_cntr_left++;
            }
            if (loop_cntr_right == right_screen_images.Length - 1)
            {
                loop_cntr_right = 0;
            }
            else
            {
                loop_cntr_right++;
            }
            return bitmaps;
        }

        private Bitmap embeddImage(Bitmap bitmap)
        {




            Bitmap blank = new Bitmap(config.x_resolution_left_screen, config.y_resolution_left_screen);
            Graphics g = Graphics.FromImage(blank);
            g.Clear(Color.Black);
            
            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                int dest_x = (config.x_resolution_left_screen / 2) - (bitmap.Width / 2);
                int dest_y = (config.y_resolution_left_screen / 2) - (bitmap.Height / 2);
                var destRect = new Rectangle(dest_x, dest_y, bitmap.Width, bitmap.Height);
                g.DrawImage(bitmap, destRect, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, wrapMode);
            }

            var ret = new Bitmap(blank);
            return ret;
            

        }

        private void updateWallpaper()
        {
            Bitmap[] bitmaps = createBitmapsAccordingtoConfig();
            if (bitmaps == null) return;
            if (config.rightScreenActive == true)
            {
                wallpaper = ImageProcessor.Combine(bitmaps, config.x_resolution_left_screen + config.x_resolution_right_screen, Math.Max(config.y_resolution_left_screen, config.y_resolution_right_screen), config.x_resolution_left_screen);
            }
            else
            {
                bitmaps[0].Save("wp1.jpg");
                wallpaper = bitmaps[0];
            }
            

            WallpaperController wp_controller = new WallpaperController();
            wp_controller.Set_desktop_wallpaper(wallpaper);

        }

        private string[] getImagesfromFolder(string source)
        {
            string source_folder = source;
            if (Directory.Exists(source_folder))
            {
                //string[] files = Directory.GetFiles(source_folder,"*|*JPG|*jpg|*bmp|*jpeg|*JPEG");
                string[] files = Directory.GetFiles(source_folder, "*");
                return files;
            }
            return new string[] {""};
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            updateWallpaper();
            Console.WriteLine("timer elapsed.");
           

        }

        internal void stopTimer()
        {
            this.timer.Stop();
        }

        internal void startTimer()
        {
            this.timer.Start();
        }
    }
}
