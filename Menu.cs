using System;
using System.Drawing;

namespace ProjectB_Group2
{
    class Menu
    {
        static int i = 0;
        static bool numcheck;
        static bool mmenu = true;
        static bool fmenu = false;
        static bool rv = false;
        static bool rs = false;
        static bool run = true;
        public static void MainMenu()
        {
            while (run)
            {
                while (mmenu)
                {
                    Colorful.Console.WriteLine("[1] Menu [2] Reservation [3] Reviews [4]Quit", Color.Yellow);
                    Colorful.Console.WriteLine("Welcome to our Restaurant please choose a number to proceed: ", Color.Yellow);
                    Menu.Numbercheck();
                    while (!Menu.numcheck)
                    {
                        Colorful.Console.WriteLine("That's an invalid number", Color.Red);
                        Menu.Numbercheck();
                    }
                    if (Menu.i == 1)
                    {
                        mmenu = false;
                        fmenu = true;
                    }
                    if (Menu.i == 2)
                    {
                        mmenu = false;
                        rs = true;
                    }
                    if (Menu.i == 3)
                    {
                        mmenu = false;
                        rv = true;
                    }
                    if (Menu.i == 4)
                    {
                        mmenu = false;
                        run = false;
                    }

                }
                while (fmenu == true)
                {
                    Colorful.Console.WriteLine("W.I.P Menu\n[0] To Return", Color.Yellow);
                    Menu.Numbercheck();
                    Returnfunc(ref fmenu);
                }
                while (rv == true)
                {
                    Colorful.Console.WriteLine("W.I.P Reviews\n[0] To Return", Color.Yellow);
                    Menu.Numbercheck();
                    Returnfunc(ref rv);
                }
                while (rs == true)
                {
                    Colorful.Console.WriteLine("W.I.P Reservation\n[0] To Return", Color.Yellow);
                    Menu.Numbercheck();
                    Returnfunc(ref rs);

                }


            }
        }
        public static void Numbercheck()
        {
            string a;
            a = Console.ReadLine();
            Menu.numcheck = int.TryParse(a, out Menu.i);
        }
        public static void Returnfunc(ref bool x){
            if (i == 0)
            {
                mmenu = true;
                x = false;
            }
        }
    }
}