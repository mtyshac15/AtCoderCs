using System;
using System.Collections.Generic;
using System.Linq;

public static class ABC190
{
    #region "199"

    #endregion

    #region "198"

    #endregion

    #region "197"

    #endregion

    #region "196"

    #endregion

    #region "195"

    #endregion

    #region "194"

    #endregion

    #region "193"

    #endregion

    #region "192"

    #endregion

    #region "191"

    public static void CircleLatticePoints()
    {
        var multiple = 10000;
        var input = IOLibrary.ReadStringArray()
                             .Select(item => (long)(decimal.Parse(item) * multiple))
                             .ToArray();

        var X = input[0];
        var Y = input[1];
        var R = input[2];

        var count = 0L;

        var maxR = 100000L;

        for (var y = -2 * maxR; y <= 2 * maxR; y++)
        {
            var tmpY = y * multiple;

            var dy = Math.Abs(Y - tmpY);

            if (dy <= R)
            {
                var x2 = R * R - dy * dy;

                Func<long, bool> isOk = (x) =>
                {
                    var dx2 = (X - x) * (X - x);
                    return dx2 <= x2;
                };

                var minRange = -2 * maxR * multiple;
                var maxRange = 2 * maxR * multiple;

                var left = MathLibrary.BinarySearch(X, minRange - 1, isOk);
                var right = MathLibrary.BinarySearch(X, maxRange + 1, isOk);

                //10^4の倍数の個数
                var countL = MathLibrary.Ceiling(left, multiple) / multiple;
                var countR = MathLibrary.Floor(right, multiple) / multiple;

                if (countL <= countR)
                {
                    count += countR - countL + 1;
                }
            }
        }

        Console.WriteLine(count);
    }

    public static void DigitalGraffiti()
    {
        var (H, W) = IOLibrary.ReadInt2();
        var S = IOLibrary.ReadStringArray(H, W);
    }

    public static void RemoveIt()
    {
        var (N, X) = IOLibrary.ReadLong2();
        var A = IOLibrary.ReadLongArray();

        foreach (var a in A)
        {
            if (a != X)
            {
                Console.Write(a + " ");
            }
        }
    }

    public static void VanishingPitch()
    {
        var (V, T, S, D) = IOLibrary.ReadInt4();

        var start = V * T;
        var end = V * S;
        if (D < start || end < D)
        {
            IOLibrary.WriteYesOrNo(true);
        }
        else
        {
            IOLibrary.WriteYesOrNo(false);
        }
    }

    #endregion

    #region "190"

    public static void VeryVeryPrimitiveGame()
    {
        var (A, B, C) = IOLibrary.ReadInt3();

        if (A == B)
        {
            var winner = (C == 0) ? "Aoki" : "Takahashi";
            Console.WriteLine(winner);
        }
        else
        {
            var winner = (A < B) ? "Aoki" : "Takahashi";
            Console.WriteLine(winner);
        }
    }

    public static void Magic3()
    {
        var (N, S, D) = IOLibrary.ReadLong3();
        for (var i = 0; i < N; i++)
        {
            var (x, y) = IOLibrary.ReadLong2();
            if (x < S && y > D)
            {
                Console.WriteLine(IOLibrary.ToYesOrNo(true));
                return;
            }
        }

        Console.WriteLine(IOLibrary.ToYesOrNo(false));
    }

    public static void BowlsAndDishes()
    {
        var (N, M) = IOLibrary.ReadInt2();
        var AB = IOLibrary.ReadInt2DArray(M, 2);
        var K = IOLibrary.ReadInt();
        var CD = IOLibrary.ReadInt2DArray(K, 2);

        var maxCount = 0;

        for (var bit = 0; bit < (1 << K); bit++)
        {
            var dish = new int[N];
            for (var i = 0; i < K; i++)
            {
                var index = MathLibrary.TestBit(bit, i) ? 1 : 0;
                var cd = CD[i, index] - 1;
                dish[cd]++;
            }

            //集計
            var count = 0;
            for (var i = 0; i < M; i++)
            {
                var a = AB[i, 0] - 1;
                var b = AB[i, 1] - 1;

                if (dish[a] > 0 && dish[b] > 0)
                {
                    count++;
                }
            }

            maxCount = Math.Max(maxCount, count);
        }

        Console.WriteLine(maxCount);
    }

    public static void StaircaseSequences()
    {
        var N = IOLibrary.ReadLong();
        var ng = 2 * (long)Math.Sqrt(N);
        var ok = 0L;

        //1+・・・+k<=Nを満たす最大のkを求める
        while (Math.Abs(ok - ng) > 1)
        {
            var middle = ok + (ng - ok) / 2;
            //1からkまでの和
            var sum = middle * (middle + 1) / 2;
            if (sum <= N + 1)
            {
                ok = middle;
            }
            else
            {
                ng = middle;
            }
        }

        var maxNum = ok;

        var suma = maxNum * (maxNum + 1) / 2;

        var flag = (suma == N);

        var count = 0;

        for (var num = 1; num <= maxNum; num++)
        {
            var a = N / num - 1;

            for (var middle = a - 1; middle <= a + 1; middle++)
            {
                var end = middle + num / 2;
                var sum = end * (end + 1) / 2 - (end - num) * (end - num + 1) / 2;
                if (sum == N)
                {
                    count += 2;
                }
            }
        }

        Console.WriteLine(count);
    }

    #endregion

    public static void Method()
    {

    }
}