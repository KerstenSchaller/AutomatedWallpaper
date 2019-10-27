using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using AForge;
//using AForge.Math.Geometry;
//using AForge.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace InformativeWallpaper
{
    class ImageProcessor
    {
        

        public void combineImages() { }



        /*Scaling function from stack overflow*/
        /*https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp*/
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }




        //taken from internet
        /*http://web.archive.org/web/20130214003927/http://tech.pro/tutorial/921/combining-images-with-csharp*/
        public static System.Drawing.Bitmap Combine(Bitmap[] bitmaps)
        {
            //read all images into memory
            List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
            System.Drawing.Bitmap finalImage = null;

            try
            {
                int width = 0;
                int height = 0;

                foreach (Bitmap bitmap in bitmaps)
                {
                    
                    //update the size of the final bitmap
                    width += bitmap.Width;
                    height = bitmap.Height > height ? bitmap.Height : height;

                    images.Add(bitmap);
                }

                //create a bitmap to hold the combined image
                finalImage = new System.Drawing.Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(System.Drawing.Color.Black);

                    //go through each image and draw it on the final image
                    int offset = 0;
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        g.DrawImage(image,
                        new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
                        offset += image.Width;
                    }
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }


        public static System.Drawing.Bitmap Combine(Bitmap[] bitmaps,int x_res, int y_res,int right_image_offset)
        {
            //read all images into memory
            List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
            System.Drawing.Bitmap finalImage = null;

            try
            {


                foreach (Bitmap bitmap in bitmaps)
                {

                    images.Add(bitmap);
                }

                //create a bitmap to hold the combined image
                finalImage = new System.Drawing.Bitmap(x_res, y_res);

                //get a graphics object from the image so we can draw on it
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(System.Drawing.Color.Black);

                    
                        g.DrawImage(images[0], new System.Drawing.Rectangle(0, 0, images[0].Width, images[0].Height));
                        g.DrawImage(images[1], new System.Drawing.Rectangle(right_image_offset, 0, images[1].Width, images[1].Height));
                
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }

    }
}
