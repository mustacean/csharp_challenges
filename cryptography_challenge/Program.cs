using System;

namespace cryptography
{
    class Program
    {
        static void TestFermat ()
        {
            var biggy = new System.Numerics.BigInteger (131);
            var prob_ = biggy.PrimalityTestWithFermatTheorem (50);
            System.Console.WriteLine ("possiblity that number is prime : " + (prob_).ToString ());
        }

        static void TestCryptographicRandomNumberGenerator ()
        {
            int max_num = 9, min_num = 0, num_of_trial = 100_000;

            var _arr = new (long num, int times_encountered, double percent) [max_num - min_num + 1];

            var xt = num_of_trial.CryptographicRandomNumbers (min_num, max_num);

            foreach (var item in xt)
            {
                _arr[item].num = item;
                _arr[item].times_encountered++;
                _arr[item].percent = (_arr[item].times_encountered / (double) num_of_trial) * 100;
            }

            System.Console.WriteLine ("(number, times encountered, percentage(%)");
            foreach (var tple in _arr) System.Console.WriteLine (tple);
        }
    }
}
