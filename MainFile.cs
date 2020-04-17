using System;
using System.Drawing;
using static ProjectB_Group2.Filemanager;
using static ProjectB_Group2.LoginClass;
using static ProjectB_Group2.Menu;

namespace ProjectB_Group2
{
    class MainFile
    {
        public static bool run = true;
        static void Main(string[] args)
        {
            RestaurantSetup();
            LoginMethod();
            MainMenu();
        }
    }
}
