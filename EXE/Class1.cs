using System;

namespace EXE

{
    public class Class1 
    {

        [STAThread]
        static void Main()
        {

            PictureHandling.PictureHandling cal = new PictureHandling.PictureHandling();
            cal.Calculate();


            Console.ReadKey();




        }


    }
}
