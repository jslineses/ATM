using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
    class Person
    {
        private int AccountNumber { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private double Balance { get; set; }
        private List<Transaction> TransactionHistory { get; set; }
        private Transaction Transac { get; set; }

        public int GetAccountNumber()
        {
            return AccountNumber;
        }
        public bool ForDeletion()
        {
            var result = false;

            if (Balance <= 0)
                result = true;

            return result;
        }
        public Person()
        {

        }
        public Person(int accountNumber, string firstName, string lastName)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
            Balance = 0;
            Transac = new Transaction();
            TransactionHistory = new List<Transaction>();
        }

        public void Deposit(double amount)
        {
            Transac = new Transaction();
            Balance += amount;
            Transac.MakeTransaction(true, amount, Balance);
            TransactionHistory.Add(Transac);
        }

        public void Withdraw(double amount)
        {
            double transAmount = Balance - amount;

            if(amount == 0)
            {
                throw new ArgumentOutOfRangeException("Amount to Wuthdraw","Nothing to withdraw.");
            }
            else if (transAmount >= 0)
            {
                Transac = new Transaction();
                Balance = transAmount;
                Transac.MakeTransaction(false, amount, Balance);
                TransactionHistory.Add(Transac);
            }
            else if(amount > Balance)
            {
                throw new ArgumentOutOfRangeException("Balance","Amount to withdraw is greater than your remaing balance.");
 
            }
        }

        public void DisplayHistory()
        {
            foreach (var item in TransactionHistory)
            {
                Console.WriteLine(string.Format("\nDate: {0}\n{1}\nAmount: Php{2}\nBalance: {3}\n===", item.GetDateLog(), (item.GetIsDeposit()?"Deposit":"Withdraw"),item.GetAmountTransact(), item.GetBalance()));
            }

            Console.WriteLine();

        }

        public void DisplayProfile()
        {
            Console.WriteLine("Information\nName: {0}, {1}\nBalance: Php{2}", LastName, FirstName, Balance);
        }

        public void EditProfile(string lastName, string firstName)
        {
            if (!string.IsNullOrWhiteSpace(lastName))
                LastName = lastName;
            if (!string.IsNullOrWhiteSpace(firstName))
                FirstName = firstName;

            Console.WriteLine("Profile Edited!");
        }
    }
}
