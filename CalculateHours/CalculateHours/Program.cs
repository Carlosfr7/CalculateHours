using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateHours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSpan timeDesired = new TimeSpan(1,23,0);
            TimeCalculator calculator = new TimeCalculator();

            var estimatedFinal = calculator.GetDate(timeDesired);            

            Console.WriteLine(estimatedFinal.ToString());
            Console.ReadLine();
        }
    }
}
