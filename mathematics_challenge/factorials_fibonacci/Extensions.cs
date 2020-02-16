using System.Collections.Generic;

public static class Extensions
{
    public static int Factorials (this int number) //done!
    {
        int fac = 1;
        for (int i = number; i >= 1; i--) fac *= i;
        return fac;
    }
    public static int FactorialsRecursive (this int number) //done!
    {
        return number == 0 ? 1 : number * FactorialsRecursive (--number);
    }
    public static int[] FibonacciNumbers (this int count) //done!
    {
        var _arr = new int[count];
        _arr[0] = 0;
        _arr[1] = 1;
        for (int i = 2; i < count; i++) _arr[i] = _arr[i - 1] + _arr[i - 2];
        return _arr;
    }
}