using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC179
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
        {
            var s = IOLibrary.ReadLine();
            var text = (s[s.Length - 1] != 's') ? "s" : "es";
            IOLibrary.WriteLine(s + text);
        }

        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var DList = IOLibrary.ReadInt2DArray(N);

            for (var i = 0; i < N - 2; i++)
            {
                var D0 = DList[i];
                var D1 = DList[i + 1];
                var D2 = DList[i + 2];
                if (D0[0] == D0[1]
                    && D1[0] == D1[1]
                    && D2[0] == D2[1])
                {
                    IOLibrary.WriteLine(IOLibrary.ToYesOrNo(true));
                    return;
                }
            }

            IOLibrary.WriteLine(IOLibrary.ToYesOrNo(false));
        }

        public override void SolveC()
        {
            var N = IOLibrary.ReadInt();
            var count = 0;

            for (var A = 1; A < N; A++)
            {
                var BCCount = (N - 1) / A;
                count += BCCount;
            }
            IOLibrary.WriteLine(count);
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

