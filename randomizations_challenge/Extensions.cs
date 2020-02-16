using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Extensions
{
    static Random rnd = new Random ();
    public static double GenerateRandomDouble (double min, double max) //done !
    {
        double diff = max - min;
        if (diff <= 0) throw new ArithmeticException ("maximum value can't be greater than or equal to minimum value.");
        diff = Math.Round (diff, 5);

        var integer_part = ((int) diff);
        var floating_part = diff - integer_part;

        int rnd_int = 0;
        double rnd_double = 0;
        while (true)
        {
            rnd_int = rnd.Next (0, integer_part);
            rnd_double = rnd.NextDouble ();
            if (rnd_int + rnd_double <= diff) break;
        }
        return min + rnd_int + rnd_double;
    }

    public static T GetRandomItemWithProbability<T> (this (T value, double weight) [] l_pro) //done!
    {
        bool IsValid () => l_pro.Select (i => i.weight >= 0 ? i.weight : 0).Sum () == 1;

        if (!IsValid ()) throw new InvalidOperationException ("sum of the all probabilities should equal to one.");
        var rnd_we = rnd.NextDouble ();

        double sum = 0;
        foreach (var item in l_pro)
        {
            sum += item.weight;
            if (sum >= rnd_we) return item.value;
        }
        return default;
    }

    public static List<T> ShuffleItems<T> (this IList<T> _list) //done!
    {
        List<T> new_list = new List<T> ();
        for (int i = 0; i < _list.Count;)
        {
            int r_num = rnd.Next (0, _list.Count);
            new_list.Add (_list[r_num]);
            _list.RemoveAt (r_num);
        }
        return new_list;
    }

    private static List<T> ShuffleItems_<T> (this List<T> _list) // much worse.
    {
        LinkedList<T> hestalin_celal = new LinkedList<T> (_list);
        LinkedList<T> shuff (LinkedList<T> l_sh)
        {
            var linked_list = new LinkedList<T> ();

            foreach (var item in l_sh)
            {
                int one_or_zero = rnd.Next (0, 2);
                if (one_or_zero == 1) linked_list.AddFirst (new LinkedListNode<T> (item));
                else linked_list.AddLast (new LinkedListNode<T> (item));
            }
            return linked_list;
        }

        for (int i = 0; i < _list.Count / 2; i++) hestalin_celal = shuff (hestalin_celal);
        return hestalin_celal.ToList ();
    }
}