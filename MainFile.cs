using System;
using System.Drawing;

namespace ProjectB_Group2
{
    class MainFile
    {
        public static bool run = true;
        static void Main(string[] args)
        {
            while (run)
            {
                LoginClass.LoginMethod();
                Menu.MainMenu();
            }

        }
    }
}
