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
            Tester.testImageProcessor();
            WallpaperConfiguration config = new WallpaperConfiguration();
            Console.ReadKey();
        }

        
        

        
    }
}
