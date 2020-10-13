using System;
using System.Collections.Generic;
using System.Text;

namespace estet.Classes
{
    public class User
    {
        public string Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public User() { }

        public User(string Password, string PhoneNumber, string Mail)
        {
            this.Mail = Mail;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            
        }

        public bool CheckLogInfo()
        {
            if (!Mail.Equals("") || !Password.Equals(""))
                return true;
            else
                return false;
        }

        public bool CheckRegInfo()
        {
            if (!Mail.Equals("") || !Password.Equals("")||PhoneNumber.Equals(""))
                return true;
            else
                return false;

        }
    }
}
