using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Data.SqlClient;

namespace HackMe.Net_Task2DB
{
    class DB_task
    {
        public static string data_db = "";

        public void connect_to_db(string database)
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
            string sql = "SELECT * FROM hashing";

            cmd = new SqlCommand(sql, connect);
            dtRead = cmd.ExecuteReader();

            data_db = data_db + dtRead.GetValue(0);

            dtRead.Close();
            cmd.Dispose();
            connect.Close();
        }
    }
}