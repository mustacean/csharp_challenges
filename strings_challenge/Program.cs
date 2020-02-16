using System;

namespace strings
{
    class Program
    {
        static void Main (string[] args)
        {
            
        }

        static void TestPalindromic ()
        {
            while (true)
            {
                System.Console.WriteLine ("Type a text to be analyzed : ");
                System.Console.WriteLine ("longest palandromic in the text : " + Console.ReadLine ().LongestPalindromic ());
            }
        }
    }
}