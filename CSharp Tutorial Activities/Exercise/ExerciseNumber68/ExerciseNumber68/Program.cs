using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseNumber68
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
						break;
                }

				Console.Write("...");
				Console.ReadLine();
			}
			while (true);
		}
		public static void NumberOne()
		{
			var count = 0;
			var isIncrement = false;
			Console.Write("Enter a few numbers seperated by a hypen \'-\': ");
			var input = Console.ReadLine();
			var splited = input.Split('-');

			List<int> listNumbers = new List<int>();
			foreach (var item in splited)
			{
				listNumbers.Add(int.Parse(item.Trim()));
			}

			for (int i = 1; i < listNumbers.Count; i++)
			{
				if (listNumbers[i - 1] == listNumbers[i] - 1)
				{
					count++;
					isIncrement = false;
				}
				isIncrement = count == 0 ? true : false;
				if (listNumbers[i - 1] == listNumbers[i] + 1)
				{
					count++;
					isIncrement = true;
				}
				isIncrement = count == 0 ? false : true;
			}

			if (count + 1 == listNumbers.Count)
				Console.WriteLine("Consecutive");
			else
				Console.WriteLine("Not Consecutive");
		}

		public static void NumberTwo()
        {
			Console.Write("Enter a few numbers seperated by a hypen \'-\': ");
			var input = Console.ReadLine();

			if (!string.IsNullOrEmpty(input.Trim()))
			{
				var splited = input.Split('-');

				List<int> listInput = new List<int>();
				List<int> listDuplicate = new List<int>();
				foreach (var item in splited)
				{
					listInput.Add(int.Parse(item.Trim()));
				}

				bool isDuplicate = false;
				for (int i = 0; i < listInput.Count - 1; i++)
				{
					for (int j = i + 1; j < listInput.Count; j++)
					{
						if (j != i)
						{
							if (listInput[i] == listInput[j])
							{
								isDuplicate = true;
								break;
							}
						}
					}

					if (isDuplicate)
					{
						listDuplicate.Add(listInput[i]);
					}
					isDuplicate = false;
				}

				Console.WriteLine("Duplicate/s: ");
				foreach (var item in listDuplicate)
				{
					Console.WriteLine(item);
				}
			}
		}

		public static void NumberThree()
        {
			Console.Write("Enter a time value in the 24-hour format (e.g. 19:00): ");
			var input = Console.ReadLine();
			var splited = input.Split(':');
			int holder;
			int[] Hour = new int[2];
			bool[] isValid = new bool[2];

			if (int.TryParse(splited[0], out holder))
			{
				Hour[0] = int.Parse(splited[0]);
				if (Hour[0] >= 0 && Hour[0] < 23)
					isValid[0] = true;
			}
			if (int.TryParse(splited[1], out holder))
			{
				Hour[1] = int.Parse(splited[1]);
				if (Hour[1] >= 0 && Hour[1] < 60)
					isValid[1] = true;
			}

			if (isValid[0] && isValid[1])
				Console.WriteLine("Valid Time");
			else
				Console.WriteLine("Invalid Time");
		}

		public static void NumberFour()
		{
			Console.Write("Enter a few words seperated by a space: ");
			var input = Console.ReadLine();
			var splited = input.Split(' ');
			var newWord = "";

			foreach (var item in splited)
			{
				var temp = (item).ToLower();
				newWord += temp[0].ToString().ToUpper() + temp.Substring(1);
			}

			Console.WriteLine(newWord);
		}

		public static void NumberFive()
        {
			int[] vowels = { 'a', 'e', 'i', 'o', 'u' };
			Console.Write("Enter an English Word: ");
			var input = Console.ReadLine();
			input = input.ToLower();
			var count = 0;

			foreach (var item in input)
			{
				for (int i = 0; i < vowels.Length; i++)
				{
					if (vowels[i] == item)
						count++;
				}
			}

			Console.WriteLine("There are {0} vowel/s", count);
		}
	}
}

