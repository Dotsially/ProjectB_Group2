using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB_Group2
{
    class LoginClass
    {
        static bool signupcheck = false;
        static bool loginrun = true;
        static IDictionary<string, string> accounts = new Dictionary<string, string>();
        public static void LoginMethod()
        {
            while (loginrun)
            {
                Console.WriteLine("Please login to proceed. \nDon't have an account? Sign up now!");
                
            
            }       

        }
        public static void SignUpMethod()
        {
            while (signupcheck)
            {
                Console.Write("Username: ");
                string a = Console.ReadLine();
                Console.Write("Password: ");
                string b = Console.ReadLine();

                if (accounts.ContainsKey(a))
                {
                    Console.WriteLine("That username is already in use.");
                }
                else
                {
                    accounts.Add(a, b);
                    signupcheck = false;
                }
            }
            
        }
    }
}
