using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem002
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadInt();
            if (N % 2 == 1)
            {
                IOLibrary.WriteLine();
                return;
            }

            for (int bit = 0; bit < (1 << N); bit++)
            {
                var str = "";
                for (int i = N - 1; i >= 0; i--)
                {
                    if (MathLibrary.TestBit(bit, i))
                    {
                        str += ')';
                    }
                    else
                    {
                        str += '(';
                    }
                }

                if (this.Check(str))
                {
                    IOLibrary.WriteLine(str);
                }
            }
        }

        private bool Check(string str)
        {
            //カッコの判定
            var count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    count++;
                }
                else if (str[i] == ')')
                {
                    count--;
                }

                if (count < 0)
                {
                    return false;
                }
            }

            return count == 0;
        }

        public void MySolve()
        {
            var N = IOLibrary.ReadInt();
            if (N % 2 == 1)
            {
                IOLibrary.WriteLine();
                return;
            }

            var hashSet = new HashSet<string>();
            var sourceSequence = Enumerable.Range(0, N).ToArray();

            foreach (var indexList in MathLibrary.GetCombinationIndexCollection(N, N / 2))
            {
                var numArray = new int[N];

                foreach (var index in indexList)
                {
                    numArray[index] = -1;
                }

                foreach (var index in sourceSequence.Except(indexList))
                {
                    numArray[index] = 1;
                }

                var ans = 0;
                var isValid = true;
                foreach (var num in numArray)
                {
                    ans += num;
                    if (ans > 0)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    var record = "";
                    foreach (var num in numArray)
                    {
                        record += num < 0 ? "(" : ")";
                    }

                    if (hashSet.Add(record))
                    {
                        IOLibrary.WriteLine(record);
                    }
                }
            }
        }
    }
}
