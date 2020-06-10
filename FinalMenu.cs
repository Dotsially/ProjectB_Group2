using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace ProjectB_Group2
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

            public static void InitMenu(List<Dishes> apettizers, List<Dishes> Main, List<Dishes> Desserts)
            {
                // Appetizers
                Dishes dish1 = new Dishes("Pane", 5.50, "Homemade bread with Tapenade");
                Dishes dish2 = new Dishes("Insalata Mista", 5.50, "Small mixed salad");
                Dishes dish3 = new Dishes("Insalata Vegetariana", 16.50, "Salad with different grilled vegetables");
                Dishes dish4 = new Dishes("Spiedini Di Scampi", 10.00, "Grilled Shrimpskewer");
                apettizers.Add(dish1);
                apettizers.Add(dish2);
                apettizers.Add(dish3);
                apettizers.Add(dish4);

                //Main Menu
                Dishes dish5 = new Dishes("Pizza Margherita", 8.00, "Flour, Garlic, Tomatoes, Mozzarella, Basil");
                Dishes dish6 = new Dishes("Pizza Prosciutto", 10.00, "Flour, Tomatoes, Parmesan Cheese, Prosciutto");
                Dishes dish7 = new Dishes("Pizza Funghi", 10.50, "Flour, Tomatoes, Mozzarella, Mushrooms");
                Dishes dish8 = new Dishes("Spaghetti Bolognese", 13.50, "Spaghetti, Tomato Sauce, Minced Meat, Onion, Celery");
                Dishes dish9 = new Dishes("Spaghetti Al Pomodoro Fresco", 11.00, "Spaghetti, Tomato Sauce, Garlic, Basil");
                Dishes dish10 = new Dishes("Penne Scampi", 17.00, "Shrimp in tomato sauce");
                Main.Add(dish5);
                Main.Add(dish6);
                Main.Add(dish7);
                Main.Add(dish8);
                Main.Add(dish9);
                Main.Add(dish10);

                // Desserts
                Dishes dish11 = new Dishes("Scroppino", 5.50, "Lemon sorbet with prosecco and vodka");
                Dishes dish12 = new Dishes("Coupe Amarena", 6.50, "Vanilla ice cream with cherries and whipped cream");
                Dishes dish13 = new Dishes("Coupe sorbetto", 6.50, "Sorbet with whipped cream and sorbetsauce");
                Desserts.Add(dish11);
                Desserts.Add(dish12);
                Desserts.Add(dish13);
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
                Console.WriteLine("Choose [1] for appetizers, [2] for the main menu, [3] for the desserts or [0] to go back to the menu.");
                int x = Convert.ToInt32(checkInt());
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
                else if (x == 0)
                {

                }
                else
                {
                    Console.WriteLine("Incorrect Value, Please enter one of the characters specified above!");
                    AddDishes();
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
                        string check = Console.ReadLine();
                        double NewPrice;
                        if (Double.TryParse(check, out NewPrice))
                            Console.WriteLine("'{0}' --> {1}", check, NewPrice);
                        else
                            Console.WriteLine("Incorrect value, Please enter a number:");
                        while (!Double.TryParse(check, out NewPrice))
                        {
                            Console.WriteLine("Enter the price of the dish:");
                            check = Console.ReadLine();
                        }
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
                int x = Convert.ToInt32(checkInt()); 
                for (int i = 0; i < x; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the dish:");
                    string name = validateString();
                    Console.WriteLine();
                    Console.WriteLine("Enter the price of the dish:");
                    string check = Console.ReadLine();
                    double price;
                    if (Double.TryParse(check, out price))
                        Console.WriteLine("'{0}' --> {1}", check, price);
                    else
                        Console.WriteLine("Incorrect value, Please enter a number:");
                        while (!Double.TryParse(check, out price))
                    {
                        Console.WriteLine("Enter the price of the dish:");
                        check = Console.ReadLine();
                    }

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
                int x = Convert.ToInt32(checkInt());
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
                else if (x == 0)
                {

                }
                else
                {
                    Console.WriteLine("Incorrect value, Please enter one of the characters specified above!");
                    AddDishes();
                }

            }


            // ================================= Changing prices on the right menu ========================================
            public static void ChangePrices()
            {
                Console.WriteLine("Choose [1] for appetizers, [2] for the main menu, [3] for the desserts or [0] to go back to the menu.");
                int x = Convert.ToInt32(checkInt());
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
                else if (x == 0)
                {

                }
                else
                {
                    Console.WriteLine("Incorrect Value, Please enter one of the characters specified above!");
                    AddDishes();
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

            public static bool isNumeric(string s)
            {
                return int.TryParse(s, out int n);
            }

            public static string checkInt()
            {
                string s;

                s = Console.ReadLine();

                while (!isNumeric(s))
                {
                    Console.WriteLine("Invalid input! Please try again!");
                    s = Console.ReadLine();
                }
                return s;

            }

            public static void MenuFunction()

            {
                Dishes.InitMenu(lstApettizers, lstMainMenu, lstDesserts);

                //=========================== Main menu screen where you choose what to do ==========================================================
                char[] charArray = new char[] { '1', '2', '3', '4', '5' };
                Console.WriteLine("What do you want to do?\n[1] for Adding dishes to the Menu\n[2] for Removing dishes from the Menu\n[3] for Displaying the Menu\n[4] to Change the price of a dish\n[5] to exit");
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
                        Console.WriteLine("Please try again!");
                    }
                }

                if (answer == '1')
                {
                    Console.Clear();
                    AddDishes();
                    Console.WriteLine();

                }
                else if (answer == '2')
                {
                    Console.Clear();
                    RemoveDishes();
                    Console.WriteLine();

                }
                else if (answer == '3')
                {
                    Console.Clear();
                    DisplayMenu(lstApettizers, lstMainMenu, lstDesserts);
                    Console.WriteLine();

                }
                else if (answer == '4')
                {
                    Console.Clear();
                    ChangePrices();
                    Console.WriteLine();

                }
                else if (answer == '5')
                {
                    
                }
            }
        }
    }
}

