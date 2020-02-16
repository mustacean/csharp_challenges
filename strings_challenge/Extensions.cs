using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    static IEnumerable<string> Palindromics (this string text1)
    {
        int len = text1.Length;
        System.Func<string, bool> IsPalindromic = (item) =>
        {
            bool is_palindromic = true;
            for (int i = 0; i < item.Length; i++)
                is_palindromic = item[i] == item[item.Length - 1 - i] && is_palindromic;
            return is_palindromic;
        };

        for (int i = 0; i < len; i++)
        {
            var ch = text1[i];

            int startInd = i + 1;
            int indic = i;
            while (true)
            {
                indic = text1.IndexOf (ch, indic + 1, len - 1 - indic);
                if (indic == -1) break;
                var sub_str = text1.Substring (i, indic - i + 1);
                if (IsPalindromic (sub_str)) yield return sub_str;
            }
        }
    }

    public static string LongestPalindromic (this string text1) //done!
    {
        var res = Palindromics (text1);
        return res.OrderByDescending (i => i.Length).FirstOrDefault ();
    }

    
}