using PictureHandling;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;


namespace Cons_Test_Bild
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

            PictureHandling.PictureHandling cal = new PictureHandling.PictureHandling();
            cal.Calculate();


            Console.ReadKey();




        }
    }
}
