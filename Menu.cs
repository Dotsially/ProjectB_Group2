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
        static bool bt = false;
        public static void MainMenu()
        {
            if (LoginClass.admin)
            {
                MenuAdmin();
            }
            else
            {
                MenuUser();
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
        public static void MenuAdmin()
        {
            while (mmenu)
            {
                Colorful.Console.WriteLine("[1]Menu [2]Reservation [3]Reviews [4]Bank Transfer [5]Quit", Color.Yellow);
                Colorful.Console.WriteLine("Welcome to our Restaurant please choose a number to proceed: ", Color.Yellow);
                Numbercheck(ref mmenu);

                while (!Menu.numcheck)
                {
                    Colorful.Console.WriteLine("That's an invalid number", Color.Red);
                    Numbercheck(ref mmenu);
                }

                if (Menu.i == 1)
                {
                    mmenu = false;
                    Console.Clear();
                    Program.Dishes.MenuFunctionAdmin();
                    fmenu = true;
                }

                else if (Menu.i == 2)
                {
                    mmenu = false;
                    Console.Clear();
                    ReservationsClass.ResevationsAdmin();
                    rs = true;
                }

                else if (Menu.i == 3)
                {
                    mmenu = false;
                    Console.Clear();
                    Review2.Review.ReviewsFunctionAdmin();
                    rv = true;
                }

                else if (Menu.i == 4)
                {
                    mmenu = false;
                    Console.Clear();
                    BankTransferClass.BankTransfer();
                    bt = true;
                }
                else if (Menu.i == 5)
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
                Numbercheck(ref fmenu);
                Console.Clear();
            }

            while (rv == true)
            {
                Colorful.Console.WriteLine("[0] To Return", Color.Yellow);
                Numbercheck(ref rv);
                Console.Clear();
            }

            while (rs == true)
            {
                Colorful.Console.WriteLine("[0] To Return", Color.Yellow);
                Numbercheck(ref rs);
                Console.Clear();

            }
            while (bt == true)
            {
                Colorful.Console.WriteLine("[0] To Return", Color.Yellow);
                Numbercheck(ref bt);
                Console.Clear();

            }
        }
        public static void MenuUser()
        {
            while (mmenu)
            {
                Colorful.Console.WriteLine("[1]Menu [2]Reservation [3]Reviews [4]Quit", Color.Yellow);
                Colorful.Console.WriteLine("Welcome to our Restaurant please choose a number to proceed: ", Color.Yellow);
                Numbercheck(ref mmenu);

                while (!Menu.numcheck)
                {
                    Colorful.Console.WriteLine("That's an invalid number", Color.Red);
                    Numbercheck(ref mmenu);
                }

                if (Menu.i == 1)
                {
                    mmenu = false;
                    Console.Clear();
                    Program.Dishes.MenuFunctionUser();
                    fmenu = true;
                }

                else if (Menu.i == 2)
                {
                    mmenu = false;
                    Console.Clear();
                    ReservationsClass.ResevationsUser();
                    rs = true;
                }

                else if (Menu.i == 3)
                {
                    mmenu = false;
                    Console.Clear();
                    Review2.Review.ReviewsFunctionUser();
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
                Numbercheck(ref fmenu);
                Console.Clear();
            }

            while (rv == true)
            {
                Colorful.Console.WriteLine("[0] To Return", Color.Yellow);
                Numbercheck(ref rv);
                Console.Clear();
            }

            while (rs == true)
            {
                Colorful.Console.WriteLine("[0] To Return", Color.Yellow);
                Numbercheck(ref rs);
                Console.Clear();

            }
            
        }
    }
}