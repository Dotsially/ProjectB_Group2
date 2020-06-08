﻿using System;
using Newtonsoft.Json.Linq;




class MainClass
{
    public static void Main(string[] args)
    {
        string ReservationAmount;
        int res = 0;
        string ConfirmReservation;
        int TotalCapacity;
        TotalCapacity = 50;
        bool CheckYN = false;
        int Test = 0;
        bool allDigits = false;
        bool allDigits2 = false;

    
        string resName;
        string resNumber;
        string resEmail;
        string resDate;


        Console.WriteLine("What name should we use for the reservation?");
        resName = Console.ReadLine();

        Console.WriteLine("What telephone number should we use for the reservation?");
        resNumber = Console.ReadLine();

        Console.WriteLine("What email should we use for the reservation?");
        resEmail = Console.ReadLine();

        Console.WriteLine("What date wold you like to reserve?");
        resDate = Console.ReadLine();

        





        // INTRO, SHOW CAPACITY AND ENTER HOW MANY PEOPLE YOU WANT TO RESERVE FOR. 
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

