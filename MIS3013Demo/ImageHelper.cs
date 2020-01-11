using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Program
{
    public static class ImageHelper
    {
        public static int[][] LoadPixelValuesFromPath(string path, int height, int width)
        {
            var image = new Bitmap(path);
            var resized = Resize(image, height, width);
            return GetLuminanceValues(resized);
        }

        private static Bitmap Resize(Bitmap image, int desiredHeight, int desiredWidth)
        {
            var scale = Math.Min((float)desiredWidth / image.Width, (float)desiredHeight / image.Height);
            var newHeight = (int)(image.Height * scale);
            var newWidth = (int)(image.Width * scale);
            return new Bitmap(image, new Size(newWidth, newHeight));
        }

        /// <summary>
        /// Converts an image into a 2d array of luminance values (0-255)
        /// </summary>
        /// <param name="image">Image to process</param>
        /// <returns></returns>
        private static int[][] GetLuminanceValues(Bitmap image)
        {
            int[][] pixelValues = new int[image.Width][];
            for (var x = 0; x < image.Width; x++)
            {
                pixelValues[x] = new int[image.Height];
                for (var y = 0; y < image.Height; y++)
                {
                    var pixel = image.GetPixel(x, y);
                    pixelValues[x][y] = (int)((pixel.R * 0.2126) + (pixel.G * 0.7152) + (pixel.B * 0.0722));
                }
            }

            return pixelValues;
        }
    }
}
