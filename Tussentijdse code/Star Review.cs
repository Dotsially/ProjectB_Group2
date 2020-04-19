using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
            public int PhoneNumber;
            public string Mail;
            public string[] Comments;
            static List<Review> Objects = new List<Review>();

            public Review(string name, string lastname, int Stars, int PhoneNumber, string Mail, string[] comments)
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
                string name, Lastname, comment, Mail;
                int Stars, PhoneNumber;
                int i, count;
                string[] addComment = new string[40];


                //=====================Enter name, Lastname, Phone number, Mail and comment=========================
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();

                Console.WriteLine("Please enter your lastname:");
                Lastname = Console.ReadLine();

                Console.WriteLine("On a scale of 1 to 5, how do you rate your experience?");
                Stars = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter your phone number: (Purely for us)");
                PhoneNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter your mail address: (Purely for us)");
                Mail = Console.ReadLine();

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

                //================= Add the comment with information to Objects List=======================================
                Review newComment = new Review(name, Lastname, Stars, PhoneNumber, Mail, newArrComments);
                Objects.Add(newComment);
                newComment.confirmation();

            }

            static void Main(string[] args)
            {


                char answer;
                Console.WriteLine("Do you want to leave a commment or see the comment section?" +
                    "Press [Y] to leave a comment, [S] to see the comments or [N] for no.");
                answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'Y' || answer == 'y')
                {
                    WriteComment();
                    Main(null);
                }
                else if (answer == 'S' || answer == 's')
                {
                    foreach (Review comments in Objects)
                    {
                        comments.DisplayComments();
                    }
                    Main(null);
                }
                else
                {
                    Environment.Exit(0);
                }

            }
        }
    }
}

