using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HackMe.Net_Task2DB
{
    class DB_task
    {
        public static string data_db = "";

        public void connect_to_db(string database)
        {
            try
            {
                List<Thread> dbThreads = new();

                dbThreads.Add(new Thread(() =>
                {
                    string connectionPath;
                    SqlConnection connect;

                    var data_source = $@"{database}";
                    var database_name = "HackMe";
                    /*(
                    var user_name = "HackerBoi";
                    var password = "psswd";

                    connectionPath = @"Data Source=" + data_source + ";Initial Catalog=" + database_name +
                                     ";Persist Security Info=True;User ID=" + user_name + ";Password" + password;
                    */
                    connectionPath = @"Data Source=" + data_source + ";Initial Catalog=" + database_name +
                                     ";Integrated Security=True;MultipleActiveResultSets=True";
                    connect = new(connectionPath);
                    connect.Open();

                    SqlCommand cmd;
                    SqlDataReader dtRead;
                    string sql = "SELECT hashing FROM Check_this";

                    cmd = new SqlCommand(sql, connect);
                    dtRead = cmd.ExecuteReader();


                    if (dtRead.HasRows)
                    {
                        while (dtRead.Read())
                        {
                            Console.WriteLine(dtRead.GetString(0));
                        }
                    }
                    

                    dtRead.Close();
                    cmd.Dispose();
                    connect.Close();

                }));

                dbThreads.Add(new Thread(() =>
                {
                    Console.WriteLine("\n\"Help\" yourself.\n");
                }));

                dbThreads[0].Start();
                //dbThreads[1].Start();

                dbThreads[0].Join();
                //dbThreads[1].Join();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void help()
        {
            try
            {
                Console.WriteLine("List of available commands for current task:" +
                                  "\n\nshow_servers - list local servers that you own\n" +
                                  "connect - connect to database where next task is hidden\n" +
                                  "show_records - list records of database\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}