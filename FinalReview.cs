using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Menu;

namespace Review
{
    class Review2
    {
        // ================================= Variables ======================================
        public class Review
        {
            public string Name;
            public string LastName;
            public int Stars;
            public string PhoneNumber;
            public string Mail;
            public string[] Comments;
            static List<Review> Objects = new List<Review>();

            public Review(string name, string lastname, int Stars, string PhoneNumber, string Mail, string[] comments)
            {
                this.Name = name;
                this.LastName = lastname;
                this.Comments = comments;
                this.Stars = Stars;
                this.PhoneNumber = PhoneNumber;
                this.Mail = Mail;
            }
            // ================================= Confirmation ======================================
            public void confirmation()
            {

                Console.WriteLine("Your comment:\n");
                for (int i = 0; i < Comments.Length; i++)
                {
                    Console.WriteLine(this.Comments[i]);
                }
                Console.WriteLine("\nHas been added to the comments");


            }
            // ============================== Display the comments ======================================
            public void DisplayComments()
            {
                string line = new String('-', (100));
                Console.WriteLine(line);
                Console.WriteLine(this.Name + " " + this.LastName + "\n");
                Console.WriteLine(this.PhoneNumber + " " + this.Mail + "\n");
                Console.WriteLine(this.Stars);
                for (int i = 0; i < Comments.Length; i++)
                {
                    Console.WriteLine(Comments[i]);
                }
                Console.WriteLine();
            }


            // ================================= Add Comment ======================================
            public static void WriteComment()
            {
                string name, Lastname, comment, Mail, PhoneNumber;
                int Stars;
                int i, count;
                string[] addComment = new string[40];

                //=====================Enter name, Lastname, Phone number, Mail and comment=========================
                Console.WriteLine("Please enter your name:");
                name = Menu.Program.Dishes.validateString();


                Console.WriteLine("Please enter your lastname:");
                Lastname = Menu.Program.Dishes.validateString();

                Console.WriteLine("On a scale of 1 to 5, how do you rate your experience?");
                Stars = 0;
                bool checker = true;
                while (checker)
                {
                    try
                    {
                        Stars = Convert.ToInt32(Console.ReadLine());
                        if (Stars > 0 && Stars < 4)
                        {
                            checker = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect value, please enter a number between 1-5.");

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect value.");
                    }
                }


                Console.WriteLine("Please enter your phone number: (Purely for us)");
                PhoneNumber = Menu.Program.Dishes.checkInt();

                Console.WriteLine("Please enter your mail address: (Purely for us)");
                Mail = Menu.Program.Dishes.validateString();

                Console.WriteLine("Add your comment below:");
                for (i = 0, count = 0; (comment = Console.ReadLine()) != "" && i < addComment.Length; i++)
                {
                    addComment[i] = comment;
                    count++;
                }

                //================Remove null values from Array. Maybe try this with a list?===========================
                string[] newArrComments = new string[count];
                for (i = 0; i < count; i++)
                {
                    newArrComments[i] = addComment[i];
                }

                Review newComment = new Review(name, Lastname, Stars, PhoneNumber, Mail, newArrComments);
                Objects.Add(newComment);
                newComment.confirmation();

            }

            static void Main(string[] args)
            {
                char[] charArray = new char[] { '1', '2', '3' };
                Console.WriteLine("Do you want to leave a commment or see the comment section?" +
                    "Press [1] to leave a comment, [2] to see the comments or [3] for no."); bool check = true;
                char answer = 'E';
                while (check)
                {
                    try
                    {
                        answer = Convert.ToChar(Console.ReadLine());
                        answer = char.ToUpper(answer);
                    }
                    catch
                    {
                        Console.WriteLine("That's not a character, please enter one of the characters defined above to proceed in the program.");
                    }
                    for (int i = 0; i < charArray.Length; i++)
                    {
                        if (answer == charArray[i])
                        {
                            check = false;
                        }
                    }
                    if (check == true)
                    {
                        Console.WriteLine("{0} isn't a valid character, please enter one of the characters defined above to proceed in the program.", answer);
                    }
                }

                if (answer == '1')
                {
                    WriteComment();
                    Main(null);
                }
                else if (answer == '2')
                {
                    foreach (Review comments in Objects)
                    {
                        comments.DisplayComments();
                    }
                }
                else
                {
                    return;
                }

            }
        }
    }
}
