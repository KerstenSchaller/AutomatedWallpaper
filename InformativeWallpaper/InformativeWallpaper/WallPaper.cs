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

namespace InformativeWallpaper
{
    public sealed class Wallpaper
    {

        /*Taken from stack overflow:*/
        /* https://stackoverflow.com/questions/1061678/change-desktop-wallpaper-using-code-in-net */


        Wallpaper() { }

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

        public static void Set_wallpaper_by_path(string image_path = "")
        {
            if (image_path != "")
            {
                // set image by path
                string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
                System.IO.Stream s = new System.Net.WebClient().OpenRead(image_path);
                Image img = Image.FromStream(s);
                img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
                Set_desktop_wallpaper(img,tempPath);
            }
            else
            {
                Console.WriteLine("No Image specified");
                
            }
        }

        public static void Set_wallpaper_black()
        {
            // set image black
            Bitmap bitmap = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(bitmap);

            Rectangle rect = new Rectangle(0, 0, 10, 10);
            flagGraphics.FillRectangle(Brushes.Black, rect);

            /*Set to funny stripes*/
            /*
            int red = 0;
            int white = 11;
            while (white <= 100)
            {
                flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10);
                flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                red += 20;
                white += 20;
            }
            */
            System.Drawing.Image img = (Image)bitmap;
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");

                img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
                Set_desktop_wallpaper(img, tempPath, Style.Stretched );
                   
        }



        private static void Set_desktop_wallpaper(System.Drawing.Image img, string tempPath, Style style = Style.Stretched)
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


        public static void get_wallpaper_by_stream(string webaddress)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            var wc = new WebClient();
            Uri uri = new Uri(webaddress);

            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Download home page data. 
            Console.WriteLine("Accessing {0} ...", webaddress);
            // Open a stream to point to the data stream coming from the Web resource.
            Stream myStream = myWebClient.OpenRead(webaddress);

            Console.WriteLine("\nDisplaying Data :\n");
            StreamReader sr = new StreamReader(myStream);
            Console.WriteLine(sr.ReadToEnd());


            // Close the stream. 
            myStream.Close();

            //Image image = Image.FromStream(wc.OpenRead(uri));
            //Set_desktop_wallpaper(image,tempPath);

        }
    }
}
