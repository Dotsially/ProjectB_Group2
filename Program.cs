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

            string name;
            string description;
            int price;
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
                    int amount = Convert.ToInt32(Console.ReadLine());
                    lstDishes[i].name = Dish;
                    lstDishes[i].price = amount;

                }


                foreach(Dishes dish in lstDishes)
                {
                    Console.WriteLine(dish.PrintDishes());
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

            public int getprice()

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

            }



            // ============================= Method Remove =========================================================

            public void RemoveDish()

            {
                Console.WriteLine("The dish " + this.getName() + " will be removed from the menu!");

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
                Console.WriteLine("Do you want to add dishes to the menu? [Y] for yes and [N} for no");
                char answer = Convert.ToChar(Console.ReadLine());
                if(answer == 'y' || answer == 'Y')
                {
                    Dishes AddDishes = new Dishes();
                    AddDishes.Menu();
                }
                
                


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
