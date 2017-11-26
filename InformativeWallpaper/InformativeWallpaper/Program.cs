using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;

namespace InformativeWallpaper
{
    class Program
    {


        //link to iss stream
        static string iss_stream = @"http://www.ustream.tv/channel/9408562";

        static void Main(string[] args)
        {

            // Create a Timer object that knows to call our TimerCallback
            // method once every x milliseconds.
            Timer t = new Timer(TimerCallback, null, 0, 5000);
            // Wait for the user to hit <Enter>

            Wallpaper.get_wallpaper_by_stream(iss_stream);


            Console.ReadKey();            
            Wallpaper.Set_wallpaper_black();

        }



        static bool toggle_bit = false;
        public static void toggle_wallpaper()
        {
            /*Toggle image from path and black background*/
            if (toggle_bit == true)
            {
                string image = @"C:\Users\kerst\Desktop\479812_495387473856785_146779520_n.jpg";
                Wallpaper.Set_wallpaper_by_path(image);
                toggle_bit = false;

            }
            else
            {
                Wallpaper.Set_wallpaper_black();
                toggle_bit = true;
            }

        }

        static int frame_nr = 0;
        

        /*Does not really work well... maximum speed is about 1 or 2 frames a second*/
        public static void gif_as_wallpaper_next_frame(string path)
        {
            string[] allfiles = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);
            /*reset gif at end*/
            if (frame_nr == (allfiles.Count()-1))
            {
                frame_nr = 0;
            }
            string path_to_frame = allfiles[frame_nr];
            Wallpaper.Set_wallpaper_by_path(path_to_frame);
            frame_nr++;
        }


        

        private static void TimerCallback(Object o)
        {
            //toggle_wallpaper();

            //does not really work, too slow
            //string path_to_gif_dir = @"C:\Users\kerst\Documents\visual studio 2015\Projects\InformativeWallpaper\InformativeWallpaper\sample_gif";
            //gif_as_wallpaper_next_frame(path_to_gif_dir);





        }
    }
}
