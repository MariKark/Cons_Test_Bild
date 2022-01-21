using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PictureHandling
{



    public class CropCircle
    {

             
        //variablen für Crop deklarieren
        private int cropX, cropY;//x, y, Widht, Hight
        int radius = 60;
        int radius2 = 30;

        //Crop Pen declarieren wo er das Bild nimmt
        public Pen cropPen = new Pen(Color.DarkRed);

        Pen farbePen = new Pen(Color.Red);
  


        public Bitmap Crop(Image image)
        {
           
            Bitmap bmpImage = (Bitmap)image;

            cropX = image.Width / 2;
            cropY = image.Height / 2; //später g Punkt zeichnen auf dem Bild!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
         
            Bitmap img = new Bitmap(2 * radius, 2 * radius);//bitmap creating
            Graphics g = Graphics.FromImage(img);
            g.TranslateTransform(img.Width / 2, img.Height / 2);//Center

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0 - radius, 0 - radius, 2 * radius, 2 * radius);
            Region region = new Region(path);
            g.SetClip(region, CombineMode.Replace);

            Bitmap bmpc = new Bitmap(bmpImage);//Image zu Bitmap // Pfad eventuell als ersatz
            
            //jetzt bmpc über das imgCircle Bild zeichnen                                                           x/y größer oder gleich dem radius
            g.DrawImage(bmpc, new Rectangle(-radius, -radius, 3 * radius, 3 * radius), new Rectangle(cropX - radius, cropY - radius, 3 * radius, 3 * radius), GraphicsUnit.Pixel);
            g.DrawEllipse(farbePen, new Rectangle(-radius,-radius,  (radius)*2, (radius)*2));//Zeichne einen Kreis als Umrandung
           

            //oder anders.. Image       Image 
            Bitmap bmpImageCrop = (Bitmap)img;
            // pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage; ---------------?!
           //--------------------- bmpImageCrop.Save(@"C:\Users\Study-Hent\Desktop\WetterAPI\Wetter2New.bmp");

            return bmpImageCrop;
        }

        

        public Bitmap Crop2(Image image)
        {

            Bitmap bmpImage2 = (Bitmap)image;

            cropX = image.Width / 2;
            cropY = image.Height / 2; //später g Punkt zeichnen auf dem Bild!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            Bitmap img = new Bitmap(2 * radius2, 2 * radius2);//bitmap creating
            Graphics g = Graphics.FromImage(img);
            g.TranslateTransform(img.Width / 2, img.Height / 2);//Center

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0 - radius2, 0 - radius2, 2 * radius2, 2 * radius2);
            Region region = new Region(path);
            g.SetClip(region, CombineMode.Replace);

            Bitmap bmpc = new Bitmap(bmpImage2);//Image zu Bitmap // Pfad eventuell als ersatz

            //jetzt bmpc über das imgCircle Bild zeichnen                                                           x/y größer oder gleich dem radius
            g.DrawImage(bmpc, new Rectangle(-radius2, -radius2, 3 * radius2, 3 * radius2), new Rectangle(cropX - radius2, cropY - radius2, 3 * radius2, 3 * radius2), GraphicsUnit.Pixel);
            g.DrawEllipse(farbePen, new Rectangle(-radius2, -radius2, radius2*2, radius2*2));//Zeichne einen Kreis als Umrandung


            //oder anders.. Image       Image 
            Bitmap bmpImageCrop2 = (Bitmap)img;
            // pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage; ---------------?!
            //----------------bmpImageCrop2.Save(@"C:\Users\Study-Hent\Desktop\WetterAPI\Wetter3New.bmp");

            return bmpImageCrop2;
        }




        /// <summary>
        /// 
        /// Sooo es sollte eine Bitmap, die schon zu Kreis vorbereitet wurde, nehmen und die Britness der pixel, also
        /// Avarage berechnen  --  mit diesen machen wir dann den vergleich, ob die zahlen den angegeben Wert entsprechen "0=schwarz und 1 = weiß"
        /// zb mache den wert 1 (grün) wenn der angegebene Wert größer 0,7 ist, dann ist es automatisch weiß und = kein regen
        /// 
        /// aber ich tuhe mich schwer damit es zu realisieren, Idee ist klar aber wie...
        /// Den überflüssigen Code für das Invertieren der Farbe habe ich gelöscht, das andere ging, jedoch nur mit dem Bild und die Farben waren fest..
        /// daher ist das hier die bessere Art aber ja...
        /// 
        /// Das Bild ist in den Resourcen hinterlegt. Damit man es testen kann
        /// 
        /// -- das untere habe ich rein auf schwarz weißem Bild getestet, aber ja...
        /// 
        /// 
        /// zum ende sollte es aber iwie gehen, bzw hoffe dann auf paar Tipps von Ihnen
        /// 
        /// 
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        /// 
        // -----ab hier ist dunkles Wald und Baustelle-----


        public double GetLuminosity(Color rgb)
        {
            double R = rgb.R + 0.2126;   
            double G = rgb.G + 0.7152;     
            double B = rgb.B + 0.0722;

            return (R + R + B + G + G + G) / 6;
        }



        public int CropBlackWhite(Bitmap cropImage)
        {

            Bitmap bmp = new Bitmap(cropImage);

            using (Graphics image3 = Graphics.FromImage(bmp))

            { 

                int X = (int)image3.DpiX;
                int Y = (int)image3.DpiY;
            
                image3.InterpolationMode = InterpolationMode.High; 

                image3.DrawImage(cropImage, new Rectangle(X, Y, cropImage.Width, cropImage.Height));
             }

            Color pixel = bmp.GetPixel(0, 0);

            Console.WriteLine("Britness-Crop-Image:  "+pixel.ToString());

            double zahl = pixel.GetBrightness();



            double totalLuminosity1 = 0;
            
                Bitmap bitmap1 = new Bitmap(bmp);
            
                for (int y = ((int)bitmap1.VerticalResolution); y < (((int)bitmap1.VerticalResolution) + bitmap1.Height); y++)
                
                {
                
                    for (int x = ((int)bitmap1.HorizontalResolution); x < (((int)bitmap1.HorizontalResolution) + bitmap1.Width); x++)
                    
                    {
                    
                    //    totalLuminosity1 += GetLuminosity(cropImage.GetPixel(x,y));
                    
                    }
                
                }
            
                double imageBrightness1 = totalLuminosity1 / (cropImage.Width * cropImage.Height);







            // Bitmap img = cropImage;


            int whiteColor = 0;
            int blackColor = 0;
            int grayColor = 0;
            int blackCol = 0;
            int gesamt = 0;
            // int rechProz = 0;

            for (int x = 0; x < cropImage.Width; x++)
            {
                for (int y = 0; y < cropImage.Height; y++)
                {
                    Color color = cropImage.GetPixel(x, y);

                    if (color.ToArgb() != Color.Black.ToArgb())
                    {
                        whiteColor++;
                    }
                    if (color.ToArgb() == Color.WhiteSmoke.ToArgb()) { grayColor++; }//whiteSmoge sind die berge --- muss get color methode machen für test
                    else
                        if (color.ToArgb() == Color.Black.ToArgb())
                    {
                        blackColor++;
                    }

                }
                blackCol = blackColor + grayColor;
                gesamt = blackCol + whiteColor;

                // rechProz = (blackCol / gesamt) * 100;
            }



            //(trigisimitrierung)
            //intensität voll = schwarz
            //halb - voll = grau und co
            // unter halb = weiß





            Console.WriteLine("black/grau: " + blackCol);
            Console.WriteLine("black: " + blackColor);
            Console.WriteLine("white: " + whiteColor);
            Console.WriteLine("Pixel gesamt " + gesamt);
            //Console.WriteLine("Pixel rechProz " + rechProz);


            //label1.Text = Convert.ToString(blackCol);
            //label1.Text = countColorsDark.ToString();
            //label2.Text = whiteColor.ToString();



            // int wert = 1;

            // if (blackCol >= (gesamt*0.7))         //70-100%
            // {
            //     wert = 3;
            // }
            //else if (blackCol >= (gesamt*0.5))       //50
            // {
            //     wert = 2;
            // }
            // else 
            // {
            //     wert = 1;
            // }

            Console.WriteLine("Zahlen-Wert " + zahl);//   0 => falsch aber wieso...

            double zahlWert = zahl;// eigentlich ist ja 0=schwarz und 1 = weiß....
            int wert;

            if (zahlWert >= 0.7 )
            {
                wert = 3;
            }
            else if (zahlWert >= 0.4)
            {
                wert = 2;
            }
            else { wert = 1; }




            Console.WriteLine("Zahl war am Ende rauskommt "+wert);
           
             int rdm = wert;
             return rdm;


        }


       
    
   

    }

}
