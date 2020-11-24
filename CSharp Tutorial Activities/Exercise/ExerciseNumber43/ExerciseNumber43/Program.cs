using System;

namespace Exercise43
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
				}

				Console.Write("...");
				Console.ReadLine();
			}
			while (true);
		}

		public static void NumberOne()
		{
			Console.Write("Please Input a number between 1 and 10: ");
			var inputNumber = int.Parse(Console.ReadLine());

			Console.WriteLine((inputNumber >= 0 && inputNumber <= 10) ? "Valid" : "Invalid");
		}

		public static void NumberTwo()
		{
			Console.Write("Please Input a number: ");
			var firstNumber = int.Parse(Console.ReadLine());
			Console.Write("Please Input another number: ");
			var secondNumber = int.Parse(Console.ReadLine());
			var result = (firstNumber > secondNumber) ? firstNumber : secondNumber;

			Console.WriteLine("The Maximum is: " + result);
		}

		public static void NumberThree()
		{
			Console.Write("Please Input width of image: ");
			var width = int.Parse(Console.ReadLine());
			Console.Write("Please Input height of image: ");
			var height = int.Parse(Console.ReadLine());
			var result = (width > height) ? "Landscape" : "Portrait";

			Console.WriteLine("The Image is a " + result);
		}

		public static void NumberFour()
		{
			Console.Write("Please Input a speed limit (km/hr): ");
			var speedLimit = int.Parse(Console.ReadLine());
			Console.Write("Please Input the speed of a car (km/hr): ");
			var carSpeed = int.Parse(Console.ReadLine());

			if (speedLimit > carSpeed)
				Console.WriteLine("OK");
			else
			{
				var overflowValue = carSpeed - speedLimit;
				var demeritPoints = ((overflowValue < 5) ? 0 : overflowValue / 5);

				if (demeritPoints > 12)
					Console.WriteLine("License Suspended");
				else
					Console.WriteLine("Demerit Point/s:  " + demeritPoints);
			}

		}
	}
}









