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



            // ============================ naam van het gerecht ========================================================

            public string getName()

            {

                return Name;

            }



            // ========================= beschrijving van het gerecht ===================================================

            public string getdescription()

            {

                return Description;

            }



            //============================== prijs van het gerecht ======================================================

            public double getprice()

            {

                return Price;

            }



            // ============================ locatie van het gerecht =====================================================

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
                Console.WriteLine("Which Dish do you want to remove from the menu?");
                string Remove = Console.ReadLine();
                Console.WriteLine(Remove);
                for(int i = 0; i < lst.Count; i++)
                {

                    Console.WriteLine("Test");
                    if (lst[i].Name == Remove)
                    {
                        lst.RemoveAt(i);
                        Console.WriteLine("The Dish " + Remove + " was successfully removed");

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
                    Console.WriteLine("Enter the name of the dish:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the price of the dish:");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter the description of the given dish:");
                    string description = Console.ReadLine();
                    Dishes newDish = new Dishes(name, price, description);
                    lst.Add(newDish);
                }
                

                
                foreach(Dishes dish in lst)
                {
                    Console.WriteLine(dish.PrintDishes());
                }
            }

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

            public static void Main(string[] args)

            {

                // =========================== Creating object ==========================================================
                /* Dishes PizzaMargherita = new Dishes("Pizza Margherita", "Pizza met zooi", 8, "Pizza");
                 PizzaMargherita.AddDish(); 
                 Console.WriteLine();
                 PizzaMargherita.RemoveDish();
                 Console.WriteLine(); */

                //=========================== Adding dishes to the menu ==========================================================
                Console.WriteLine("Do you want to add dishes to the menu? [Y] for yes and [N] for removing dishes from the menu or [M] for displaying the menu");
                char answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'y' || answer == 'Y')
                {
                    AddDishes();
                    Main(null);
                } else if(answer == 'n' || answer == 'N')
                {
                    RemoveDishes();
                    Main(null);
                } else if (answer == 'm' || answer == 'M')
                {
                    DisplayMenu(lstApettizers, lstMainMenu, lstDesserts);
                }



            }

        }

    }

}
