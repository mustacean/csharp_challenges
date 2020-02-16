using System.Collections.Generic;

public static class Extensions
{
    public static int Binomial (this int number, int sec)//done!
    {
        int factorials (int i) => i == 0 ? 1 : i * factorials (--i);

        //N! / N-K! / K!
        return factorials (number) / factorials (number - sec) / factorials (sec);
    }

    public static IEnumerable<IEnumerable<int>> PascalTriangle (int number_of_row)//done!
    {
        IEnumerable<int> RowOrderer (int row)
        {
            for (int i = 0; i <= row; i++)
                yield return Extensions.Binomial (row, i);
        };

        for (int i = 0; i < number_of_row; i++)
            yield return RowOrderer (i);
    }
}
