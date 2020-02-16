using System;
using System.Linq;

namespace randomizations
{
    class Program
    {
        static void Main (string[] args)
        {
            var nums = System.Linq.Enumerable.Range (1, 20_000).ToList ();

            //System.Console.WriteLine (nums.ShuffleItems_ ().Count);

            // foreach (var item in nums.ShuffleItems_ ())
            // {
            //     System.Console.WriteLine (item);
            // }
            System.Console.WriteLine (nums.ShuffleItems ().Count);
        }

        static void TestRandomPassword () //done.
        {
            var pass = new PasswordFactory ();

            pass.Criterias.Add (new LowerCaseCriteria () { IsAllowed = true, IsRequired = true });
            pass.Criterias.Add (new SpecialCharCriteria () { IsAllowed = false, IsRequired = false });
            pass.Criterias.Add (new UpperCaseCriteria () { IsAllowed = false, IsRequired = false });
            //pass.Criterias.Add (new NumberCriteria () { IsAllowed = true, IsRequired = false });

            var pass_generated = pass.GeneratePassword (5, 10);
            System.Console.WriteLine (pass_generated);
        }
        static void TestMyProbAlgorithm () //done.
        {
            var _ar = new ValueTuple<int, double>[]
                {
                    //(index, weight)
                    (0, 0.3),
                    (1, 0.1),
                    (2, 0.55),
                    (3, 0),
                    (4, 0.04),
                    (5, 0.01)
                };

            int[] test_pr = new int[_ar.Length];
            int NUM_OF_TRIAL = 10_000_000;
            for (int i = 0; i < NUM_OF_TRIAL; i++)
            {
                var nu = _ar.GetRandomItemWithProbability ();
                test_pr[nu]++;
            }

            for (int i = 0; i < test_pr.Length; i++)
                System.Console.WriteLine ("item" + i + " : " + ((double) test_pr[i] / NUM_OF_TRIAL));
        }
    }
}