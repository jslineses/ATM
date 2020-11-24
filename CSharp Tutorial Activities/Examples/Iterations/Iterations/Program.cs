using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterations
{
    class Program
    {
        static void Main(string[] args)
        {
            FourthIteration();
        }

        public static void FirstIteration()
        {
            for (var i = 0; i <= 10; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine(i);
            }

            for (int i = 10; i >= 1; i--)
            {
                if (i % 2 == 0)
                    Console.WriteLine(i);
            }
        }

        public static void SecondIteration()
        {
            var name = "George Naismith";

            //for (int i = 0; i < name.Length; i++)
            //{
            //    Console.WriteLine(name[i]);
            //}

            foreach (var character in name)
            {
                Console.WriteLine(character);
            }
        }

        public static void ThirdIteration()
        {
            var numbers = new int[] { 5, 4, 3, 2, 1 };

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        public static void FourthIteration()
        {
            while (true)
            {
                Console.Write("Please type a name: ");
                var value = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine(value);
                    continue;
                }

                break;
            }
        }
    }
}
