using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC108
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var (S, P) = IOLibrary.ReadLong2();

            for (var N = 1L; N * N <= P; N++)
            {
                var M = P - N;
                if (N * M == S)
                {
                    Console.WriteLine(IOLibrary.ToYesOrNo(true));
                    return;
                }
            }

            Console.WriteLine(IOLibrary.ToYesOrNo(false));
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var s = IOLibrary.ReadLine();
            var t = new List<char>(N);

            foreach (var str in s)
            {
                t.Add(str);

                if (t.Count >= 3)
                {
                    if (t[t.Count - 3] == 'f' && t[t.Count - 2] == 'o' && t[t.Count - 1] == 'x')
                    {
                        t.RemoveAt(t.Count - 1);
                        t.RemoveAt(t.Count - 1);
                        t.RemoveAt(t.Count - 1);
                    }
                }
            }

            Console.WriteLine(t.Count);
        }

        public override void SolveC()
        {

        }

        public override void SolveD()
        {

        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

