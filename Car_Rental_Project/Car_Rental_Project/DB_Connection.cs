using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Car_Rental_Project
{
    public interface DB_Connection
    {
        SQLiteConnection GetConnection();
    }
}
