using System;
using System.Collections.Generic;
using System.Linq;

public static class ARCLike
{
    #region 

    public static void TwoSequences2()
    {
        var N = IOLibrary.ReadInt();
        var a = IOLibrary.ReadLongArray();
        var b = IOLibrary.ReadLongArray();

        var maxA = a[0];
        var maxC = a[0] * b[0];

        for (var j = 0; j < N; j++)
        {
            for (var i = Math.Max(0, j - 1); i <= j; i++)
            {
                if (a[i] > maxA)
                {
                    maxA = a[j];
                }
            }

            var c = maxA * b[j];
            if (c > maxC)
            {
                maxC = c;
            }

            Console.WriteLine(maxC);
        }
    }

    public static void MexBoxes()
    {
        var (N, K) = IOLibrary.ReadLong2();
        var a = IOLibrary.ReadLongArray();
        var sortedA = a.Sort().GroupBy(item => item);

        var sum = 0L;

        var num = -1L;
        var boxNum = K;
        foreach (var ball in sortedA)
        {
            if (ball.Key == num + 1)
            {
                //iに書き換える箱の個数
                var x = Math.Min(ball.Count(), boxNum);
                sum += x;

                boxNum = x;
                num = ball.Key;
            }
        }

        Console.WriteLine(sum);
    }

    public static void RobotOnGrid()
    {
        var mod = 998244353;
        ModInt.Init(mod);

        var (H, W, K) = IOLibrary.ReadInt3();

        var list = MathLibrary.CreateList(new { H = 0, W = 0, C = "" });

        for (var i = 0; i < K; i++)
        {
            var inputs = IOLibrary.ReadStringArray();
            var h = int.Parse(inputs[0]);
            var w = int.Parse(inputs[1]);
            var c = inputs[2];
            var item = new { H = h, W = w, C = c };
            list.Add(item);
        }
    }

    #endregion

    public static void Method()
    {

    }
}