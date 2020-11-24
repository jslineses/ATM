using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseNumber49
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
			var count = 0;
            for (int i = 1; i < 100; i++)
            {
				if (i % 3 == 0)
				{
					count++;
					Console.WriteLine(count + ", " + i);
				}
            }

            Console.WriteLine("There {0} numbers that are divisible by 3 between 1 and 100.", count);
		}
		public static void NumberTwo()
		{
			int sum = 0;
			while (true)
            {
				Console.Write("Enter a number: ");
				var input = Console.ReadLine();
				int converted = 0;

				if (int.TryParse(input, out converted))
					sum += converted;
				else
				{
					if (input.ToLower() == "ok")
						break;
				}

				Console.WriteLine("Sum is " + sum);
                Console.WriteLine();
            }
		}
		public static void NumberThree()
		{
            Console.Write("Enter a number: ");
			var input = int.Parse(Console.ReadLine());
			int factorial = 1;

            for (int i = input; i > 0; i--)
            {
				Console.Write(i + ((i-1!=0)?" X ":""));
				factorial *= i;
            }
            Console.WriteLine();
            Console.WriteLine(input + "! = " + factorial);
		}
		public static void NumberFour()
		{
			var random = new Random();
			var pickedNumber = random.Next(1,10);
			var @try = 0;
			bool isGuessed = false;

			while (@try < 4 && !isGuessed)
            {
                Console.Write("Please guess the number: ");
				var input = int.Parse(Console.ReadLine());

				if (input == pickedNumber)
				{
					isGuessed = true;
				}

				@try++;
            }

			Console.WriteLine();
			if (isGuessed)
                Console.WriteLine("You won");
			else
                Console.WriteLine("You lost");
		}
		public static void NumberFive()
		{
            Console.Write("Please input a series of number seperated by comma (,): ");
			var input = Console.ReadLine();
			var max = 0;

			var splited = input.Split(',');

			foreach (var item in splited)
            {
				int convertToint = int.Parse(item.Trim());
				if (convertToint > max)
					max = convertToint;
			}

			Console.WriteLine(max);
		}
	}
}