using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
    class Transaction
    {
        private string DateLog { get; set; }
        private bool IsDeposit { get; set; }
        private double Balance { get; set; }
        private double AmountTransact { get; set; }


        public string GetDateLog() { return DateLog; }
        public bool GetIsDeposit() { return IsDeposit; }
        public double GetBalance() { return Balance; }
        public double GetAmountTransact() { return AmountTransact; }

        public void MakeTransaction(bool isDeposit, double amount, double balance)
        {
            IsDeposit = isDeposit;
            if (isDeposit)
            {
                DateLog = DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString();
                Balance += AmountTransact = amount;

                Console.WriteLine("You Deposit: {0}\nBalance: {1}", amount, balance);
            }
            else
            {
                DateLog = DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString();
                AmountTransact = amount;
                Balance = balance;

                Console.WriteLine("You Withdraw: {0}\nBalance: {1}", amount, balance);
            }
        }

    }
}
