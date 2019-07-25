using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPractice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DelegatePractice delegatePractice = new DelegatePractice();
            delegatePractice.ShowDelegate();

            Anonymous anonymous = new Anonymous()
            {
                Age = 1,
                ID = 123456,
                Name = "Anonymous",
            };
            anonymous.AnonymousMethod();

            var anonymous1 = new
            {
                Age = 1,
                ID = 1234567,
                Name = "Anonymous",
                Other = 1
            };
            Console.WriteLine("{0},{1},{2},{3}", anonymous1.Name, anonymous1.ID, anonymous1.Other, anonymous1.Age);
            Console.ReadKey();
        }
    }
}