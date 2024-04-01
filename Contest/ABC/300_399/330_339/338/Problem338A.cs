using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC338
{
    public class ProblemA
    {
        public static void Main(string[] args)
        {
            var problem = new ProblemA();
            problem.Solve();
        }

        /// <summary>
        /// Capitalized?
        /// </summary>
        public void Solve()
        {
            var S = Console.ReadLine().Trim();

            var result = true;
            for (int i = 0; i < S.Length; i++)
            {
                var str = S[i];

                if (i == 0 && char.IsLower(str))
                {
                    //先頭が小文字
                    result = false;
                }
                else if (i != 0 && char.IsUpper(str))
                {
                    //先頭以外が大文字
                    result = false;
                }
            }

            Console.WriteLine(ProblemA.ToYesOrNo(result));
        }

        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
