using System;

namespace factorials
{
    class Program
    {
        static void Main (string[] args)
        {
            System.Console.WriteLine ("give me a number:");
            if (int.TryParse (Console.ReadLine (), out int x))
                System.Console.WriteLine (x + "! : " + x.FactorialsRecursive ());
            System.Console.WriteLine ("fibonacci of N = " + x);
            foreach (var item in x.FibonacciNumbers ()) System.Console.WriteLine (item);
        }
    }
}