using System;
using static ProjectB_Group2.Filemanager;
using static ProjectB_Group2.LoginClass;
using static ProjectB_Group2.Menu;

namespace ProjectB_Group2
{
    public partial class MainFile
    {
        public static bool run = true;
        static void Main(string[] args)
        {
            while (run)
            {
                RestaurantSetup();
                LoginMethod();
                MainMenu();
            }
        }
    }
}
