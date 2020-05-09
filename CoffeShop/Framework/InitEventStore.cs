using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Framework
{
    class InitEventStore
    {
        static void InitialiseEventStore()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Connections.GetSqlDbConnection());
                SqlCommand cmd = new SqlCommand(@"CREATE TABLE [dbo].[EventStore](
                                                [Id][uniqueidentifier] NOT NULL,
                                                [CreatedAt][datetime2] NOT NULL,
                                                [Sequence][int] IDENTITY(1, 1) NOT NULL,
                                                [Version][int] NOT NULL,
                                                [EventName][nvarchar](250) NOT NULL,
                                                [AggregateId][nvarchar](250) NOT NULL,
                                                [MetaData][nvarchar](max) NOT NULL,
                                                [AggregateName][nvarchar](250) NOT NULL
                                                ) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully...");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
            }
            Console.ReadKey();
        }
    }
}
