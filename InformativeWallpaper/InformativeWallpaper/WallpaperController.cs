using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.Threading;


namespace InformativeWallpaper
{
    public sealed class WallpaperController
    {

        /*Taken from stack overflow:*/
        /* https://stackoverflow.com/questions/1061678/change-desktop-wallpaper-using-code-in-net */

        /*Create timer*/
        private System.Timers.Timer timer = new System.Timers.Timer();

        /*Create a global image which can be manipulated and used by different functions*/
        System.Drawing.Bitmap image_to_be_set = new System.Drawing.Bitmap(1, 1);

        /*index for image to be used in set_image_by_folder(...)*/
        private int file_index = 0;

        /*path to a folder to be used in set_image_by_folder(...)*/
        private string path_to_folder = "";

        public void set_path_to_folder(string path)
        {
            path_to_folder = path;
        }

        public WallpaperController()
        {

            /*delete old temporary wallpaper*/
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }

            /*set timer properties*/
            timer.Interval = 5000;
            timer.Elapsed += TimerCallback;
            timer.AutoReset = true;
            timer.Start();

        }



        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched
        }



        public  void set_image_by_folder(string path_to_folder)
        {
            /*Only go further if path is not a filepath*/
            if (!File.Exists(path_to_folder))
            {

                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(path_to_folder);
                string extension;

                /*count number of files with correct extension in order to reset the counter correctly*/
               

                /*reset index if end of folder is reached*/
                if (file_index == (fileEntries.Count()-1))
                {
                    file_index = 0;
                }

                
                string file = fileEntries[file_index];
                extension = Path.GetExtension(file);
                if ((extension == ".jpg") || (extension == ".JPG"))
                {
                    Set_wallpaper_by_file(fileEntries[file_index]);
                    
                }
                file_index++;

                /* Recurse into subdirectories of this directory.*/
                //string[] subdirectoryEntries = Directory.GetDirectories(path_to_folder);
                //foreach (string subdirectory in subdirectoryEntries)
                // Do something
            }


        }




        public  void Set_wallpaper_by_file(string image_path = "")
        {
            if (image_path != "")
            {
                // set image by path
                string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
                System.IO.Stream s = new System.Net.WebClient().OpenRead(image_path);
                Console.WriteLine(image_path);
                image_to_be_set = (Bitmap)Image.FromStream(s);
               
            }
            else
            {
                Console.WriteLine("No Image specified");
                
            }
        }

        public  void Set_wallpaper_black()
        {
            // set image black
            Bitmap bitmap = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(bitmap);

            Rectangle rect = new Rectangle(0, 0, 10, 10);
            flagGraphics.FillRectangle(Brushes.Black, rect);
            
            System.Drawing.Image img = (Image)bitmap;
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");

            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
            Set_desktop_wallpaper(img, Style.Stretched );
                   
        }

        private  void Set_desktop_wallpaper()
        {
            Set_desktop_wallpaper(image_to_be_set);
            
        }

        public  void Set_desktop_wallpaper(System.Drawing.Image img, Style style = Style.Stretched)
        {

            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            try
            {
                img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
            if (img != null)
            {

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                if (style == Style.Stretched)
                {
                    key.SetValue(@"WallpaperStyle", 2.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                }

                if (style == Style.Centered)
                {
                    key.SetValue(@"WallpaperStyle", 1.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                }

                if (style == Style.Tiled)
                {
                    key.SetValue(@"WallpaperStyle", 1.ToString());
                    key.SetValue(@"TileWallpaper", 1.ToString());
                }

                SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0,
                    tempPath,
                    SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
        }

        public  void start_timer()
        {
            timer.Start();
        }

        public void set_timer_interval(int seconds)
        {
            timer.Interval = seconds*1000;
        }

        private  void TimerCallback(Object o, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("timercallback entered");
            set_image_by_folder(path_to_folder);
            Set_desktop_wallpaper();
            
        }


    }
}
