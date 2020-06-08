using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;
using Newtonsoft.Json;


namespace ReservationAmount
{






    public class reservation
    {
        public string ResName { get; set; }
        public string ResDate { get; set; }


    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string ReservationAmount;
            int res = 0;
            string ConfirmReservation;
            int TotalCapacity;
            TotalCapacity = 50;
            bool CheckYN = false;
            bool allDigits = false;
            bool allDigits2 = false;

            static void ViewReserv()
            {
                using (StreamReader file = File.OpenText(@"d:\test.json"))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    reservation movie2 = (reservation)serializer.Deserialize(file, typeof(reservation));
                    Console.WriteLine(movie2);
                }
            }


            static void Reserve()
            {
                Console.WriteLine("Under which name can we register the reservation?");
                string ResName = Console.ReadLine();
                Console.WriteLine("Under which date can we register the reservation?\n Please enter date with format below\n 'xx-xx-xxxx'\n Example: 04-07-2020");
                string ResDate = Console.ReadLine();

                // Make object for reservation
                reservation resobj = new reservation()
                {
                    ResName = ResName,
                    ResDate = ResDate
                };

                //Write to .Json File (location on drive needs to be edited for final version)
                using (StreamWriter file = File.AppendText(@"d:\test.json"))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, resobj);
                }
                











            }

            // INTRO, SHOW CAPACITY AND ENTER HOW MANY PEOPLE YOU WANT TO RESERVE FOR. 
            Console.WriteLine("Enter '1' to make a reservation\nEnter '2' to view reservations");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {
                Reserve();
            }
            else if (answer == 2)
            {
                ViewReserv();
            }

            Console.WriteLine("We have a total of " + TotalCapacity + " seats.");
            Console.WriteLine("Hello! How many people will be visiting us?");
            ReservationAmount = Console.ReadLine();
            //res = Convert.ToInt32(ReservationAmount);




            //check if input is a number or not.
            allDigits = ReservationAmount.All(char.IsDigit);
            Console.WriteLine(allDigits);


            if (allDigits == false)
            {
                while (allDigits == false)
                {
                    Console.WriteLine("Hello! How many people will be visiting us?");
                    ReservationAmount = Console.ReadLine();
                    allDigits = ReservationAmount.All(char.IsDigit);

                }
                if (allDigits == true)
                {
                    res = Convert.ToInt32(ReservationAmount);
                    allDigits = true;

                }
            }

            if (allDigits == true)
            {
                res = Convert.ToInt32(ReservationAmount);
            }

            //check if not smaller then 0 or 
            while (res < 1 || res > 50)
            {
                Console.WriteLine("You can reserve for minimum of 1 or maximum of 50 person(s)");
                ReservationAmount = Console.ReadLine();
                allDigits = ReservationAmount.All(char.IsDigit);
                if (allDigits == true)
                {
                    res = Convert.ToInt32(ReservationAmount);
                    allDigits = true;
                }
            }

            //See the input
            if (int.TryParse(ReservationAmount, out res))
            {
                Console.WriteLine("Your input: {0}, is a number", res);
            }
            else
            {
                Console.WriteLine("Your input {0} is NOT a Number", res);
            }


            // Confirm it with yes or no
            Console.WriteLine("Are you sure?");
            Console.WriteLine("Y/N: ");
            ConfirmReservation = Console.ReadLine();

            if (ConfirmReservation.Contains("Y") == true)
            {
                CheckYN = true;
            }
            if (ConfirmReservation.Contains("N"))
            {
                CheckYN = true;
            }

            while (CheckYN == false)
            {
                Console.WriteLine("Please enter either 'Y' or 'N'");
                ConfirmReservation = Console.ReadLine();
                if (ConfirmReservation == "Y")
                {
                    CheckYN = true;
                }
                if (ConfirmReservation == "N")
                {
                    CheckYN = true;
                }
            }

            //What happens if you enter Y or N (yes or no).
            if (ConfirmReservation.Equals("Y"))
            {
                Console.WriteLine("Reservation Complete! Thank you for reserving at our restaurant, whe hope to see you soon!");
                TotalCapacity = TotalCapacity - res;
                Console.WriteLine("We have " + TotalCapacity + " seats left");
                Console.ReadLine();
            }
            else if (ConfirmReservation == "N")
            {
                Console.WriteLine("How many people will be visiting?: ");
                ReservationAmount = Console.ReadLine();
                allDigits2 = ReservationAmount.All(char.IsDigit);
            }

            if (allDigits2 == false)
            {
                while (allDigits2 == false)
                {
                    Console.WriteLine("Hello! How many people will be visiting us?");
                    ReservationAmount = Console.ReadLine();
                    allDigits2 = ReservationAmount.All(char.IsDigit);

                }
                if (allDigits2 == true)
                {
                    res = Convert.ToInt32(ReservationAmount);
                    allDigits = true;

                }
            }


            if (allDigits2 == true)
            {
                res = Convert.ToInt32(ReservationAmount);
            }

            while (res <= 0 || res > 50)
            {
                Console.WriteLine("Please enter a number between 1 and 50.");
                ReservationAmount = Console.ReadLine();
                res = Convert.ToInt32(ReservationAmount);
            }
            {
                TotalCapacity = TotalCapacity - res;
                Console.WriteLine("Reservation Complete! Thank you for reserving at our restaurant, whe hope to see you soon!");
                Console.WriteLine("We have " + TotalCapacity + " seats left");
                Console.ReadLine();
            }


            while (allDigits2 == false)
            {
                if (allDigits2 == false)
                {
                    Console.WriteLine("Please enter a number!");
                    ReservationAmount = Console.ReadLine();
                    allDigits2 = ReservationAmount.All(char.IsDigit);
                }
                if (allDigits2 == true)
                {
                    allDigits2 = true;
                    res = Convert.ToInt32(ReservationAmount);
                    TotalCapacity = TotalCapacity - res;
                    Console.WriteLine("Reservation Complete! Thank you for reserving at our restaurant, whe hope to see you soon!");
                    Console.WriteLine("We have " + TotalCapacity + " seats left");
                    Console.ReadLine();
                }
            }

        }
    }
}

