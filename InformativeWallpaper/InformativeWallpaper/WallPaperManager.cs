using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

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


        Timer timer = new Timer();
        public WallPaperManager()
        {
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            //timer.Start();
            config = WallpaperConfiguration.getWallpaperConfigurationValues();

            updateWallpaper();
        }

        private void updateWallpaper()
        {
            Bitmap[] bitmaps;

            string[] images = getImagesfromFolder(config.ImageSourceFolder);
            string[] static_images = getImagesfromFolder(config.staticImageSourceFolder);

            if (config.right_image_static )
            {
                bitmaps = new Bitmap[] { new Bitmap(images[0]), new Bitmap(static_images[0]) };
            }
            else if (config.left_image_static )
            {
                    bitmaps = new Bitmap[] { new Bitmap(static_images[1]), new Bitmap(images[1]) };
                
            }
            else
            {
                bitmaps = new Bitmap[] { new Bitmap(images[0]), new Bitmap(images[1]) };
            }

            
            bitmaps[0]  = ImageProcessor.ResizeImage(bitmaps[0], config.x_resolution/2, config.y_resolution);
            bitmaps[1] = ImageProcessor.ResizeImage(bitmaps[1], config.x_resolution / 2, config.y_resolution);

            wallpaper = ImageProcessor.Combine(bitmaps, config.x_resolution, config.y_resolution,config.x_resolution/2);
            WallpaperController wp_controller = new WallpaperController();
            wp_controller.Set_desktop_wallpaper(wallpaper);

        }

        private string[] getImagesfromFolder(string source)
        {
            string source_folder = source;
            if (Directory.Exists(source_folder))
            {
                string[] files = Directory.GetFiles(source_folder,"*jpg");
                return files;
            }
            return new string[] {""};
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            updateWallpaper();

        }




    }
}
