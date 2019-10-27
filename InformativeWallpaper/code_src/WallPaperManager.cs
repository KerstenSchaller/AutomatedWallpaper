using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace InformativeWallpaper
{
    class WallPaperManager
    {
        /*
	- function load images from folder
	*/
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
            string[] right_screen_images;
            if (config.rightScreenStatic == false)
            {
                right_screen_images = getImagesfromFolder(config.rightScreenImageSource);
            }
            else
            {
                right_screen_images = new string[] { config.rightScreenImageSource };
            }
            string[] left_screen_images;
            if (config.leftScreenStatic == false)
            {
                left_screen_images = getImagesfromFolder(config.leftScreenImageSource);
            }
            else
            {
                left_screen_images = new string[] { config.leftScreenImageSource };
            }
            


            /*If folder is same for both screens share the images between the screens*/
            if (config.rightScreenImageSource == config.leftScreenImageSource)
            {
                List<string> right_screen_images_temp = new List<string>();
                List<string> left_screen_images_temp = new List<string>();
                for (int i = 0; i < right_screen_images.Length-1; i += 2)
                {
                    left_screen_images_temp.Add(right_screen_images[i]);
                    right_screen_images_temp.Add(right_screen_images[i+1]);
                }
                left_screen_images = left_screen_images_temp.ToArray();
                right_screen_images = right_screen_images_temp.ToArray();
            }

           

            try
            {
                var leftimage = left_screen_images[loop_cntr_left];
                var rightimage = right_screen_images[loop_cntr_right];
                
                bitmaps = new Bitmap[] { new Bitmap(leftimage), new Bitmap(rightimage) };
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
            
            
            //scale images
            bitmaps[0] = ImageProcessor.ResizeImage(bitmaps[0], config.x_resolution_left_screen, config.y_resolution_left_screen);
            bitmaps[1] = ImageProcessor.ResizeImage(bitmaps[1], config.x_resolution_right_screen, config.y_resolution_right_screen);

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

        private void updateWallpaper()
        {
            Bitmap[] bitmaps = createBitmapsAccordingtoConfig();
            if (bitmaps == null) return;
            wallpaper = ImageProcessor.Combine(bitmaps, config.x_resolution_left_screen + config.x_resolution_right_screen, Math.Max(config.y_resolution_left_screen,config.y_resolution_right_screen), config.x_resolution_left_screen );
            WallpaperController wp_controller = new WallpaperController();
            wp_controller.Set_desktop_wallpaper(wallpaper);

        }

        private string[] getImagesfromFolder(string source)
        {
            string source_folder = source;
            if (Directory.Exists(source_folder))
            {
                string[] files = Directory.GetFiles(source_folder,"*JPG");
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
