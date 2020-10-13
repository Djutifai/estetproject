using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace estet.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();

    }
}
