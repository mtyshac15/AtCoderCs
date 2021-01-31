using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ARC110
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

    #region "111"

    public static void SimpleMath2()
    {
        var (N, M) = IOLibrary.ReadLong2();
        var m = (int)M;

        //循環節の長さ
        var rlist = new List<int>();
        var remainder = 1;
        var s = 0;
        var t = 0;

        while (true)
        {
            var hasFound = false;
            for (s = 0; s < rlist.Count; s++)
            {
                if (rlist[s] == remainder)
                {
                    hasFound = true;
                    break;
                }
            }

            if (hasFound)
            {
                break;
            }

            rlist.Add(remainder);
            remainder = (remainder * 10) % m;
            if (remainder == 0)
            {
                break;
            }
            t++;
        }

        //循環節の長さ
        var digit = MathLibrary.Digits(N);

        var length = t - s + 1;




        var index = (N - 1) % length;
        var ans = 0;
        Console.WriteLine(ans);
    }

    public static void ReversibleCards()
    {
        var N = IOLibrary.ReadInt();

        var abArray = IOLibrary.ReadInt2DArray(N);

        var max = 400000;
        var sum = new int[max];

        var ans = 0;
        for (var i = 0; i < N; i++)
        {
            var (a, b) = IOLibrary.ReadInt2();

            if (sum[a] == 0)
            {
                ans++;
            }
            else if (sum[b] == 0)
            {
                ans++;
            }
        }

        Console.WriteLine(ans);
    }

    #endregion

    #region "110"

    public static void RedundantRedundancy()
    {
        var N = IOLibrary.ReadInt();
        var list = Enumerable.Range(1, N);
        var ans = MathLibrary.LCM(list);
        Console.WriteLine(ans + 1);
    }

    public static void Many110()
    {
        var N = IOLibrary.ReadInt();
        var T = IOLibrary.ReadLine();

        var num = 10000000000;

        if (N == 1)
        {
            if (T == "0")
            {
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine(2 * num);
            }
            return;
        }
        else if (N == 2)
        {
            if (T == "00")
            {
                Console.WriteLine(0);
            }
            if (T == "10"
                || T == "11")
            {
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine(num - 1);
            }
            return;
        }

        //最初の3文字を取得
        var str = T.Substring(0, 3);

        if (!str.Contains("0")
            || !str.Contains("1")
            || str.Contains("00")
            || str.Contains("010"))
        {
            Console.WriteLine(0);
            return;
        }

        //3文字の繰り返しかどうか
        for (var i = 0; i < N / 3; i++)
        {
            if (str[0] != T[3 * i]
                || str[1] != T[3 * i + 1]
                || str[2] != T[3 * i + 2])
            {
                Console.WriteLine(0);
                return;
            }
        }

        var q = N / 3;
        for (var i = 0; i < N % 3; i++)
        {
            if (str[i] != T[3 * q + i])
            {
                Console.WriteLine(0);
            }
        }

        //開始位置
        var numOfTimes = num / q;
        var startIndex = "110110".IndexOf(str);
        if (startIndex == 0)
        {
            Console.WriteLine(numOfTimes);
        }
        else
        {
            Console.WriteLine(numOfTimes - 1);
        }
    }

    #endregion
}
