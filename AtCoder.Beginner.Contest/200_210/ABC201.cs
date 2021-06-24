using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC201
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var A = IOLibrary.ReadIntArray();
            A.Sort();
            IOLibrary.WriteYesOrNo(A[2] - A[1] == A[1] - A[0]);
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();

            var mountains = new string[N];
            var heights = new int[N];

            for (int i = 0; i < N; i++)
            {
                var ST = IOLibrary.ReadStringArray();

                var s = ST[0];
                var t = int.Parse(ST[1]);

                mountains[i] = s;
                heights[i] = t;
            }

            var ansT = heights.ToArray().Sort().Reverse().Skip(1).FirstOrDefault();
            var index = Array.IndexOf(heights, ansT);
            var ans = mountains[index];

            IOLibrary.WriteLine(ans);
        }

        public override void SolveC()
        {
            var S = IOLibrary.ReadLine();

            var ans = 0;

            var list = new List<int>();
            var oList = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                var s = S[i];
                if (s == 'o')
                {
                    list.Add(i);
                    oList.Add(i);
                }
                else if (s == '?')
                {
                    list.Add(i);
                }
            }

            foreach (var i0 in list)
            {
                foreach (var i1 in list)
                {
                    foreach (var i2 in list)
                    {
                        foreach (var i3 in list)
                        {
                            var testArray = new int[] { i0, i1, i2, i3 };

                            //oをすべて満たしているか
                            var result = true;
                            foreach (var o in oList)
                            {
                                if (!testArray.Contains(o))
                                {
                                    result = false;
                                    break;
                                }
                            }

                            if (result)
                            {
                                ans++;
                            }
                        }
                    }
                }
            }

            IOLibrary.WriteLine(ans);
        }

        public override void SolveD()
        {
            var (H, W) = IOLibrary.ReadInt2();
            var A = IOLibrary.ReadStringArray(H, W);
        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

