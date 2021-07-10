using AtCoder.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Typical.Problem;

namespace Typical.Problem064
{
    public class Problem : TypicalProblemBase
    {
        public override void Solve()
        {
            var (N, Q) = IOLibrary.ReadInt2();
            var A = IOLibrary.ReadIntArray();

            //不便さを集計
            var inconvenience = new long[N + 1];
            for (int i = 0; i < N - 1; i++)
            {
                var sub = A[i + 1] - A[i];
                inconvenience[i + 1] = sub;
            }

            var sum = inconvenience.Sum(x => Math.Abs(x));

            for (int i = 0; i < Q; i++)
            {
                var (L, R, V) = IOLibrary.ReadInt3();

                var before = Math.Abs(inconvenience[L - 1]) + Math.Abs(inconvenience[R]);
                if (L > 1)
                {
                    inconvenience[L - 1] += V;
                }

                if (R < N)
                {
                    inconvenience[R] -= V;
                }

                var after = Math.Abs(inconvenience[L - 1]) + Math.Abs(inconvenience[R]);

                sum += (after - before);

                IOLibrary.WriteLine(sum);
            }
        }

        public void OldSolve()
        {
            var (N, Q) = IOLibrary.ReadInt2();
            var A = IOLibrary.ReadIntArray();

            //不便さを集計
            var inconvenience = new long[N - 1];
            for (int i = 0; i < N - 1; i++)
            {
                var sub = A[i + 1] - A[i];
                inconvenience[i] = sub;
            }

            var sum = inconvenience.Sum(x => Math.Abs(x));

            for (int i = 0; i < Q; i++)
            {
                var (L, R, V) = IOLibrary.ReadInt3();
                if (L > 1)
                {
                    var leftSub = inconvenience[L - 2];
                    if (leftSub > 0 == V > 0)
                    {
                        //差が開く場合
                        sum += Math.Abs(V);
                    }
                    else if (Math.Abs(leftSub) > Math.Abs(V))
                    {
                        sum -= Math.Abs(V);
                    }
                    else
                    {
                        sum -= Math.Abs(inconvenience[L - 2]);
                        var sub = inconvenience[L - 2] + V;
                        sum += Math.Abs(sub);
                    }

                    inconvenience[L - 2] += V;
                }

                if (R < N)
                {
                    var rightSub = inconvenience[R - 1];
                    if (rightSub > 0 != V > 0)
                    {
                        //差が開く場合
                        sum += Math.Abs(V);
                    }
                    else if (Math.Abs(rightSub) > Math.Abs(V))
                    {
                        sum -= Math.Abs(V);
                    }
                    else
                    {
                        sum -= Math.Abs(inconvenience[R - 1]);
                        var sub = inconvenience[R - 1] - V;
                        sum += Math.Abs(sub);
                    }

                    inconvenience[R - 1] -= V;
                }

                IOLibrary.WriteLine(sum);
            }
        }
    }
}
