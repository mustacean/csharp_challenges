using System;
using System.Collections.Generic;
using System.Linq;

public static class Mca_Statistical_Extensions
{
    public static double Mod (this IEnumerable<double> _set)//done!
    {
        var sorted_array = _set.OrderBy (i => i).ToArray ();

        double value_to_return = sorted_array[0];
        int last_iteration_count = 1;
        int most_iteration_count = 1;

        for (int i = 0; i < sorted_array.Length; i++)
        {
            if (i != 0)
            {
                if (sorted_array[i] == sorted_array[i - 1])
                {
                    last_iteration_count++;
                    if (most_iteration_count < last_iteration_count)
                    {
                        most_iteration_count = last_iteration_count;
                        value_to_return = sorted_array[i];
                    }
                }
                else last_iteration_count = 1;
            }
        }
        return value_to_return;
    }

    public static double Median (this IEnumerable<double> _set)//done!
    {
        var _array = _set.OrderBy (i => i).ToArray ();
        var _len = _set.Count ();
        if (_len % 2 == 0)
        {
            var _median_index = ((_len / 2));
            return ((double) (_array[_array.Length == 1 ? 0 : _median_index] + _array[_median_index - 1])) / 2;

        }
        else
        {
            var _median_index = ((_len / 2));
            return _array[_median_index];
        }
    }

    public static double Mean (this IEnumerable<double> _set) => TruncatedMean (_set, 0);//done!

    public static double TruncatedMean (this IEnumerable<double> _set, int count)//done!
    {
        double _avg = 0;
        _set = _set.OrderBy (i => i).ToArray ().AsSpan (count).ToArray ();

        _set = _set.ToArray ().AsSpan (0, _set.Count () - count).ToArray ();

        foreach (var item in _set)
            _avg += item;
        return _avg / _set.Count ();
    }

    public static double StandardDeviation (this IEnumerable<double> _set)//done!
    {
        var _mean = Mean (_set);

        double numerator = 0;
        double denominator = _set.Count ();

        foreach (var item in _set)
        {
            numerator += Math.Pow ((item - _mean), 2);
        }

        var hestalin_celal = numerator / denominator;

        return Math.Sqrt (hestalin_celal);
    }
}
