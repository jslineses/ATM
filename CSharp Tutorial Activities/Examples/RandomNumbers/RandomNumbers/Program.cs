using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SecondRandom();
        }

        public static void FirstRandom()
        {
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.Write((char)('a' + random.Next(0, 26)));
            }
            Console.WriteLine();
        }

        public static void SecondRandom()
        {
            var random = new Random();
            const int passwordLength = 10;
            var buffer = new char[passwordLength];

            for (int i = 0; i < passwordLength; i++)
            {
                buffer[i] = (char)('a' + random.Next(0, 26));
            }

            var password = new string(buffer);
            Console.WriteLine(password);
        }
    }
}
