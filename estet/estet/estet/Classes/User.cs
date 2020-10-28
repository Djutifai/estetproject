using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xamarin.Forms;

namespace estet.Classes
{
    [Table ("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Unique, Column("ID")]
        [JsonProperty("ID")]
        public int Id { get; set; }
        [Column("mail"), Unique]
        [JsonProperty("MAIL")]
        public string Mail { get; set; }
        [MaxLength(12),Column("password")]
        [JsonProperty("PASSWORD")]
        public string Password { get; set; }
        [MaxLength(11),Column("phone")]
        [JsonProperty("PHONENUMBER")]
        public string PhoneNumber { get; set; }

        [MaxLength(1), Column("dev")]
        [JsonProperty("DEV?")]
        public bool IntIsDev { get; set; }

        public User()
        { }
        public User(string Mail, string Password, string PhoneNumber)
        {
            this.Mail = Mail;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            IntIsDev = false;
            
        }

        public User(string Mail, string Password, string PhoneNumber, bool _isDev)
        {
            this.Mail = Mail;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            IntIsDev = _isDev;

        }

    }
}
