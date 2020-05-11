using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace ProjectB_Group2
{






    class MainFile
    {
        static void Main(string[] args)

        {
            string reservationName;
            string Date;
            string Persons;

            


            {
                Console.Write("Please enter a name for the reservation ([C] to cancel): ");
                reservationName = Console.ReadLine();



                while (string.IsNullOrEmpty(reservationName))
                {
                    Console.WriteLine("Empty input, Please try again");
                    reservationName = Console.ReadLine();
                }
                Console.Clear();

            }

            Console.Write("Please enter date for the reservation: ");
            Date = Console.ReadLine();

            Console.Write("Please enter how many people are coming");
            Persons = Console.ReadLine();


            using (var streamWriter = new StreamWriter("C:\\Users\\micha\\Documents\\GitHub\\ProjectB_Group2\\toFile.csv"))
            {
                streamWriter.WriteLine("ONE, TWO, THREE");
                
                {

                    streamWriter.WriteLine(reservationName + "," + Date + "," + Persons);
                }
            }

        }
        }
    }



