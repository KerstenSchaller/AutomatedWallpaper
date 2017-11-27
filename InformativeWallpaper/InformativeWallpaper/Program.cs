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


       
        static void Main(string[] args)
        {
            start_Wallpaper_permutation_from_folder();
            Console.ReadKey();
        }


        public static void start_Wallpaper_permutation_from_folder()
        {
            string path = @"C:\Users\kerst\Desktop\100PHOTO";
            WallpaperController wallpapercontroller = new WallpaperController();
            wallpapercontroller.set_path_to_folder(path);
            wallpapercontroller.set_timer_interval(10);
            wallpapercontroller.start_timer();

        }
       
        

        
    }
}
