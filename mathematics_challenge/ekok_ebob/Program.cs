using System;

namespace ekok_ebob
{
    class Program
    {
        static void Main (string[] args)
        {
            int n1 = 0, n2 = 0;

            System.Console.WriteLine ("first number:");
            n1 = int.Parse (Console.ReadLine ());
            System.Console.WriteLine ("second number:");
            n2 = int.Parse (Console.ReadLine ());

            var haydar = (n1, n2);
            System.Console.WriteLine ("ebob : " + haydar.Greatest_Common_Divisors ());
            System.Console.WriteLine ("ekok : " + haydar.Least_Common_Multiples ());

            System.Console.WriteLine ("SumsOfMultiples (3, 5): " + 15. SumsOfMultiples (3, 5));
        }
    }
}