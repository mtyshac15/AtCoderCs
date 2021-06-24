using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ABC114
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {

        }

        public override void SolveB()
        {

        }

        public override void SolveC()
        {
            var N = IOLibrary.ReadLong();

            var digits = N.Digits();

            var numArray = new int[] { 3, 5, 7 };
            var bitArray = new int[] { 0, 1, 2 };

            var ans = 0;
            Action<long, int> func = null;
            func = (currentNum, bit) =>
            {
                if (currentNum > N)
                {
                    return;
                }

                if(bitArray.All(x => MathLibrary.TestBit(bit, x)))
                {
                    ans++;
                }

                for (int i = 0; i < numArray.Length; i++)
                {
                    var num = numArray[i];
                    var nextNum = currentNum * 10 + num;
                    var nextBit = bit | (1 << i);
                    func(nextNum, nextBit);
                }
            };

            func(0, 0);

            IOLibrary.WriteLine(ans);
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