using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public static class Connections
    {
        private const string SqlDbConnectionString = "Data source=AZRA-PC\\SQLEXPRESS; Database=EventStore; User Id=sa; Password=sa123";

        public static string GetSqlDbConnection()
        {
            return SqlDbConnectionString;
        }
    }
}
