using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class Global
    {
        public MySqlConnection Con;
        public MySqlCommand Command;
        public MySqlDataReader DataReader;
        public MySqlDataAdapter DataAdapter;
        public DataTable DataTable;
        public string Query;

        public Global()
        {
            Con = new MySqlConnection();
            Con.ConnectionString = "server=localhost;database=atmdb;uid=root;password=password;";

            try
            {

                Con.Open();

                if (Con.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connecting to database...");
                Con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
