using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using estet.Data;
using estet.iOS.Data;
using Xamarin.Forms;
using Foundation;
using UIKit;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace estet.iOS.Data
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "Db.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}