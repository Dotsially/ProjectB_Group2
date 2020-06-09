using System;
using System.Drawing;

namespace ProjectB_Group2
{
    class Menu
    {
        static int i;
        static string a;
        static bool numcheck;
        static bool mmenu = true;
        static bool fmenu = false;
        static bool rv = false;
        static bool rs = false;
        public static void MainMenu()
        {
            while (mmenu)
            {

                Colorful.Console.WriteLine("[1]Menu [2]Reservation [3]Reviews [4]Quit", Color.Yellow);
                Colorful.Console.WriteLine("Welcome to our Restaurant please choose a number to proceed: ", Color.Yellow);
                Menu.Numbercheck(ref mmenu);

                while (!Menu.numcheck)
                {
                    Colorful.Console.WriteLine("That's an invalid number", Color.Red);
                    Menu.Numbercheck(ref mmenu);
                }

                if (Menu.i == 1)
                {
                    mmenu = false;
                    fmenu = true;
                    Program.Dishes.MenuFunction();
                }

                else if (Menu.i == 2)
                {
                    mmenu = false;
                    rs = true;
                    ReservationsClass.Resevations();
                }

                else if (Menu.i == 3)
                {
                    mmenu = false;
                    Review2.Review.ReviewsFunction();
                    rv = true;
                }

                else if (Menu.i == 4)
                {
                    mmenu = false;
                    MainFile.run = false;
                }
                else
                {
                    Colorful.Console.WriteLine("That's an invalid number", Color.Red);
                }

            }

            while (fmenu == true)
            {
                Colorful.Console.WriteLine("[0] To Return", Color.Yellow);
                Menu.Numbercheck(ref fmenu);
            }

            while (rv == true)
            {
                Colorful.Console.WriteLine("[0] To Return", Color.Yellow);
                Menu.Numbercheck(ref rv);
            }

            while (rs == true)
            {
                Colorful.Console.WriteLine("[0] To Return", Color.Yellow);
                Menu.Numbercheck(ref rs);

            }


        }
        public static void Numbercheck(ref bool x)
        {
            a = Console.ReadLine();
            bool strconverter = int.TryParse(a, out i);
            if (strconverter)
            {
                Menu.numcheck = int.TryParse(a, out Menu.i);
                if (mmenu == false)
                {
                    Returnfunc(ref x);
                }
            }
            else
            {
                Colorful.Console.WriteLine("That's an invalid number", Color.Red);
            }
        }
        public static void Returnfunc(ref bool x)
        {
            if (i == 0)
            {
                mmenu = true;
                x = false;
            }
            else
            {
                Colorful.Console.WriteLine("That's an invalid number", Color.Red);
            }
        }
    }
}