using System;
using System.Collections.Generic;

namespace Menu
{
    class Program
    {
        // ============================  Class Declaration =============================================================

        public class Dishes
        {
            // ===========================  Variables =================================================================

            string Name;
            string Description;
            double Price;
            string Location;
            static List<Dishes> lstApettizers = new List<Dishes>();
            static List<Dishes> lstMainMenu = new List<Dishes>();
            static List<Dishes> lstDesserts = new List<Dishes>();
            public Dishes(string name, double price, string description)
            {
                Name = name;
                Price = price;
                Description = description;

            }

            // ======================== Declaration of Class ============================================================
            public string PrintDishes()
            {
                int x = this.Name.Length;
                string line = new String('-', (50 - x));
                Console.WriteLine();
                return this.Name + line + "$" + this.Price + "\n  +" + this.Description;

            }

            // =================================  Display Menu ===============================================================

            public static void DisplayMenu(List<Dishes> Apettizers, List<Dishes> MainDish, List<Dishes> Desserts)
            {
                //Find a way to add section name above the dishes, so Apettizers - "bread, salad, etc."
                List<Dishes> newList = new List<Dishes>();
                newList.AddRange(Apettizers);
                newList.AddRange(MainDish);
                newList.AddRange(Desserts);
                string[] array = new string[] { "Appetizers", "MainDishes", "Desserts" };
                foreach (Dishes Section in newList)
                {
                    Console.WriteLine(Section.PrintDishes() + "\n");

                }
            }

            // ============================ name of the Dish ========================================================
            public string getName()
            {
                return Name;
            }

            // ========================= Description of the Dish ===================================================
            public string getdescription()
            {
                return Description;
            }

            //============================== Price of the Dish ======================================================

            public double getprice()
            {
                return Price;
            }

            // ============================ Location of the Dish =====================================================
            public string getlocation()
            {
                return Location;
            }

            // =============================== Method add ==============================================================

            public static void AddDishes()
            {
                Console.WriteLine("Choose [1] for appetizers, [2] for the main menu or [3] for the desserts");
                int x = Convert.ToInt32(Console.ReadLine());
                if (x == 1)
                {
                    newDishes(lstApettizers);
                }
                else if (x == 2)
                {
                    newDishes(lstMainMenu);
                }
                else if (x == 3)
                {
                    newDishes(lstDesserts);
                }

            }


            // ============================= Method Remove =========================================================

            public static void RemoveDish(List<Dishes> lst)

            {
                Console.WriteLine();
                Console.WriteLine("Which Dish do you want to remove from the menu?");
                string Remove = Console.ReadLine();
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i].Name == Remove)
                    {
                        lst.RemoveAt(i);
                        Console.WriteLine();
                        Console.WriteLine("The Dish " + Remove + " was successfully removed");
                        Console.WriteLine();
                    }

                }

            }

            // ================================ Change price =======================================================
            public static void ChangePrice(List<Dishes> lst)
            {
                Console.WriteLine();
                Console.WriteLine("Which Dish would you like to change?");
                string change = Console.ReadLine();
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i].Name == change)
                    {
                        Console.WriteLine();
                        Console.WriteLine("What is the new price of " + change + "?");
                        double NewPrice = Convert.ToDouble(Console.ReadLine());
                        lst[i].Price = NewPrice;
                        Console.WriteLine();
                        Console.WriteLine("The Price of " + change + " was updated to: " + NewPrice);
                        Console.WriteLine();
                    }
                }

            }


            // ============================== Adding dishes to the right list =============================================================
            public static void newDishes(List<Dishes> lst)
            {

                Console.WriteLine("Enter the amount of dishes you want to add: ");
                int x = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < x; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the dish:");
                    string name = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter the price of the dish:");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Enter the description of the given dish:");
                    string description = Console.ReadLine();
                    Dishes newDish = new Dishes(name, price, description);
                    lst.Add(newDish);
                }



                foreach (Dishes dish in lst)
                {
                    Console.WriteLine(dish.PrintDishes());
                }
            }


            // ================================== Removing dishes from the right menu ======================================
            public static void RemoveDishes()
            {
                Console.WriteLine("Choose [1] for appetizers, [2] for the main menu or [3] for the desserts");
                int x = Convert.ToInt32(Console.ReadLine());
                if (x == 1)
                {
                    RemoveDish(lstApettizers);
                }
                else if (x == 2)
                {
                    RemoveDish(lstMainMenu);
                }
                else if (x == 3)
                {
                    RemoveDish(lstDesserts);
                }

            }


            // ================================= Changing prices on the right menu ========================================
            public static void ChangePrices()
            {
                Console.WriteLine("Choose [1] for appetizers, [2] for the main menu or [3] for the desserts");
                int x = Convert.ToInt32(Console.ReadLine());
                if (x == 1)
                {
                    ChangePrice(lstApettizers);
                }
                else if (x == 2)
                {
                    ChangePrice(lstMainMenu);
                }
                else if (x == 3)
                {
                    ChangePrice(lstDesserts);
                }

            }

            public static void Main(string[] args)

            {

                //=========================== Main menu screen where you choose what to do ==========================================================
                Console.WriteLine("What do you want to do?\n[Y] for Adding dishes to the Menu\n[N] for Removing dishes from the Menu\n[M] for Displaying the Menu\n[C] to Change the price of a dish\nany other key to exit");
                char answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'y' || answer == 'Y')
                {
                    AddDishes();
                    Console.WriteLine();
                    Main(null);
                }
                else if (answer == 'n' || answer == 'N')
                {
                    RemoveDishes();
                    Console.WriteLine();
                    Main(null);
                }
                else if (answer == 'm' || answer == 'M')
                {
                    DisplayMenu(lstApettizers, lstMainMenu, lstDesserts);
                    Console.WriteLine();
                    Main(null);
                }
                else if (answer == 'c' || answer == 'C')
                {
                    ChangePrices();
                    Console.WriteLine();
                    Main(null);
                }
                else
                {
                    Environment.Exit(0);
                }



            }

        }

    }

}

