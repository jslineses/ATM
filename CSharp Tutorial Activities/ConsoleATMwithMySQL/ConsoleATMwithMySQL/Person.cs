using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleATMwithMySQL.DatabaseManagement;

namespace ConsoleATMwithMySQL
{
    class Person
    {
        private string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public double Balance { get; set; }

        private bool IsActive { get; set; }

        private PersonDB PersonDb;

        public Person() { PersonDb = new PersonDB(); }
        public Person(string accountnumber)
        {
            AccountNumber = accountnumber;
            PersonDb = new PersonDB();
        }

        public string CreatePerson(string firstName, string lastName, string middlename, string gender)
        {
            var accountNumber = "";

            try
            {
                accountNumber = PersonDb.Insert(firstName, lastName, middlename, gender);
                Console.WriteLine("Person is Registered!");
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return accountNumber;
        }

        public bool Isvalid() { return PersonDb.CheckAccountNumber(AccountNumber); }
        public void Log(bool isLogIn, string accountnumber)
        {
            PersonDb.UpdateLog(isLogIn ? "In" : "Out", accountnumber);
        }
        public double GetBalance() { return Balance = PersonDb.CheckBalance(AccountNumber); }

        public void ReadData()
        {
            Person newPerson = new Person();
            newPerson = PersonDb.GetPersonData(AccountNumber);

            LastName = newPerson.LastName;
            FirstName = newPerson.FirstName;
            MiddleName = newPerson.MiddleName;
            Gender = newPerson.Gender;
        }

        // ==============================================
        public void Deposit(double amount)
        {
            PersonDb.Deposit(AccountNumber, Balance, amount);
            Console.WriteLine("Amount Deposit!");
            Console.ReadLine();
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("Balance", "Insufisient balance!");
            }
            else if (amount == 0)
            {
                throw new ArgumentOutOfRangeException("Amount to Wuthdraw", "Nothing to withdraw!");
            }
            else
            {
                PersonDb.Withdraw(AccountNumber, Balance, amount);
                Console.WriteLine("Amount Deposit!");
                Console.ReadLine();
            }
        }

        public void DisplayHistory()
        {

        }

        public void DisplayProfile()
        {
            ReadData();
            Console.WriteLine("Information\nName: {0}, {1}\nBalance: Php{2}", LastName, FirstName, Balance);

        }

        public void EditProfile()
        {
            PersonDb.CheckUpdate(this.AccountNumber, this);
            Console.WriteLine("Profile Edited!");
            Console.ReadLine();
        }
        public void DeleteProfile()
        {
            PersonDb.CheckdDelete(this.AccountNumber);
            Console.WriteLine("Profile Deleted!");
            Console.ReadLine();
        }
    }
}
