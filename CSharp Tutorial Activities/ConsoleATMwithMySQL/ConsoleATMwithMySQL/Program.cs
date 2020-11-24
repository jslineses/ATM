using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ConsoleATMwithMySQL.DatabaseManagement;

namespace ConsoleATMwithMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = true;
            while (result)
            {
                result = Menu();
            }
        }

        private static bool Menu()
        {
            var value = true;
            string accountnumber;

            Console.Clear();
            Console.WriteLine("\tWelcome to ATM");
            Console.WriteLine(@"
[1] Register
[2] Log In
[3] Exit");
            Console.Write("Choose in MENU: ");
            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int result))
            {
                result = int.Parse(choice);

                switch (result)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        Console.Write("Enter your Account Number: ");
                        accountnumber = Console.ReadLine();
                        LogIn(accountnumber);
                        break;
                    case 3:
                        value = false;
                        break;
                    default:
                        Console.Write("Invalid Choice!  ");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.Write("Invalid Choice!  ");
                Console.ReadLine();
            }

            return value;
        }
        private static void CreateAccount()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\tWelcome to ATM");
                Console.WriteLine("=== Create Account ===");
                Console.Write("Enter your Lastname: ");
                var lastname = Console.ReadLine();
                var splited = lastname.ToLower().Trim().Split(' ');
                lastname = "";
                foreach (var item in splited)
                {
                    lastname += item[0].ToString().ToUpper() + ((item.Length > 1) ? item.Substring(1) : "") + " ";
                }
                lastname.Trim();

                Console.Write("Enter your Firstname: ");
                var firstname = Console.ReadLine();
                splited = firstname.ToLower().Trim().Split(' ');
                firstname = "";
                foreach (var item in splited)
                {
                    firstname += item[0].ToString().ToUpper() + ((item.Length > 1) ? item.Substring(1) : "") + " ";
                }
                firstname.Trim();

                Console.Write("Enter your Middlename (Optional): ");
                var middlename = Console.ReadLine();
                splited = middlename.ToLower().Trim().Split(' ');
                middlename = "";
                foreach (var item in splited)
                {
                    middlename += item[0].ToString().ToUpper() + ((item.Length > 1) ? item.Substring(1) : "") + " ";
                }
                middlename.Trim();

                if (middlename.Length > 0)
                {
                    splited = middlename.ToLower().Trim().Split(' ');
                    middlename = "";
                    foreach (var item in splited)
                    {
                        middlename += item[0].ToString().ToUpper() + ((item.Length > 1) ? item.Substring(1) : "") + " ";
                    }
                }

                var gender = "";

                do
                {
                    Console.Write("Enter your Gender (Male/Female): ");
                    gender = Console.ReadLine();

                    if (gender.ToLower() == "male" || gender.ToLower() == "female")
                        break;
                    else
                    {
                        Console.WriteLine("Unable to identify gender!");
                        Console.WriteLine();
                    }
                } while (true);

                Person newPerson = new Person();
                Console.Clear();
                Console.WriteLine("Account Number: " + newPerson.CreatePerson(lastname, firstname, middlename, gender));
                Console.WriteLine("Due to lack of resources, please remember or take note your Accountnumer!");

                Console.Write("Press Enter...");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Enter...");
                Console.ReadLine();
            }
        }

        private static void LogIn(string accountnumber)
        {
            Person newPerson = new Person(accountnumber);
            try
            {
                bool loop = false;
                do
                {
                    bool isValid = newPerson.Isvalid();

                    if (isValid)
                    {
                        var balance = newPerson.GetBalance();
                        newPerson.Log(true, accountnumber);

                        loop = false;
                        Console.Clear();
                        Console.WriteLine("\tWelcome to ATM");
                        Console.WriteLine("=== Account ===");
                        Console.WriteLine(string.Format("*******{0:00}", accountnumber.Substring(8)));
                        Console.WriteLine(@"
Balance: Php{0:0.00}

[1] Deposit
[2] Withdraw
[3] View Profile
[4] Back", balance);
                        Console.Write("Choose in MENU: ");
                        var choice = Console.ReadLine();


                        if (int.TryParse(choice, out int result))
                        {
                            result = int.Parse(choice);
                            double amount;

                            switch (result)
                            {
                                case 1:
                                    while (true)
                                    {
                                        Console.Write("Enter Amount to deposit: ");
                                        var input = Console.ReadLine();
                                        if (IsAmountValid(input))
                                        {
                                            amount = double.Parse(input);
                                            newPerson.Deposit(amount);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Amount!");
                                        }
                                    }
                                    break;
                                case 2:
                                    while (true)
                                    {
                                        Console.Write("Enter Amount to Withdraw: ");
                                        var input = Console.ReadLine();
                                        if (IsAmountValid(input))
                                        {
                                            amount = double.Parse(input);
                                            newPerson.Withdraw(amount);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Amount!");
                                        }
                                    }
                                    break;

                                case 3:
                                    ViewProfile(newPerson, accountnumber);
                                    break;
                                case 4:
                                    loop = false;
                                    break;
                                default:
                                    Console.Write("Invalid Choice!  ");
                                    loop = true;
                                    break;
                            }
                        }
                        else
                        {
                            Console.Write("Invalid Choice!  ");
                            loop = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Account Number!");
                    }
                } while (loop);
                Console.Write("Press Enter...");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Enter...");
                Console.ReadLine();
            }
            finally
            {
                newPerson.Log(false, accountnumber);
            }

        }
        public static void ViewProfile(Person newPerson, string accountnumber)
        {
            try
            {
                bool loop = false;
                do
                {
                    bool isValid = newPerson.Isvalid();

                    if (isValid)
                    {
                        loop = false;

                        var balance = newPerson.GetBalance();
                        Console.Clear();
                        Console.WriteLine("\tWelcome to ATM");
                        Console.WriteLine("=== Profile ===");
                        Console.WriteLine(string.Format("*******{0:00}", accountnumber.Substring(8)));
                        newPerson.DisplayProfile();
                        Console.WriteLine(@"
[1] Edit
[2] Remove
[3] Back");
                        Console.Write("Choose in MENU: ");
                        var choice = Console.ReadLine();



                        if (int.TryParse(choice, out int result))
                        {
                            result = int.Parse(choice);
                            loop = true;

                            switch (result)
                            {
                                case 1:
                                    while (loop)
                                    {
                                        Console.WriteLine(@"
[1] Last Name
[2] First Name
[3] Middle Name
[4] Gender
[5] Done");
                                        Console.Write("Choose to edit: ");
                                        var choiceMenu2 = Console.ReadLine();
                                        if (int.TryParse(choiceMenu2, out int result1))
                                        {
                                            var input = "";
                                            result1 = int.Parse(choiceMenu2);
                                            if (result1 > 0 && result < 5)
                                            {
                                                Console.Write("Enter new value: ");
                                                input = Console.ReadLine();
                                                var splited = input.ToLower().Trim().Split(' ');
                                                input = "";
                                                foreach (var item in splited)
                                                {
                                                    input += item[0].ToString().ToUpper() + ((item.Length>1)?item.Substring(1):"") + " ";
                                                }
                                                input.Trim();
                                            }

                                            switch (result1)
                                            {
                                                case 1:
                                                    newPerson.LastName = input;
                                                    break;
                                                case 2:
                                                    newPerson.FirstName = input;
                                                    break;
                                                case 3:
                                                    newPerson.MiddleName = input;
                                                    break;
                                                case 4:
                                                    newPerson.Gender = input;
                                                    break;
                                                default:
                                                    loop = false;
                                                    break;
                                            }
                                            newPerson.EditProfile();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid choice!");
                                            loop = true;
                                        }
                                    }
                                    break;
                                case 2:
                                    newPerson.DeleteProfile();
                                    break;
                                case 3:
                                    loop = false;
                                    break;
                                default:
                                    Console.Write("Invalid Choice!  ");
                                    loop = true;
                                    break;
                            }
                        }
                        else
                        {
                            Console.Write("Invalid Choice!  ");
                            loop = true;
                        }
                    }
                } while (loop);
                Console.Write("Press Enter...");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Enter...");
                Console.ReadLine();
            }
            finally
            {

            }
        }

        public static bool IsAmountValid(string amount)
        {
            if (double.TryParse(amount, out double result))
                return true;

            return false;
        }
    }
}
