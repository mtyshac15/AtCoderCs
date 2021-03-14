using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ARC110
{
    #region "113"

    public static void ABCA()
    {
        var K = IOLibrary.ReadInt();

        var counts = new long[3];

        //a=b=c
        for (var a = 1; a * a * a <= K; a++)
        {
            counts[0]++;
        }

        //a=b
        for (var a = 1; a * a <= K; a++)
        {
            var minC = 1;
            var maxC = K / (a * a);

            var count = maxC - minC + 1;
            if (minC <= a && maxC >= a)
            {
                count--;
            }

            counts[1] += count * 3;
        }

        //a<b<c
        for (var a = 1; a * a <= K; a++)
        {
            for (var b = a + 1; a * b <= K; b++)
            {
                var minC = b + 1;
                var maxC = K / (a * b);
                if (maxC > b)
                {
                    counts[2] += (maxC - minC + 1) * 6;
                }
            }
        }

        Console.WriteLine(counts.Sum());
    }

    public static void ABCB()
    {
        var (A, B, C) = IOLibrary.ReadLong3();

        var list = new List<int>();

        ModInt.Init(10);
        ModInt a = A;

        ModInt num = 1;
        for (var i = 0; i < 10; i++)
        {
            num *= a;

            if (list.Contains(num.ToInt()))
            {
                break;
            }

            list.Add(num.ToInt());
        }

        ModInt.Init(list.Count);
       var exp = ModInt.Pow(B, C);

        var index = (exp - 1).ToInt();
        var ans = list[index];
        Console.WriteLine(ans);
    }

    #endregion

    #region "112"

    public static void AMinusBEqualsC()
    {
        var T = IOLibrary.ReadInt();

        for (var i = 0; i < T; i++)
        {
            var (L, R) = IOLibrary.ReadInt2();

            var ans = 0L;

            if (2 * L <= R)
            {
                var maxCount = 0L;
                {
                    var a = R;
                    var minB = L;
                    var maxB = a - minB;
                    maxCount += maxB - minB + 1;
                }

                ans += maxCount * (maxCount + 1) / 2;
            }

            Console.WriteLine(ans);
        }
    }

    public static void MinusB()
    {
        var (B, C) = IOLibrary.ReadLong2();

        var correctedB = B;
        var correctedC = C;

        if (correctedB < 0)
        {
            correctedC--;
            correctedB *= -1;
        }

        var exchange = correctedC;

        //Bより大きい数の個数
        //最初と最後に-1倍
        exchange -= 2;

        //-1を行う回数
        var maxNum = exchange / 2;

        //Bより小さい数の個数
        var rangeArray = new long[3][]
        {
            new long[2],
            new long[2],
            new long[2],
        };

        var minNum = 0L;
        {
            var quotient = correctedC / 2;
            //-1のみ行う場合
            rangeArray[0][1] = correctedB - 1;
            rangeArray[0][0] = Math.Min(correctedB - quotient, correctedB - 1);
        }

        if (correctedC >= 1)
        {
            exchange = correctedC;
            exchange--;
            var quotient = exchange / 2;

            //最初に-1倍する場合
            {
                rangeArray[1][1] = Math.Min(-correctedB, correctedB - 1);
                rangeArray[1][0] = Math.Min(-correctedB - quotient, correctedB - 1);
            }

            //最後に-1倍する場合
            {
                var num = -(correctedB - 1);
                rangeArray[2][1] = Math.Min(num, correctedB - 1);

                num = -(correctedB - quotient);
                rangeArray[2][0] = Math.Min(num, correctedB - 1);
            }
        }

        minNum += rangeArray[0][1] - rangeArray[0][0] + 1;
        if (rangeArray[1][1] == rangeArray[0][0])
        {
            minNum += rangeArray[0][1] - rangeArray[1][0] + 1;
        }
        else if (rangeArray[1][1] < rangeArray[0][0])
        {
            minNum += rangeArray[1][1] - rangeArray[1][0] + 1;
        }
        else
        {
            var duplicate = rangeArray[1][1] - rangeArray[0][0];
            var num = rangeArray[1][1] - rangeArray[1][0] + 1 - duplicate;
            minNum += num;
        }

        if (rangeArray[2][0] < rangeArray[1][0]
            || rangeArray[2][0] > rangeArray[1][1]
            && rangeArray[2][0] < rangeArray[0][0])
        {
            minNum++;
        }

        var count = maxNum + minNum + 1;
        Console.WriteLine(count);
    }

    #endregion

    #region "111"

    public static void SimpleMath2()
    {
        var (N, M) = IOLibrary.ReadLong2();
        ModInt.Init((int)(M * M));
        var product = ModInt.Pow(10, N);
        var ans = product.ToInt() / M;
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

    public static void Method()
    {

    }
}
