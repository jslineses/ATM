using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversion
{
	class Program
	{
		static void Main(string[] args)
		{
			byte b = 1;
			int i = b;
			Console.WriteLine(i);

			try
			{
				var number = "46456";
				byte j = Convert.ToByte(number);
				Console.WriteLine(j);
			}
			catch (Exception)
			{
				Console.WriteLine("Error!");

			}
		}
	}
}
