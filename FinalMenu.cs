using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using Newtonsoft.Json;

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
            static List<Dishes> lstDrinks = new List<Dishes>();
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
                Console.WriteLine("Choose [1] for appetizers, [2] for the main menu or [3] for the desserts or [0] to go back to the menu.");
                int x = validateInt();
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
                else
                {
                    Console.WriteLine("Back to the main menu.");
                }

            }


            // ============================= Method Remove =========================================================

            public static void RemoveDish(List<Dishes> lst)

            {   //add check if remove isn't empty.
                Console.WriteLine();
                Console.WriteLine("Which Dish do you want to remove from the menu?");
                string Remove = validateString();
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
                string change = validateString();
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
                    string name = validateString();
                    Console.WriteLine();
                    Console.WriteLine("Enter the price of the dish:");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Enter the description of the given dish:");
                    string description = validateString();
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
                Console.WriteLine("Choose [1] for appetizers, [2] for the main menu, [3] for the desserts or [0] to go back to the menu.");
                int x = validateInt();
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
                else
                {
                    Console.WriteLine("Back to the main menu.");

                }

            }


            // ================================= Changing prices on the right menu ========================================
            public static void ChangePrices()
            {
                Console.WriteLine("Choose [1] for appetizers, [2] for the main menu, [3] for the desserts or [0] to go back to the menu.");
                int x = validateInt();
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
                else
                {
                    Console.WriteLine("Back to the main menu.");
                }

            }
            public static int validateInt()
            {
                bool checker = true;
                int x = 0;
                while (checker)
                {
                    try
                    {
                        x = Convert.ToInt32(Console.ReadLine());
                        if (x >= 0 && x < 4)
                        {
                            checker = false;
                            return x;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect value, please enter a number between 1-3.");

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect value.");
                    }
                }
                return x;

            }

            public static string validateString()
            {
                string x = "";

                x = Console.ReadLine();
                while (string.IsNullOrEmpty(x))
                {
                    Console.WriteLine("Invalid input! Please try again!");
                    x = Console.ReadLine();
                }
                return x;

            }

            public static void Main(string[] args)

            {
                //string json = JsonSerializer.Serialize(lstApettizers);
                //Console.WriteLine(json);


                //=========================== Main menu screen where you choose what to do ==========================================================
                char[] charArray = new char[] { 'P', 'Y', 'N', 'M', 'C' };
                Console.WriteLine("What do you want to do?\n[Y] for Adding dishes to the Menu\n[N] for Removing dishes from the Menu\n[M] for Displaying the Menu\n[C] to Change the price of a dish\nany other key to exit");
                bool check = true;
                char answer = 'E';
                while (check)
                {
                    try
                    {
                        answer = Convert.ToChar(Console.ReadLine());
                        answer = char.ToUpper(answer);
                    }
                    catch
                    {
                        Console.WriteLine("That's not a character, please enter one of the characters defined above to proceed in the program.");
                    }
                    for (int i = 0; i < charArray.Length; i++)
                    {
                        if (answer == charArray[i])
                        {
                            check = false;
                        }
                    }
                    if (check == true)
                    {
                        Console.WriteLine("{0} isn't a valid character, please enter one of the characters defined above to proceed in the program.", answer);
                    }
                }

                if (answer == 'Y')
                {
                    AddDishes();
                    Console.WriteLine();
                    Main(null);
                }
                else if (answer == 'N')
                {
                    RemoveDishes();
                    Console.WriteLine();
                    Main(null);
                }
                else if (answer == 'M')
                {
                    DisplayMenu(lstApettizers, lstMainMenu, lstDesserts);
                    Console.WriteLine();
                    Main(null);
                }
                else if (answer == 'C')
                {
                    ChangePrices();
                    Console.WriteLine();
                    Main(null);
                }
                else if (answer == 'P')
                {
                    //JsonMenu.Test(); //Werkt nog niet
                    Console.WriteLine();
                    Main(null);

                }
                else if (answer == 'E')
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}

