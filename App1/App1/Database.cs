using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class Database
    {
        private SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateIndexAsync<UserResult>().Wait();
        }

    }
}
