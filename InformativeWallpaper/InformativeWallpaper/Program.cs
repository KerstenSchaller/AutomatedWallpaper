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
using System.Drawing;
using System.Runtime.InteropServices;

namespace InformativeWallpaper
{
    class Program
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            Tester.testImageProcessor();

            /*Hide the console window*/
            var handle = GetConsoleWindow();
            // Hide
            ShowWindow(handle, SW_HIDE);

            // Show
            //ShowWindow(handle, SW_SHOW);

            // start wallpaper manager
            WallPaperManager wpm = new WallPaperManager();
            Console.ReadKey();
        }

       
    }
}
