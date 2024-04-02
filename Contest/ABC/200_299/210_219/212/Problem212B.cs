using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC212
{
    public class ProblemB
    {
        public static void Main(string[] args)
        {
            var problem = new ProblemB();
            problem.Solve();
        }

        /// <summary>
        /// Weak Password
        /// </summary>
        public void Solve()
        {
            var X = Console.ReadLine().Trim().Select(x => int.Parse(x.ToString())).ToArray();

            //4桁とも同じ数字
            if (X[0] == X[1]
                && X[1] == X[2]
                && X[2] == X[3])
            {
                Console.WriteLine("Weak");
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                var nextNum = (X[i] + 1) % 10;
                if (X[i + 1] != nextNum)
                {
                    Console.WriteLine("Strong");
                    return;
                }
            }

            Console.WriteLine("Weak");
        }
    }
}
