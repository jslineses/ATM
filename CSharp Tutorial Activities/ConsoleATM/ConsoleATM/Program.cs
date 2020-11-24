using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
    class Program
    {
        enum Atm
        {
            Deposit,
            Withdraw
        }
        private static List<Person> ListPerson = new List<Person>();
        public static void CreatePerson()
        {
            Person newPerson;
            Console.WriteLine("Creating Account");
            Console.Write("Enter your Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Enter your First Name: ");
            var firstName = Console.ReadLine();
            var accountNumber = GenerateAccountNumber();

            newPerson = new Person(accountNumber, firstName.Trim(), lastName.Trim());
            ListPerson.Add(newPerson);
            StringBuilder builder = new StringBuilder();
            builder.Append('#', 6);
            builder.Append("Account Number: " + accountNumber);
            builder.Append('#', 6);
        }
        static void Main(string[] args)
        {
            Person user;
            bool loop = true;
            bool isAccountValid = false;

            Console.WriteLine("Welcome to Simple ATM");
            while (loop)
            {
                try
                {

                    Console.WriteLine(@"Inforfamation
[1] Create Account
{2] View Account
[3] Make Transaction
[4] Exit");
                    Console.Write("Choose Menu: ");
                    int menuChoice = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    int userAccountNumber = 0;
                    isAccountValid = false;
                    switch (menuChoice)
                    {
                        case 1:
                            Console.WriteLine("==== Create Account ====");
                            CreatePerson();
                            break;
                        case 2:
                            Console.WriteLine("==== View Account ====");
                            Console.Write("Enter Account Number: ");
                            userAccountNumber = int.Parse(Console.ReadLine());
                            user = new Person();

                            foreach (var item in ListPerson)
                            {
                                if (item.GetAccountNumber() == userAccountNumber)
                                {
                                    user = item;
                                    isAccountValid = true;
                                    break;
                                }
                            }

                            if (isAccountValid)
                                AtmViewAccount(user);
                            else
                            {
                                Console.WriteLine("Invalid Account Number!");
                                Console.WriteLine();
                            }
                            break;
                        case 3:
                            Console.WriteLine("==== Make Transaction ====");
                            Console.Write("Enter Account Number: ");
                            userAccountNumber = int.Parse(Console.ReadLine());
                            user = new Person();

                            foreach (var item in ListPerson)
                            {
                                if (item.GetAccountNumber() == userAccountNumber)
                                {
                                    user = item;
                                    isAccountValid = true;
                                    break;
                                }
                            }

                            if (isAccountValid)
                                AtmTransaction(user);
                            else
                            {
                                Console.WriteLine("Invalid Account Number!");
                                Console.WriteLine();
                            }
                            break;
                        case 4:
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice!");
                            Console.WriteLine();
                            Console.ReadLine();
                            break;
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine("Error!\n{0}", e.Message);
                }
            }
        }

        public static int GenerateAccountNumber()
        {
            bool isDuplicateAccountNumber = false;
            var accountNumber = 0;
            Random rand = new Random();
            accountNumber = rand.Next(0, 100);
            if (ListPerson.Count > 0)
            {
                while (!isDuplicateAccountNumber)
                {
                    accountNumber = rand.Next(0, 100);
                    foreach (var item in ListPerson)
                    {
                        if (item.GetAccountNumber() == accountNumber)
                            isDuplicateAccountNumber = true;
                    }
                }
            }

            return accountNumber;
        }

        public static void AtmTransaction(Person user)
        {
            bool loop = true;
            Transaction transact = new Transaction();
            var builder = new StringBuilder();
            builder.AppendLine();
            builder.Append('=', 6);
            builder.Append("Make Transaction");
            builder.Append('#', 6);
            builder.Append("Account Number: " + user.GetAccountNumber());
            builder.AppendLine();
            builder.Append('#', 6);
            builder.AppendLine();

            while (loop)
            {
                Console.WriteLine(@"ATM
[1] Deposit
{2] Withdaw
[3] History
[4] Back");
                Console.Write("Choose Transaction: ");
                int transChoice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                double amount;

                switch (transChoice)
                {
                    case 1:
                        Console.WriteLine("==== Deposit ====");
                        Console.Write("Enter amount: ");
                        amount = double.Parse(Console.ReadLine());
                        Console.WriteLine();

                        user.Deposit(amount);
                        break;
                    case 2:
                        Console.WriteLine("==== Withdraw ====");
                        Console.Write("Enter amount: ");
                        amount = double.Parse(Console.ReadLine());
                        Console.WriteLine();

                        user.Withdraw(amount);
                        break;
                    case 3:
                        Console.WriteLine("==== History ====");
                        Console.WriteLine();
                        user.DisplayHistory();
                        Console.WriteLine();
                        Console.ReadLine();
                        break;
                    case 4:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void AtmViewAccount(Person user)
        {
            Transaction transact = new Transaction();
            var builder = new StringBuilder();
            builder.AppendLine();
            builder.Append('=', 6);
            builder.Append("View Account");
            builder.Append('#', 6);
            builder.Append("Account Number: " + user.GetAccountNumber());
            builder.AppendLine();
            builder.Append('#', 6);
            builder.AppendLine();

            user.DisplayProfile();
            Console.WriteLine();

            Console.WriteLine(@"Action
[1] Edit
[2] Remove
[3] Back");

            Console.WriteLine("Account Information");
            Console.Write("Choose Menu: ");
            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    AtmEditAccount(user);
                    break;
                case 2:
                    if (user.ForDeletion())
                    {
                        ListPerson.Remove(user);
                        Console.WriteLine("Account Deleted!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Unavailable to Delete, Please withdraw all balance first!");

                        Console.WriteLine();
                    }
                    break;
            }
        }

        public static void AtmEditAccount(Person user)
        {
            Person editedPerson = new Person();
            var builder = new StringBuilder();
            builder.AppendLine();
            builder.Append('=', 6);
            builder.Append("Edit Account");
            builder.Append('#', 6);
            builder.Append("Account Number: " + user.GetAccountNumber());
            builder.AppendLine();
            builder.Append('#', 6);
            builder.AppendLine();

            user.DisplayProfile();
            Console.WriteLine(@"
[1] Last Name
[2] First Name");
            Console.Write("Choose to edit: ");
            var choice = int.Parse(Console.ReadLine());
            Console.Write("What to replace: ");
            var inputValue = Console.ReadLine();

            if (choice == 1)
            {
                for (int i = 0; i < ListPerson.Count; i++)
                {
                    if (ListPerson[i].GetAccountNumber() == user.GetAccountNumber())
                    {
                        ListPerson[i].EditProfile(inputValue.Trim(), "");
                        editedPerson = ListPerson[i];
                    }
                }
            }
            else if(choice== 2)
            {
                for (int i = 0; i < ListPerson.Count; i++)
                {
                    if (ListPerson[i].GetAccountNumber() == user.GetAccountNumber())
                    {
                        ListPerson[i].EditProfile("", inputValue.Trim());
                        editedPerson = ListPerson[i];
                    }
                }
            }

            AtmViewAccount(editedPerson);
        }
    }
}
