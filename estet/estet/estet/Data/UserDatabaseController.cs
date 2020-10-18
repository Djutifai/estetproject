using estet.Classes;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace estet.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        private SQLiteConnection database;

       
        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();

        }

        public User GetUser()
        {
            lock(locker)
            {
                if (database.Table<User>().Count() ==0)
                {
                    return null;
                    
                }
                else
                {
                    return database.Table<User>().First();
                }
                
            }
        }

        public void CreateAdmin()
        {
            database.Insert(new User("admin", "admin", "123") { _isDev = true });
        }

        public bool LoginValidate (string mail, string password)
        {
            var data = database.Table<User>();
            var d1 = data.Where(x => x.Mail == mail && x.Password == password).FirstOrDefault();

            if (d1 != null) 
            {
                return true;
            }
            else 
            return false;
        }

        public int SaveUser (User user)
        {
            lock (locker)
            {
                if (user.Id != 0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else { return database.Insert(user); }
            }
        }

        public string GetMail(User user)
        {
            return user.Mail;
        }

        public int DeleteUser (int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id); 
            }
        }

        
    }
}
