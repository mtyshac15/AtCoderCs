using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC206
{
    public class ProblemA
    {
        public static void Main(string[] args)
        {
            var problem = new ProblemA();
            problem.Solve();
        }

        /// <summary>
        /// Maxi-Buying
        /// </summary>
        public void Solve()
        {
            var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

            var price = (int)(N * 1.08);

            var originalPrice = 206;
            if (price < originalPrice)
            {
                Console.WriteLine("Yay!");
            }
            else if (price > originalPrice)
            {
                Console.WriteLine(":(");
            }
            else
            {
                Console.WriteLine("so-so");
            }
        }
    }
}
