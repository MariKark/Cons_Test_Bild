using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PictureHandling
{

    public class PictureHandling 
    {

       
        public int Calculate()
        {

                
           
                Bitmap newFile;
                FileOperations getFile = new FileOperations();
                CropCircle wert = new CropCircle();


                newFile = getFile.LoadBitmap();//lädt die Bitmap aus (FileOperation) LoadBitmap-Methode
                                               //modRGB.Manipulate(newFile);//Ruft Methode Manipulate von BlackWhitInvert-Klasse
            Bitmap centerKreise = newFile;                           //---modRGB---  ist das schwarz/weiß Bild

               // int wert = modRGB.Manipulate(newFile);
               // image.Save(@"C:\Users\Study-Hent\Desktop\WetterAPI\Wetter1New.bmp");







                Image cropImage = wert.Crop(newFile);//bmmImageGrop
                Image cropImage2 = wert.Crop2(cropImage);


                //2 Images übereinander positionieren, klappt mit PNG als 2tes Bild, da sonst verdeckt
                //Graphics g = Graphics.FromImage(cropImage);
                //g.DrawImage(cropImage2,-60,-60, cropImage.Size.Width, cropImage.Size.Height);
                int radius = 60;
                int radius2 = 30;

                Pen farbePen = new Pen(Color.Red);
                Graphics g = Graphics.FromImage(centerKreise);

                int pixelWX = centerKreise.Size.Width;
                int pixelHY = centerKreise.Size.Height;
                g.DrawEllipse(farbePen, new Rectangle((pixelWX - (radius * 2)) / 2, (pixelHY - (radius * 2)) / 2, (radius) * 2, (radius) * 2));//Zeichne einen Kreis als Umrandung
                g.Dispose();
                Graphics g2 = Graphics.FromImage(centerKreise);
                g2.DrawEllipse(farbePen, new Rectangle((pixelWX - (radius2 * 2)) / 2, (pixelHY - (radius2 * 2)) / 2, (radius2) * 2, (radius2) * 2));//Zeichne einen Kreis als Umrandung
                g2.Dispose();
               //--------------- centerKreise.Save(@"C:\Users\Study-Hent\Desktop\WetterAPI\Wetter2Kreise.bmp");




                int bildCrop = wert.CropBlackWhite((Bitmap)cropImage);
                int bildCrop2 = wert.CropBlackWhite((Bitmap)cropImage2);

                Console.WriteLine(bildCrop +" "+ bildCrop2);

                return bildCrop;

       

        }

     }



 }