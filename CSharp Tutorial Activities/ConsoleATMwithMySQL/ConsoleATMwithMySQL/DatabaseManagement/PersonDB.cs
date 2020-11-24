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
    class PersonDB : DatabaseLog
    {
        private string GenerateAccountNumber()
        {
            try
            {
                var accountNumber = 0;
                Random rand = new Random();
                var randomNumber = rand.Next(0, 999);

                Query = "Select id from tblperson where id like @ID order by id desc limit 1;";

                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", DateTime.Now.Year.ToString() + randomNumber.ToString("000") + "%");
                DataReader = Command.ExecuteReader();

                if (DataReader.Read())
                    accountNumber = int.Parse(DataReader.GetString(0).Substring(8));


                accountNumber++;

                DataReader.Close();
                Con.Close();

                return DateTime.Now.Year + randomNumber.ToString("000") + accountNumber.ToString("000");
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
        public string Insert(string lastname, string firstname, string middlename, string gender)
        {
            try
            {
                var accountNumber = GenerateAccountNumber();

                Query = "Insert into tblperson values(@ID, @lastname, @firstname, @middlename, @gender, 0, 1);";

                Con.Open();
                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", accountNumber);
                Command.Parameters.AddWithValue("@lastname", lastname);
                Command.Parameters.AddWithValue("@firstname", firstname);
                Command.Parameters.AddWithValue("@middlename", middlename);
                Command.Parameters.AddWithValue("@gender", gender);
                Command.ExecuteNonQuery();

                UpdateLog("Create", accountNumber);

                return accountNumber;

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
        public void Deposit(string accountnumber, double balance, double amount)
        {
            try
            {
                Query = "Update tblperson set balance = (balance + @amount) where id = @ID;";

                Con.Open();
                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", accountnumber);
                Command.Parameters.AddWithValue("@amount", amount);
                Command.ExecuteNonQuery();
                Con.Close();

                Transaction Transact = new Transaction("Deposit", balance, amount, accountnumber);
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
        public void Withdraw(string accountnumber,double balance, double amount)
        {
            try
            {
                Query = "Update tblperson set balance = balance - @amount where id = @ID;";

                Con.Open();
                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", accountnumber);
                Command.Parameters.AddWithValue("@amount", amount);
                Command.ExecuteNonQuery();
                Con.Close();

                Transaction Transact = new Transaction("withdraw", balance, amount, accountnumber);
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

        public bool CheckAccountNumber(string accountnumber)
        {
            try
            {
                var result = false;
                Query = "Select * from tblperson where id = @ID and isActive = 1;";

                Con.Open();
                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", accountnumber);
                DataReader = Command.ExecuteReader();
                DataReader.Read();

                if (DataReader.HasRows)
                {
                    result = true;

                    DataReader.Close();
                    Con.Close();
                }

                return result;
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
        public double CheckBalance(string accountnumber)
        {
            try
            {
                var result = 0.00;
                Query = "Select balance from tblperson where id = @ID;";

                Con.Open();
                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", accountnumber);
                DataReader = Command.ExecuteReader();
                DataReader.Read();

                if (DataReader.HasRows)
                {
                    result = DataReader.GetDouble(0);

                    DataReader.Close();
                    Con.Close();
                }

                return result;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        public void CheckUpdate(string accountnumber, Person person)
        {
            try
            {
                Query = "update tblperson set lastname = @lastname, firstname = @firstname, middlename = @middlename, gender = @gender where id = @ID;";

                Con.Open();
                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", accountnumber);
                Command.Parameters.AddWithValue("@lastname", person.LastName);
                Command.Parameters.AddWithValue("@firstname", person.FirstName);
                Command.Parameters.AddWithValue("@middlename", person.MiddleName);
                Command.Parameters.AddWithValue("@gender", person.Gender);
                Command.ExecuteNonQuery();
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
        public void CheckdDelete(string accountnumber)
        {
            try
            {
                Query = "update from tblperson set isActive = 0 where id = @ID;";

                Con.Open();
                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", accountnumber);
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

        public Person GetPersonData(string accountnumber)
        {
            Person newPerson = new Person();

            try
            {
                Query = "Select * from tblperson where id = @ID and isActive = 1;";

                Con.Open();
                Command = new MySqlCommand(Query, Con);
                Command.Parameters.AddWithValue("@ID", accountnumber);
                DataReader = Command.ExecuteReader();
                DataReader.Read();

                if (DataReader.HasRows)
                {
                    newPerson.LastName = DataReader.GetString(1);
                    newPerson.FirstName = DataReader.GetString(2);
                    newPerson.MiddleName = DataReader.GetString(3);
                    newPerson.Gender = DataReader.GetString(4);

                    DataReader.Close();
                    Con.Close();
                }
                return newPerson;
            }
            catch (MySqlException ex)
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
