using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConsoleATMwithMySQL.DatabaseManagement
{
    class DatabaseLog : Global
    {
        public void UpdateLog(string type, string descid)
        {
            Query = "insert into tblaccountlog values(0, @type, @desc, Now());";

            if (Con.State == ConnectionState.Closed)
                Con.Open();

            Command = new MySqlCommand(Query, Con);
            Command.Parameters.AddWithValue("@type", type);
            Command.Parameters.AddWithValue("@desc", descid);
            Command.ExecuteNonQuery();
            Con.Close();
        }
    }

    class Transaction : DatabaseLog
    {
        public Transaction(string type, double balance, double amount, string tblperson_id)
        {
            var id = GenerateId();
            Query = "insert into tbltransaction values(@id, Now(), @type, @balance, @amount, @tblperson_id);";

            if (Con.State == ConnectionState.Closed)
                Con.Open();

            Command = new MySqlCommand(Query, Con);
            Command.Parameters.AddWithValue("@id", id);
            Command.Parameters.AddWithValue("@type", type);
            Command.Parameters.AddWithValue("@balance", balance);
            Command.Parameters.AddWithValue("@amount", amount);
            Command.Parameters.AddWithValue("@tblperson_id", tblperson_id);
            Command.ExecuteNonQuery();
            Con.Close();

            UpdateLog("Transact", id);
        }

        private string GenerateId()
        {
            try
            {
                var accountNumber = 0;
                Random rand = new Random();
                var randomNumber = rand.Next(0, 99);


                Query = "Select id from tbltransaction where id like @ID order by id desc limit 1;";
                Con.Open();
                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", "Trans" + randomNumber.ToString("00") + "%"); ;
                DataReader = Command.ExecuteReader();

                if (DataReader.Read())
                    accountNumber = int.Parse(DataReader.GetString(0).Substring(8));


                accountNumber++;
                DataReader.Close();
                Con.Close();
                return "Trans" + randomNumber.ToString("00") + accountNumber.ToString("000");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }
    }
}
