using estet.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace estet.Data
{
    class OrderDatabaseController
    {
        static object locker = new object();
        private SQLiteConnection database;

        public OrderDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Order>();
        }

      //  public Order GetOrder(string id) => database.Get<Order>
    }
}
