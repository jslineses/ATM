using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseNumber56
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Input Number: ");
                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        NumberOne();
                        break;
                    case 2:
                        NumberTwo();
                        break;
                    case 3:
                        NumberThree();
                        break;
                    case 4:
                        NumberFour();
                        break;
                    case 5:
                        NumberFive();
                        break;
                }

                Console.Write("...");
                Console.ReadLine();
                Console.Clear();
            }
            while (true);
        }

        public static void NumberOne()
        {
            string name = "";
            List<string> listName = new List<string>();
            do
            {
                Console.Write("Eneter a Name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    listName.Add(name);
            } while (!string.IsNullOrWhiteSpace(name));

            Console.WriteLine();
            switch (listName.Count)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("{0} likes your post.", listName.First());
                    break;
                case 2:
                    Console.WriteLine("Friend {0} and {1} like your post.", listName.First(), listName.Last());
                    break;
                default:
                    Console.WriteLine("Friend {0}, {1} and {2} others like your post.", listName.First(), listName[1], listName.Count - 2);
                    break;
            }
        }

        public static void NumberTwo()
        {
            Console.Write("Please Enter your Name: ");
            var name = Console.ReadLine();
            var newName = "";

            for (int i = name.Length - 1; i >= 0; i--)
            {
                newName += name[i];
            }
            char[] charName = name.ToCharArray();
            Console.WriteLine("Reverse");
            Array.Reverse(charName);
            foreach (var item in charName)
            {
                newName += item;
            }

            Console.WriteLine(newName);
        }

        public static void NumberThree()
        {
            int[] listNumbers = new int[5];
            int i = 0;
            do
            {
                Console.Write("Enter number: ");
                var input = int.Parse(Console.ReadLine());

                if (listNumbers.Contains(input))
                    Console.WriteLine("Error! Please Retry");
                else
                {
                    listNumbers[i] = input;
                    i++;
                }
            } while (i < 5);

            Console.WriteLine("Sort");
            Array.Sort(listNumbers);
            foreach (var item in listNumbers)
            {
                Console.WriteLine(item);
            }

        }

        public static void NumberFour()
        {
            var input = "quit";
            List<int> listNumbers = new List<int>();
            Console.WriteLine("Type \'Quit\' to Exit");

            do
            {
                List<int> listUniqueNumbers = new List<int>();
                int inputNumber;
                Console.Write("Enter a number: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out inputNumber))
                {
                    inputNumber = int.Parse(input);
                    listNumbers.Add(inputNumber);

                    bool isDuplicate = false;
                    for (int i = 0; i < listNumbers.Count; i++)
                    {
                        for (int j = 0; j < listNumbers.Count; j++)
                        {
                            if (j != i)
                            {
                                if (listNumbers[i] == listNumbers[j])
                                {
                                    isDuplicate = true;
                                }
                            }
                        }

                        if (!isDuplicate)
                        {
                            listUniqueNumbers.Add(listNumbers[i]);
                        }
                        isDuplicate = false;
                    }

                    Console.WriteLine("Unique Number/s:");
                    foreach (var item in listUniqueNumbers)
                    {
                        Console.WriteLine(item);
                    }
                }
            } while (input.ToLower() != "quit");
        }

        public static void NumberFive()
        {
            Console.Write("Please input a series of number seperated by comma (,): ");
            var input = Console.ReadLine();
            List<int> listNumbers = new List<int>();
            var splited = input.Split(',');
            foreach (var item in splited)
            {
                listNumbers.Add(int.Parse(item.Trim()));
            }


            if (listNumbers.Count == 0 && listNumbers.Count < 5)
            {
                Console.WriteLine("Invalid List, Please re-try!");
            }
            else
            {
                listNumbers.Sort();
                List<int> listSmallest = new List<int>();
                foreach (var item in listNumbers)
                {
                    if (!listSmallest.Contains(item))
                    {
                        if (listSmallest.Count != 3)
                            listSmallest.Add(item);
                    }
                }

                Console.WriteLine("Three Smallest numbers in the list: ");
                foreach (var item in listSmallest)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
