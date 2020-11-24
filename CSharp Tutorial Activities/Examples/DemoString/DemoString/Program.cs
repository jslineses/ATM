using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoString
{
    class Program
    {
        static void Main(string[] args)
		{

			int[] numbers = new int[6] { 7, 5, 2, 12, 0, 0 };
			numbers[4] = 9;
			numbers[5] = 6;

			string listNumbers = string.Join(", ", numbers);
			Console.WriteLine(string.Format("This is the list of Numbers\n{0}", listNumbers));

			var firstName = "George";
			var lastName = "Naismith";
			var fullName = string.Format("My name is {0} {1}", firstName, lastName);
			var multiLineSample = @"This is a sample of a multiline
Welcome to this application";
			Console.WriteLine(multiLineSample);
		}
    }
}
