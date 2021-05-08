using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABCLike1
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var S = IOLibrary.ReadLine();
            var ans = S.Count("ZONe");
            IOLibrary.WriteLine(ans);
        }

        public override void SolveB()
        {
            var (N, D, H) = IOLibrary.ReadInt3();
            var pointList = IOLibrary.ReadInt2DArray(N);

            var minA = decimal.MaxValue;

            foreach (var point in pointList)
            {
                var d = point[0];
                var h = point[1];
                var a = ((decimal)H - h) / (D - d);
                if (a < minA)
                {
                    minA = a;
                }
            }

            var ans = minA * (-D) + H;
            ans = Math.Max(ans, 0);
            IOLibrary.WriteLine(ans);
        }

        public override void SolveC()
        {
            var N = IOLibrary.ReadInt();
            var ABCDE = IOLibrary.ReadInt2DArray(N);
            var m = 5;

            Func<long, bool> isOk = (x) =>
            {
                var list = new List<bool[]>();

                if (x < 4)
                {
                    var a = 0;
                }

                foreach (var element in ABCDE)
                {
                    var flagArray = element.Select(i => i >= x).ToArray();
                    if (!list.Any(item => item.SequenceEqual(flagArray)))
                    {
                        list.Add(flagArray);
                    }
                }

                Func<IEnumerable<bool>, IEnumerable<bool>, IEnumerable<bool>>
                    or = (sequence1, sequence2) =>
                 {
                     return sequence1.Zip(sequence2, (e1, e2) => e1 | e2);
                 };

                if (list.Count < 3)
                {
                    var flagArray = list.Aggregate((result, next) => or(result, next)
                                        .ToArray());
                    return flagArray.All(i => i == true);
                }

                var combination = MathLibrary.GetCombinationIndexCollection(list.Count, 3);
                foreach (var indexList in combination)
                {
                    var flagArray = new bool[m];
                    var people = indexList.Select(i => list[i]);
                    foreach (var person in people)
                    {
                        flagArray = or(flagArray, person).ToArray();
                    }

                    if (flagArray.All(i => i == true))
                    {
                        return true;
                    }
                }

                return false;
            };

            var ng = 1000000001;
            var ok = 0;
            var ans = MathLibrary.BinarySearch(ok, ng, isOk);
            IOLibrary.WriteLine(ans);
        }

        public override void SolveD()
        {
            var S = IOLibrary.ReadLine();
            var T = new LinkedList<char>();
            var isReverse = false;

            foreach (var c in S)
            {
                if (c == 'R')
                {
                    isReverse = !isReverse;
                }
                else
                {
                    if (isReverse)
                    {
                        T.AddFirst(c);
                    }
                    else
                    {
                        T.AddLast(c);
                    }
                }
            }

            var ansT = new List<string>();
            foreach (var t in T)
            {
                var lastT = ansT.LastOrDefault();
                var strT = t.ToString();
                if (lastT == strT)
                {
                    ansT.RemoveAt(ansT.Count - 1);
                }
                else
                {
                    ansT.Add(strT);
                }
            }

            if (isReverse)
            {
                ansT.Reverse();
            }

            var ansStr = string.Join("", ansT);
            IOLibrary.WriteLine(ansStr);
        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

