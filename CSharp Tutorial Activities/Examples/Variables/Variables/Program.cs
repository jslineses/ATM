using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables
{
	class Program
	{
		static void Main(string[] args)
		{

			var number = 4;
			var count = 20;
			var totalPrice = 37.70f;
			var character = 'F';
			var firstName = "John";
			var isWorking = true;

			Console.WriteLine(number);
			Console.WriteLine(count);
			Console.WriteLine(totalPrice);
			Console.WriteLine(character);
			Console.WriteLine(firstName);
			Console.WriteLine(isWorking);

			Console.WriteLine("{0} {1}", byte.MinValue, byte.MaxValue);
			Console.WriteLine("{0} {1}", float.MinValue, float.MaxValue);

			const float Pi = 3.14f;
			Console.WriteLine("This value can't modify: {0}", Pi);
		}
	}
}
