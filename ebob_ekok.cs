namespace ekok_ebob
{
    public static class Extensions
    {
        public static int SumsOfMultiples (this int max, int a = 3, int b = 5)//done!
        {
            int sum = 0;
            for (int i = 1; i <= max; i++)
            {
                int g_with_a = Greatest_Common_Divisors ((a, i));
                int g_with_b = Greatest_Common_Divisors ((b, i));

                if (g_with_a != 1 || g_with_b != 1) sum += i;
            }
            return sum;
        }

        public static int Least_Common_Multiples (this (int a, int b) nums) //done!
        {
            int gcd = Greatest_Common_Divisors (nums);

            if (gcd == 1) return nums.a * nums.b;
            else
            {
                int x1 = nums.a / gcd;
                int x2 = nums.b / gcd;
                return x1 * x2 * gcd;
            }
        }

        public static int Greatest_Common_Divisors (this (int a, int b) nums) //done!
        {
            int yeah_homie (int biggie, int smalls)
            {
                while (true)
                {
                    int rm = biggie % smalls;
                    biggie = smalls;
                    if (rm == 0) break;
                    smalls = rm;
                }
                return smalls;
            }
            if (nums.a > nums.b) return yeah_homie (nums.a, nums.b);
            else if (nums.a == nums.b) return nums.a;
            else return yeah_homie (nums.b, nums.a);
        }
    }
}
