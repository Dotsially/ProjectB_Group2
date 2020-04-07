using System;

namespace Star_Review
{
    public class StarReview
    {
        public int Stars;

        public StarReview()
        {
            this.Stars = Console.Read();
        }
    }

    public class PersInfo
    {
        public string Name;
        public string Mail;
        public int PhoneNumber;

        public PersInfo()
        {
            this.Name = Convert.ToString(Console.Read());
            this.Mail = Convert.ToString(Console.Read());
            this.PhoneNumber = Console.Read();
        }
    }

    public class Review
    {

    }


}
