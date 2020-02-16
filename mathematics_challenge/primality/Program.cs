using System;

namespace primality
{
    class Program
    {
        static void Main (string[] args)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew ();

            System.Console.WriteLine ("Type a number :");

            if (!int.TryParse (Console.ReadLine (), out int x)) return;

            sw.Start ();

            if (x.isPrime ()) { System.Console.WriteLine ("It's a prime number."); }
            System.Console.WriteLine ("prime factors : " +
                string.Join (',', x.PrimeFactors ()));

            System.Console.WriteLine ("unique prime factors : " +
                string.Join (',', x.PrimeFactorsDistinct ()));

            System.Console.WriteLine ("closest prime number : " + x.ClosestPrime ());

            System.Console.Write ("proper divisors : ");
            System.Console.WriteLine (string.Join (',', x.ProperDivisors ()));

            System.Console.WriteLine ("amicable numbers (by : " + x + ") :");
            System.Console.WriteLine (string.Join (',', x.AmicableNumbers ()));

            System.Console.WriteLine ("perfect numbers (by : " + x + ") :");
            System.Console.WriteLine (string.Join (',', x.PerfectNumbers ()));

            System.Console.WriteLine ("amstrong numbers (by : " + x + ") :");
            System.Console.WriteLine (string.Join (',', x.AmstrongNumbers ()));
            sw.Stop ();
            System.Console.WriteLine ("time elapsed :" + sw.ElapsedMilliseconds);
            System.Console.WriteLine ("TYPE THE SPACE BETWEEN TWO CONSECUTIVE NUMBERS :"); //off, ne ingilizce konusuom ama
            if (!int.TryParse (Console.ReadLine (), out int y)) return;
            System.Console.WriteLine ("taking the " + x + " as max, here is the prime tuples (space : " + y + ") : ");
            foreach (var item in x.PrimeTuples (y)) System.Console.WriteLine ("{" + string.Join (',', item) + "}");
        }
    }
}