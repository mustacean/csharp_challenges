using System;

namespace statistical
{
    class Program
    {
        static void Main (string[] args)
        {
            var numbers = new double[]
            {
                0.1,
                0.5,
                15,
                12,
                12.1,
                5.3,
                3.1,
                3.1,
                2,
                2.1,
                2,
                2
            };

            System.Console.WriteLine ("here is the mod : " + numbers.Mod ());

            System.Console.WriteLine ("here is the median : " + numbers.Median ());

            System.Console.WriteLine ("here is the mean : " + numbers.Mean ());

            System.Console.WriteLine ("here is the (2 times) truncated mean : " + numbers.TruncatedMean (2));

            System.Console.WriteLine ("here is the standard deviation : " + numbers.StandardDeviation ());
        }
    }
}