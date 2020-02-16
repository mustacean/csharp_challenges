using System;

namespace binomial_coefficients_pascal_triangle
{
    class Program
    {
        static void Main (string[] args)
        {
            int numb_of_row = 10;
            int sec = 2;
            foreach (var item in System.Linq.Enumerable.Range (sec, numb_of_row))
                System.Console.WriteLine ("C(" + item + "," + sec + ") : " + item.Binomial (sec));

            System.Console.WriteLine ("pascal triangle : ");
            int space_decrementation_motherf_ckin_a_shole_yeah_homie = 1;
            foreach (var item in Extensions.PascalTriangle (numb_of_row))
            {
                for (int i = 0; i < (numb_of_row / 2 + (numb_of_row - space_decrementation_motherf_ckin_a_shole_yeah_homie)); i++) System.Console.Write (" ");
                space_decrementation_motherf_ckin_a_shole_yeah_homie++;
                foreach (var subitem in item) System.Console.Write (" " + subitem);
                System.Console.WriteLine ();
            }
        }
    }
}