using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Menu
{
    class Program
    {
        // ============================  Class Declaration =============================================================

        public class Dishes
        {
            // ===========================  Variables =================================================================

            string name;
            string description;
            double price;
            string location;
            List<Dishes> lstDishes = new List<Dishes>();



            // ======================== Declaration of Class ============================================================
            public string PrintDishes()
            {
                return this.name + "-------------------- $" + this.price;
            }


            // =================================  Menu ===============================================================

            public void Menu()
            {

                Console.WriteLine("Please enter amount of dishes to be added: ");
                int x = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < x; i++)
                {
                    lstDishes.Add(new Dishes());
                    Console.WriteLine("Please enter dish: ");
                    string Dish = Console.ReadLine();
                    Console.WriteLine("Please enter the price: ");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    lstDishes[i].name = Dish;
                    lstDishes[i].price = amount;

                }


                foreach (Dishes dish in lstDishes)
                {
                    Console.WriteLine(dish.PrintDishes());
                    dish.AddDish();

                }

            }



            // ============================ naam van het gerecht ========================================================

            public string getName()

            {

                return name;

            }



            // ========================= beschrijving van het gerecht ===================================================

            public string getdescription()

            {

                return description;

            }



            //============================== prijs van het gerecht ======================================================

            public double getprice()

            {

                return price;

            }



            // ============================ locatie van het gerecht =====================================================

            public string getlocation()

            {

                return location;

            }



            // =============================== Method add ==============================================================

            public void AddDish()

            {

                Console.WriteLine("The dish " + this.getName() + " will be added to the menu!");
                Console.WriteLine("It will cost: " + this.getprice() + " Euros");
                Console.WriteLine("And it will have the following description: " + this.getdescription());
                Console.WriteLine("It will be sorted under: " + this.getlocation());
                Console.WriteLine();

            }



            // ============================= Method Remove =========================================================

            public void RemoveDish()

            {
                Console.WriteLine("Which Dish do you want to remove from the menu?");
                string Remove = Console.ReadLine();
                Console.WriteLine(Remove);
                foreach (Dishes Dish in lstDishes)
                {
                    Console.WriteLine("Test");
                    if (Dish.name == Remove)
                    {
                        lstDishes.Remove(Dish);
                        Console.WriteLine("The Dish " + Remove + " was successfully removed");
                    }
                }
            }

            // ============================== Main Method =============================================================

            public static void Main(string[] args)

            {

                // =========================== Creating object ==========================================================
                /* Dishes PizzaMargherita = new Dishes("Pizza Margherita", "Pizza met zooi", 8, "Pizza");
                 PizzaMargherita.AddDish(); 
                 Console.WriteLine();
                 PizzaMargherita.RemoveDish();
                 Console.WriteLine(); */

                //=========================== Adding dishes to the menu ==========================================================
                Console.WriteLine("Do you want to add or remove dishes from the menu? [Y] for Add and [N} for Remove, press any other key to exit");
                char answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'y' || answer == 'Y')
                {
                    Dishes AddDishes = new Dishes();
                    AddDishes.Menu();
                    Main(null);
                }
                if (answer == 'n' || answer == 'N')
                {
                    Dishes RemoveDishes = new Dishes();
                    RemoveDishes.RemoveDish();
                    Main(null);
                }
                //else
                //{
                //    Environment.Exit(0);
                //}




                /*
                Dishes PastaBolognese = new Dishes("Pasta Bolognese", "Pasta met zooi", 7, "Pasta");
                PastaBolognese.AddDish();
                Console.WriteLine();
                PastaBolognese.RemoveDish();
                Console.WriteLine(); */

            }

        }

    }

}


