using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC337
{
    public class ProblemB
    {
        public static void Main(string[] args)
        {
            var problem = new ProblemB();
            problem.Solve();
        }

        /// <summary>
        /// Extended ABC
        /// </summary>
        public void Solve()
        {
            var S = Console.ReadLine().Trim();

            var current = 'A';

            foreach (var c in S)
            {
                if (current == 'A')
                {
                    if (c == 'B' || c == 'C')
                    {
                        current = c;
                    }
                }
                else if (current == 'B')
                {
                    if (c == 'A')
                    {
                        Console.WriteLine(ProblemB.ToYesOrNo(false));
                        return;
                    }
                    else if (c == 'C')
                    {
                        current = c;
                    }
                }
                else if (current == 'C')
                {
                    if (c != 'C')
                    {
                        Console.WriteLine(ProblemB.ToYesOrNo(false));
                        return;
                    }
                }
            }

            Console.WriteLine(ProblemB.ToYesOrNo(true));
        }

        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
