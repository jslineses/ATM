using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
		{
			var george = new Person();
			george.FirstName = "George";
			george.LastName = "Naismith";
			george.Introduce();

			Calculator calculator = new Calculator();
			var result = calculator.Add(1, 1);
			Console.WriteLine(result);
		}
    }
}
