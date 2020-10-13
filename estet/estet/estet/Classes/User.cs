using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace estet.Classes
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public User() { }
        
        public User(string Mail, string Password)
        {
            this.Mail = Mail;
            this.Password = Password;

        }

        public User(string Mail, string Password, string PhoneNumber)
        {
            this.Mail = Mail;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            
        }

        public bool CheckIfEmpty()
        {
            if (!Mail.Equals("") || !Password.Equals(""))
                return false;
            else
                return true;
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
