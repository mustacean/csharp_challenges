using System;
using System.Collections.Generic;
using System.Linq;

namespace randomizations
{
    abstract class PasswordCriteria
    {
        public abstract Func<char, bool> Validator { get; }
        public bool IsAllowed { get; set; } = true;
        public bool IsRequired { get; set; }
    }
    class NumberCriteria : PasswordCriteria
    {
        public override Func<char, bool> Validator => (i) => IsAllowed & char.IsDigit (i);
    }
    class LowerCaseCriteria : PasswordCriteria
    {
        public override Func<char, bool> Validator => (i) =>
            IsAllowed &
            char.IsLetter (i) &
            char.IsLower (i);
    }
    class UpperCaseCriteria : PasswordCriteria
    {
        public override Func<char, bool> Validator => (i) =>
            IsAllowed &
            char.IsLetter (i) &
            char.IsUpper (i);
    }
    class SpecialCharCriteria : PasswordCriteria
    {
        public override Func<char, bool> Validator => (i) => IsAllowed & char.IsPunctuation (i);
    }

    class PasswordFactory
    {
        public List<PasswordCriteria> Criterias { get; set; } = new List<PasswordCriteria> ();
        static Random rnd = new Random ();

        //Returns preferred indexes..
        List<int> SatisfyPassword (char[] Password, List<PasswordCriteria> criterias_To_Satisfy)
        {
            List<int> picked_indexes = new List<int> ();
            foreach (var item in criterias_To_Satisfy)
            {
                if (!item.IsAllowed) throw new InvalidOperationException ("you say that it requires but not allowing?");
                bool isSatisfied = false;
                foreach (var pass_char in Password)
                {
                    if (item.Validator (pass_char)) { isSatisfied = true; break; }
                }
                if (!isSatisfied)
                {
                    int ran_ind = -1;
                    while (true)
                    {
                        int r = rnd.Next (0, Password.Length);
                        if (!picked_indexes.Contains (r)) { picked_indexes.Add (r); ran_ind = r; break; }
                    }
                    char char_to_add;
                    while (!item.Validator (char_to_add = (char) rnd.Next (30, 256))) { }
                    Password[ran_ind] = char_to_add;
                }
            }
            return picked_indexes;
        }

        public string GeneratePassword (int MinLength, int MaxLength)
        {
            if (MaxLength - MinLength <= 0) throw new ArithmeticException ("sorry, This is not valid in our planet.");

            int PasswordLength = rnd.Next (MinLength, MaxLength + 1);

            if (Criterias.Where (i => i.IsAllowed).Count () == 0)
                throw new OperationCanceledException ("you allow nothin'?");

            var reqs = Criterias.Where (i => i.IsRequired);
            var foo = reqs.Count ();
            if (foo > PasswordLength) PasswordLength = foo;
            char[] Password = new char[PasswordLength];
            int done_num = 0;
            var st_indxs = SatisfyPassword (Password, reqs.ToList ());
            while (true)
            {
                if (done_num == PasswordLength) break;
                if (st_indxs.Contains (done_num)) { done_num++; continue; }
                var rnd_ch = (char) rnd.Next (30, 256);
                bool isValidTotal = false;
                foreach (var item in Criterias)
                {
                    isValidTotal = item.Validator (rnd_ch) || isValidTotal;
                }
                if (isValidTotal) { Password[done_num] = rnd_ch; done_num++; }
            }
            return string.Concat (Password);
        }
    }
}
