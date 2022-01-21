using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureHandling
{
    public class FileOperations
    {
        Bitmap newBitmap;
        

        public Bitmap LoadBitmap()
        {
            bool key = false;

            do
            {
                                                     //Bild ist hier auch beigefügt worden
             FileStream oStream = new FileStream(@"C:\Users\Study-Hent\Desktop\WetterAPI\Wetter1.bmp", FileMode.Open);
             Bitmap image = new Bitmap(oStream);
             oStream.Close();

             newBitmap = new Bitmap(image);
               // newBitmap = new Bitmap();

                return newBitmap;


                 //Console.ReadKey(true);
                //key = true;
            } while (key == true);//!Console.KeyAvailable
        }

    }
}
