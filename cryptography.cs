using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

static class Extensions
{
    private static char ShiftLetter (this char c, int shift, bool ToLeft)
    {
        char start_char = '\0';
        char end_char = '\0';
        if (char.IsUpper (c)) { start_char = 'A'; end_char = 'Z'; }
        else if (char.IsLower (c)) { start_char = 'a'; end_char = 'z'; }

        int len = end_char - start_char + 1;
        int hestalin_celal = c - start_char;
        //26 letters
        if (ToLeft)
        {
            return (char) ((shift + hestalin_celal) % len + start_char);
        }
        else
        {
            hestalin_celal = len - (hestalin_celal) - 1;
            return (char) (end_char - ((shift + hestalin_celal) % len));
        }

        throw new System.NotImplementedException ();
    }
    private static string foo (this string msg, int key, bool to_lef)
    {
        StringBuilder sb = new StringBuilder ();
        for (int i = 0; i < msg.Length; i++)
        {
            var ch = (char) msg[i];
            sb.Append (char.IsLetter (ch) ? ch.ShiftLetter (key, to_lef) : ch);
        }
        return sb.ToString ();
    }
    private static string foo_2 (this string msg, string key, bool to_lef)
    {
        var sb = new StringBuilder ();
        int counter = 0;
        foreach (var item in msg)
        {
            if (counter == key.Length) counter = 0;
            var too = key[counter];
            sb.Append (char.IsLetter (item) ? item.ShiftLetter ((byte) too - (char.IsUpper (too) ? 'A' : 'a') + 1, to_lef) : item);
            counter++;
        }
        return sb.ToString ();
    }
    public static string CaesarEncrypt (this string msg, int key) => msg.foo (key, true); //done!
    public static string CaesarDecrypt (this string msg, int key) => msg.foo (key, false); //done!
    public static string VigonereEncrypt (this string msg, string key) => msg.foo_2 (key, true); //done!
    public static string VigonereDecrypt (this string msg, string key) => msg.foo_2 (key, false); //done!
    public static long CryptographicRandomNumber (long min, long max) //done!
    {
        using (var rand = RandomNumberGenerator.Create ())
        {
            int arr_len = 8;

            if (max < int.MaxValue && max >= short.MaxValue) arr_len = 4;
            else if (max <= short.MaxValue && max >= byte.MaxValue) arr_len = 2;
            else if (max <= byte.MaxValue) arr_len = 1;

            var arr = new byte[arr_len];

            long value_to_return = 0;
            while (true)
            {
                rand.GetBytes (arr);
                value_to_return = (long) new BigInteger (value: arr, isUnsigned: false, isBigEndian: false);
                if (value_to_return > max || value_to_return < min) continue;
                else break;
            }
            return value_to_return;
        }
    }
    public static IEnumerable<long> CryptographicRandomNumbers (this int numoftimes, long min, long max) //done!
    {
        foreach (var item in Enumerable.Range (0, numoftimes))
        {
            yield return CryptographicRandomNumber (min, max);
        }
    }
    public static double PrimalityTestWithFermatTheorem (this BigInteger p, int num_of_trials) //done!
    {
        BigInteger RandomN ()
        {
            // 1<= N <= P
            using (var crnc = RandomNumberGenerator.Create ())
            {
                while (true)
                {
                    var b_a = p.ToByteArray ();
                    crnc.GetBytes (b_a);
                    var bi = new BigInteger (b_a);
                    if (bi > 1 && bi <= p) return bi;
                }
            }
        }

        double poss = 1;
        for (int i = 0; i < num_of_trials; i++)
        {
            BigInteger random_N = RandomN ();
            if (System.Numerics.BigInteger.ModPow (random_N, p - 1, p) != 1) return 0;
            else poss *= .5;
        }
        return 1 - poss;
    }
}
