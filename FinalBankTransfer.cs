using System;
using System.Text.Json;
using System.IO;
using System.Reflection;

namespace ProjectB_Group2
{
    public class BankAccount
    {
        public double CompanyBalance { get; set; }
        public string Title { get; set; }

        public BankAccount(double income)
        {
            CompanyBalance = income;
            Title = "Company bank account";
        }
        public BankAccount()
        {
            CompanyBalance = 25000.000;
            Title = "Company bank account";
        }

        public void deposit(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Can't deposite negative value.");
            }
            else
            {
                CompanyBalance += amount;
            }
        }

        public void withdraw(double amount)
        {
            if (amount > CompanyBalance)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                CompanyBalance -= amount;
            }

        }

        public virtual string Info()
        {
            return $"{Title} currently holds: {CompanyBalance} $";
        }
    }

    public class CompanyThreshold : BankAccount
    {
        public string BankAccountName;
        public string Password;
        public bool login;

        public CompanyThreshold(double income) : base(income)
        {
            Title = "Company threshold";
            BankAccountName = "ProjectBAccount";
            Password = "ADKMMM2020";

        }
        public bool LoginIn(string acc, string pass)
        {
            if (acc == BankAccountName && pass == Password)
            {
                login = true;
            }
            return login;
        }

        public override string Info()
        {
            return $"{Title} currently holds: {CompanyBalance} $";

        }
        public void DailyRevenue(BankAccount obj)
        {

            Console.WriteLine($"The total amount off {CompanyBalance} has been added to the company bank account. " +
                $"Total balance is {obj.CompanyBalance + this.CompanyBalance}");
            obj.CompanyBalance += this.CompanyBalance;
        }

    }
    class BankTransferClass
    {
        public static void BankTransfer()
        {
            //Global variable/object, so we don't have multiple objects.
            string fileName = Filemanager.jsonpathwrite("BankTransfer.txt"); //Can be left out in case system doesn't have "C" location.
            string jsonString = File.ReadAllText(fileName);

            CompanyThreshold companyThreshold = new CompanyThreshold(1000);
            BankAccount bankAccount = new BankAccount();

            Console.WriteLine("Enter your bank account: ");
            string account = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            if (companyThreshold.LoginIn(account, password))
            {

                Console.WriteLine("Enter [D] for deposite, [W] for withdraw, [I] for balance information, [R] to deposite daily revenue to bank account or [E] to exit.");
                char answer = validateChar();
                while (answer != 'E')
                {
                    if (answer == 'D')
                    {
                        Console.WriteLine("Enter the amount you want to deposite to the threshold.");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        companyThreshold.deposit(amount);
                        Console.WriteLine(companyThreshold.Info());
                    }
                    else if (answer == 'W')
                    {
                        Console.WriteLine("Enter the amount you want to withdraw to the threshold.");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        companyThreshold.withdraw(amount);
                        Console.WriteLine(companyThreshold.Info());
                    }
                    else if (answer == 'I')
                    {
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine(companyThreshold.Info());
                        Console.WriteLine("-----------------------------------------");
                    }
                    else if (answer == 'R')
                    {
                        companyThreshold.DailyRevenue(bankAccount);
                    }
                    Console.WriteLine("Enter [D] for deposite, [W] for withdraw, [I] for balance information, [R] to deposite daily revenue to bank account or [E] to exit.");
                    answer = validateChar();
                }
                jsonString = JsonSerializer.Serialize(bankAccount);
                File.WriteAllText(fileName, jsonString);
            }
            else
            {
                Console.WriteLine("Incorrect account, bye.");
            }
        }

        public static char validateChar()
        {
            char c = '\0';
            bool validate = true;
            while (validate)
            {
                try
                {
                    c = Convert.ToChar(Console.ReadLine());
                    validate = false;
                }
                catch
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
            c = char.ToUpper(c);
            return c;
        }
        public static void writeJson()
        {

        }

    }
}
