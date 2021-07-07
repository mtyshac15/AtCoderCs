using AtCoder.Common;
using System;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem016
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var N = IOLibrary.ReadLong();
            var (A, B, C) = IOLibrary.ReadLong3();

            var count = 10000;
            var min = 10000;
            for (int a = 0; a < count; a++)
            {
                for (int b = 0; b < count; b++)
                {
                    var reminder = N - A * a - B * b;
                    if (reminder >= 0
                        && reminder % C == 0)
                    {
                        var c = (int)(reminder / C);
                        min = Math.Min(a + b + c, min);
                    }
                }
            }

            IOLibrary.WriteLine(min);
        }
    }
}
