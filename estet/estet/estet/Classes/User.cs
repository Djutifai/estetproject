using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace estet.Classes
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("MAIL")]
        public string Mail { get; set; }
        [MaxLength(12)]
        [JsonProperty("PASSWORD")]
        public string Password { get; set; }
        [MaxLength(11)]
        [JsonProperty("PHONENUMBER")]
        public string PhoneNumber { get; set; }

        internal bool _isDev = false;

        public User() { }

        public User(string Mail, string Password, string PhoneNumber)
        {
            this.Mail = Mail;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            
        }

       
    }
}
