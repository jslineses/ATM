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
    class Program

    {
        static void Main(string[] args)
        {

            Console.WriteLine(GenerateId());
        }
        private static string GenerateId()
        {
            Global g = new Global();
            var accountNumber = 0;
            Random rand = new Random();
            var randomNumber = rand.Next(0, 99);

            g.Query = "Select id from tbltransaction where id like @ID order by id desc limit 1;";
            g.Con.Open();
            g.Command = new MySqlCommand(g.Query, g.Con);
            g.Command.Parameters.AddWithValue("@ID", "Trans" + randomNumber.ToString("00") + "%"); ;
            g.DataReader = g.Command.ExecuteReader();

            if (g.DataReader.Read())
                accountNumber = int.Parse(g.DataReader.GetString(0).Substring(8));


            accountNumber++;
            g.DataReader.Close();
            g.Con.Close();
            return "Trans" + randomNumber.ToString("00") + accountNumber.ToString("000");
        }
    }
}
