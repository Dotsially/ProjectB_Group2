using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using static ProjectB_Group2.Filemanager;
using Newtonsoft.Json;


namespace ProjectB_Group2
{
    class LoginClass
    { 
        //field
        static int n;
        static string c;
        static string jsonString;
        static bool signupcheck = false;
        static bool loginrun = true;
        static bool numbercheckbool = true;
   
        static Dictionary<string, string> accounts = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonpathread("accounts.json"));
        static bool accountcheck(string x, string y)
        {
            if (accounts.ContainsKey(x) && accounts[x].Equals(y))
            {
                return true;
            }
            return false;

        }

        //Main function
        public static void LoginMethod()
        {

            while (loginrun)
            {
                Console.WriteLine("Please login to proceed. \nDon't have an account? Sign up now!");
                Colorful.Console.WriteLine("[1]Login [2]Sign up", Color.Yellow);
                c = Console.ReadLine();
                Console.WriteLine("");
                Numbercheck(c, n);
                while (numbercheckbool)
                {
                    c = Console.ReadLine();
                    Numbercheck(c, n);
                }
                jsonString = JsonConvert.SerializeObject(accounts);

            }
            File.WriteAllText(jsonpathwrite("accounts.json"), jsonString);
        }

        //Sign up function.
        public static void SignUpMethod()
        {
            while (signupcheck)
            {
                Console.WriteLine("Welcome to the Signup screen. Please make an account to continue.");
                Console.Write("Username: ");
                string a = Console.ReadLine();
                Console.Write("Password: ");
                string b = Console.ReadLine();
                
                if (accounts.ContainsKey(a))
                {
                    Colorful.Console.WriteLine("That username is already in use.", Color.Red);
                }
                else
                {
                    accounts.Add(a, b); 
                    signupcheck = false;
                }
                Console.WriteLine("");
            }
            
        }

        //Login function
        public static void LoginFunction()
        {
            Console.WriteLine("Welcome to the Login screen. Please login to continue.");
            Console.Write("Username: ");
            string a = Console.ReadLine();
            Console.Write("Password: ");
            string b = Console.ReadLine();
            if (accountcheck(a, b))
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome " + a + "!");
                loginrun = false;
            }
            else
            {
                Colorful.Console.WriteLine("That username and password combination doesn't exist. Please try again.", Color.Red);
            }
            Console.WriteLine("");

        }

        //Check to see if the user inputs the right number.
        public static void Numbercheck(string x, int z)
        {
            bool strconverter = int.TryParse(x, out z);
            if (strconverter)
            {  
                int.TryParse(x, out z);
                if (z == 1)
                {
                    numbercheckbool = false;
                    LoginClass.LoginFunction();
                }
                else if (z == 2)
                {
                    numbercheckbool = false;
                    signupcheck = true;
                    LoginClass.SignUpMethod();
                }
                else
                {
                    Colorful.Console.WriteLine("That's an invalid number", Color.Red);
                }
            }
        }
        
    }
}
