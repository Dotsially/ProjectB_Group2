using System;

namespace ProjectB_Group2
{
     // ============================  Class Declaration =============================================================
    public class MyDish
    {

        // ===========================  Variables =================================================================
        string name;
        string description;
        int price;
        string location;

        // ======================== Declaration of Class ============================================================
        public MyDish(string name, string description,
                      int price, string location)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.location = location;
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
            MyDish PizzaMargherita = new MyDish("Pizza Margherita", "Pizza met zooi", 8, "Pizza");
            PizzaMargherita.AddDish();
            Console.WriteLine();
            PizzaMargherita.RemoveDish();
            Console.WriteLine();

            MyDish PastaBolognese = new MyDish("Pasta Bolognese", "Pasta met zooi", 7, "Pasta");
            PastaBolognese.AddDish();
            Console.WriteLine();
            PastaBolognese.RemoveDish();
            Console.WriteLine();
        }
    }
}
