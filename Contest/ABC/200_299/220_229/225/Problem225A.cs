using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC225
{
    public class ProblemA
    {
        public static void Main(string[] args)
        {
            var problem = new ProblemA();
            problem.Solve();
        }

        /// <summary>
        /// Distinct Strings
        /// </summary>
        public void Solve()
        {
            var S = Console.ReadLine().Trim();

            //文字種類の個数を算出
            var charSet = new HashSet<char>(S.ToCharArray());

            var ans = 6;
            if (charSet.Count == 1)
            {
                ans = 1;
            }
            else if (charSet.Count == 2)
            {
                //文字の種類が2種類のとき、同じ文字は2文字ある 3!/2!
                ans = 3;
            }

            Console.WriteLine(ans);
        }
    }
}
