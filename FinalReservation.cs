using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;
using static ProjectB_Group2.Filemanager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ProjectB_Group2
{

    public class reservation
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Seats { get; set; }


    }

    public class ReservationsClass
    {
        static string SResName;
        static string SResDate;
        static string SResSeats;
        
        //static reservation file = JsonConvert.DeserializeObject<reservation>(Path.Combine(jsondoc, @"Restaurant/json/reservations.json"));


        public static void ResevationsUser()
        {
            string ReservationAmount;
            int res = 0;
            string ConfirmReservation;
            int TotalCapacity;
            TotalCapacity = 50;
            bool CheckYN = false;
            bool allDigits = false;
            bool allDigits2 = false;
            Console.WriteLine("[1] To make a reservation\n[2] To view reservations\n[3] to exit");


            int answer = Convert.ToInt32(Console.ReadLine());


            if (answer == 1)
            {
                Console.Clear();
                Reserve();
                Console.WriteLine("We have a total of " + TotalCapacity + " seats.");
                Console.WriteLine(" How many people will be visiting us?");
                ReservationAmount = Console.ReadLine();
                //res = Convert.ToInt32(ReservationAmount);

                //check if input is a number or not.
                allDigits = ReservationAmount.All(char.IsDigit);
                Console.WriteLine(allDigits);

                if (allDigits == false)
                {
                    while (allDigits == false)
                    {
                        Console.WriteLine("How many people will be visiting us?");
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
                }
                else if (ConfirmReservation == "N")
                {
                    Console.WriteLine("How many people will be visiting?: ");
                    ReservationAmount = Console.ReadLine();
                    allDigits2 = ReservationAmount.All(char.IsDigit);
                    if (allDigits2 == false)
                    {
                        while (allDigits2 == false)
                        {
                            Console.WriteLine("How many people will be visiting us?");
                            ReservationAmount = Console.ReadLine();
                            allDigits2 = ReservationAmount.All(char.IsDigit);

                        }
                        if (allDigits2 == true)
                        {
                            res = Convert.ToInt32(ReservationAmount);
                            allDigits = true;
                            TotalCapacity = TotalCapacity - res;
                            Console.WriteLine("Reservation Complete! Thank you for reserving at our restaurant, whe hope to see you soon!");
                            Console.WriteLine("We have " + TotalCapacity + " seats left");

                        }
                    }
                }





                while (res <= 0 || res > 50)
                {
                    Console.WriteLine("Please enter a number between 1 and 50.");
                    ReservationAmount = Console.ReadLine();
                    res = Convert.ToInt32(ReservationAmount);
                }
                SResSeats = ReservationAmount;

                reservation resobj = new reservation
                {
                    Name = SResName,
                    Date = SResDate,
                    Seats = SResSeats
                };
                string[] restxt = { SResName, SResDate, SResSeats };
                string path = jsonpathwrite("reservations.txt");



                Console.WriteLine();
                File.AppendAllText(path, "------------------------------\n");
                File.AppendAllText(path, "Name: "+ SResName + "\n");
                File.AppendAllText(path, "Date: " + SResDate +"\n");
                File.AppendAllText(path, "Seats: " + SResSeats +"\n");
                File.AppendAllText(path, "------------------------------\n");

            }
            else if (answer == 2)
            {
                Console.Clear();
                ViewReserv();
            }
            else if (answer == 3)
            {
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid number!");
            }


            

        }
        public static void ResevationsAdmin()
        {
            
            Console.WriteLine("[1] To view reservations\n[2] To exit");


            int answer = Convert.ToInt32(Console.ReadLine());


            if (answer == 1)
            {
                Console.Clear();
                ViewReserv();
            }
            else if (answer == 2)
            {
                Console.Clear();
            }
            
            }
        static void ViewReserv()
        {
            
                string path = jsonpathwrite("reservations.txt");
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                    Console.WriteLine(line);

                Console.ReadLine();
                Console.Clear();

            

        }
        public static void Reserve()
        {
            Console.WriteLine("Under which name can we register the reservation?");
            string ResName = Console.ReadLine();
            Console.WriteLine("Under which date can we register the reservation?\n Please enter date with format below\n 'xx-xx-xxxx'\n Example: 04-07-2020");
            string ResDate = Console.ReadLine(), format = "";
            try
            {
                if (ResDate.Contains("-"))
                {
                    format = "dd-MM-yyyy";
                }
                else if (ResDate.Contains("/"))
                {
                    format = "dd/MM/yyyy";
                }
                else if (ResDate.Contains("."))
                {
                    format = "dd.MM.yyyy";
                }
                else if (ResDate.Contains(" "))
                {
                    format = "dd MM yyyy";
                }

                DateTime date = DateTime.ParseExact(ResDate, format, System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine(date.ToShortDateString());
            }
            catch (Exception) { }
            SResName = ResName;
            SResDate = ResDate;

        }
        // INTRO, SHOW CAPACITY AND ENTER HOW MANY PEOPLE YOU WANT TO RESERVE FOR. 


    }
}

