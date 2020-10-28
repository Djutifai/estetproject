using estet.Classes;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin;
using System.Linq;

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

        public User GetUser(int id) => database.Get<User>(id);
     /*   {
            return database.Get<User>(id); //Work with null exception
        } */

        public User GetUser(string mail)
        {
            var user = from s in database.Table<User>()
                       where s.Mail == mail
                       select s;
            return user.FirstOrDefault();
        }

        public void CreateAdmin()
        {
            User newadmin = new User("admin", "admin", "123",true);
            database.Insert(newadmin);
        }

       /* public bool CheckIfDev(int id)
        {
            if ()
                return false;
            else return true;
        }*/
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

        public List<User> GetAllUsers() => database.Table<User>().ToList();
        public int DeleteUser (int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id); 
            }
        }

        
    }
}
