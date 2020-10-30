using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    public static bool isPrime (this int num) //done!
    {
        for (int i = 2; i < (int) System.Math.Sqrt (num); i++)
            if (num % i == 0) return false;
        return true;
    }

    public static IEnumerable<int> PrimesTable (this int max) //done!
    {
        for (int i = max - 1; i >= 0; i--)
            if (isPrime (i)) yield return i;
    }
    public static int ClosestPrime (this int max) //done!
        => PrimesTable (max).FirstOrDefault ();

    public static IEnumerable<int> PrimeFactorsDistinct (this int number) //done!
    {
        IList<int> factors = new List<int> ();
        for (int i = 2; i <= number; i++)
            if (number % i == 0 && i.isPrime ()) factors.Add (i);
        return factors;
    }

    public static IEnumerable<int> PrimeFactors (this int number) // done!
    {
        //60 = 2.2.3.5

        var factors = PrimeFactorsDistinct (number).ToList ();

        var mult_of_factors = 1; // 2.3.5 = 30
        foreach (var item in factors) mult_of_factors *= item;

        var extraNum = number / mult_of_factors; // 2

        if (extraNum != 1) factors.AddRange (PrimeFactors (extraNum));
        return factors;
    }

    public static IEnumerable<IEnumerable<int>> PrimeTuples (this int max_num, int range) //done!
    {
        var prime_numbers_in_range = Enumerable.Range (2, max_num).Where (i => i.isPrime ());

        List<int> p2_cache = new List<int> ();
        IEnumerable<int> fetch_tuple (int p1)
        {
            int coe = 1;
            yield return p1;
            while (true)
            {
                int p2 = p1 + coe * range;
                coe++;
                if (p2 > max_num) break;
                if (p2.isPrime () && !p2_cache.Contains (p2)) { p2_cache.Add (p2); yield return p2; }
                else break;
            }
        }

        foreach (var item in prime_numbers_in_range)
        {
            var x = fetch_tuple (item).ToArray ();
            var y = x.Length;
            if (y > 1) yield return x;
        }
    }

    public static IEnumerable<int> ProperDivisors (this int num, bool include_num_itself = false)
    {
        for (int i = 1; !include_num_itself? i < num : i <= num; i++)
            if (num % i == 0) yield return i;
    }

    public static int SumOfProperDivisors (this int num, bool include_num_itself = false) =>
        ProperDivisors (num, include_num_itself).Sum ();

    public static IEnumerable < (int, int) > AmicableNumbers (this int max) //done!
    {
        List<int> checked_nums = new List<int> ();
        for (int i = 1; i <= max; i++)
        {
            var pro_d_sums = i.SumOfProperDivisors ();
            if (checked_nums.Contains (pro_d_sums)) continue;
            else checked_nums.Add (pro_d_sums);

            var p_d_s_of_pds = pro_d_sums.SumOfProperDivisors ();
            if (p_d_s_of_pds == i && pro_d_sums != i) { checked_nums.Add (p_d_s_of_pds); yield return (i, pro_d_sums); }
        }
    }

    public static IEnumerable<int> PerfectNumbers (this int max) //done!
    {
        for (int i = 1; i <= max; i++)
            if (i == i.SumOfProperDivisors ()) yield return i;
    }

    public static IEnumerable<int> AmstrongNumbers (this int max) //done!
    {
        for (int i = 10; i <= max; i++)
        {
            int num_digit = (int) System.Math.Log10 (i) + 1;
            string num = i.ToString ();
            int sum = 0;
            for (int j = 0; j < num_digit; j++)
            {
                int current_digit = int.Parse (num[j].ToString ());
                sum += (int) System.Math.Pow (current_digit, num_digit);
            }
            if (sum == i) yield return i;
        }
    }
}