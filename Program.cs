using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                (new Program()).start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Main(args);
            }
        }

        public void start()
        {
            Console.Write("Enter the desired with height > ");
            String strHeight = Console.ReadLine();
            Console.Write("Enter the desired with width > ");
            String strWidth = Console.ReadLine();
            try
            {
                Int32 intHeight = Convert.ToInt32(strHeight);
                Int32 intWidth = Convert.ToInt32(strWidth);

                String imagePath = Directory.GetCurrentDirectory();
                Console.WriteLine(imagePath);
                String thumbnailPath = Path.Combine(imagePath, "thumbs");

                if (!Directory.Exists(thumbnailPath))
                {
                    Directory.CreateDirectory(thumbnailPath);
                }

                foreach (string image in Directory.GetFiles(imagePath, "*.jpg"))
                {
                    string newFile = Path.Combine(thumbnailPath, Path.GetFileName(image));
                    ImageResize.ResizeImage(image, newFile, intWidth, intHeight);
                }

            }
            catch
            {
                throw;
            }
        }
    }
}
