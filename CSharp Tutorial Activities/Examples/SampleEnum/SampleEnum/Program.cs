using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEnum
{
    class Program
	{
		public enum ShippingMethod
		{
			RegularAirMail = 1,
			RegisteredMail = 2,
			Express = 3
		}
		static void Main(string[] args)
		{
			var method = ShippingMethod.Express;
			Console.WriteLine((int) method);

			var methodId = 2;
			Console.WriteLine((ShippingMethod) methodId);
			Console.WriteLine(method.ToString());

			var methodName = "Express";
			var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);

		}
    }
}
