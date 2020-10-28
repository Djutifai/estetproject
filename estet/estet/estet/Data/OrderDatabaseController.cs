using estet.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace estet.Data
{
    public class OrderDatabaseController
    {
        static object locker = new object();
        private SQLiteConnection database;

        public OrderDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Order>();
        }

        public Order GetOrder(int id)
        {
            var user = from s in database.Table<Order>()
                       where s.OrderId == id
                       select s;
            return user.FirstOrDefault();
        }

        public void SaveOrder(Order order)
        {
            lock (locker)
            {
                database.Insert(order);
            }
        }
    }
}
