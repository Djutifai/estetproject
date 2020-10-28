using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace estet.Classes
{
    public class Order
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
        /// <summary>
        /// Order status. 0 - Ordered
        /// 1 - In work
        /// 2 - Checking
        /// 3 - Done
        /// </summary>
        [MaxLength (1)]
        public byte Status { get; set; }

        public Order() { }


    }
}
