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
                Console.WriteLine(IOLibrary.YesOrNo(true));
                return;
            }
        }

        Console.WriteLine(IOLibrary.YesOrNo(false));
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