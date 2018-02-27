using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformativeWallpaper
{
    class Tester
    {
        public static bool testImageProcessor()
        {

            try
            {
                string current_directory = Directory.GetCurrentDirectory();
                string testfile1_path = Path.Combine(current_directory, "testimage1.bmp");
                string testfile2_path = Path.Combine(current_directory, "testimage2.bmp");
                Bitmap bitmap1 = new Bitmap(testfile1_path);
                Bitmap bitmap2 = new Bitmap(testfile2_path);
                Bitmap[] bitmaps = new Bitmap[2] { bitmap1, bitmap2 };
                Bitmap new_bitmap = ImageProcessor.Combine(bitmaps);
                new_bitmap.Save("newImage.bmp");
                return true;
            }
            catch
            {
                //test failed
                return false;
            }
            
        }

        
    }
}
