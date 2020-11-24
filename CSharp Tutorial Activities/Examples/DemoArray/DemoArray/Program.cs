using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoArray
{
    class Program
    {
        static void Main(string[] args)
		{
			int[] numbers = new int[6] { 7, 5, 2, 12, 0, 0 };
			numbers[4] = 9;
			numbers[5] = 6;

			for (int i = 0; i < numbers.Length; i++)
			{
				Console.WriteLine(numbers[i]);
			}
		}
    }
}
