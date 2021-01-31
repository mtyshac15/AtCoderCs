using System;
using System.Collections.Generic;
using System.Linq;

public static class ABC170
{
    #region "179"

    public static void PluralForm()
    {
        var s = IOLibrary.ReadLine();
        var text = (s[s.Length - 1] != 's') ? "s" : "es";
        Console.WriteLine(s + text);
    }

    public static void GotoJail()
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
                Console.WriteLine(IOLibrary.YesOrNo(true));
                return;
            }
        }

        Console.WriteLine(IOLibrary.YesOrNo(false));
    }

    public static void ATimesBPlusC()
    {
        var N = IOLibrary.ReadInt();
        var count = 0;

        for (var A = 1; A < N; A++)
        {
            var BCCount = (N - 1) / A;
            count += BCCount;
        }
        Console.WriteLine(count);
    }

    #endregion

    #region "178"

    public static void Not()
    {
        var x = IOLibrary.ReadInt();
        Console.WriteLine(1 - x);
    }

    public static void ProductMax()
    {
        var (a, b, c, d) = IOLibrary.ReadLong4();

        var x = new long[] { a, b };
        var y = new long[] { c, d };

        //直積
        var xy = x.SelectMany(n => y,
                             (ex, ey) => ex * ey);

        Console.WriteLine(xy.Max());
    }

    public static void Ubiquity()
    {
        var N = IOLibrary.ReadLong();

        var all = ModInt.Pow(10, N);

        //0を含まない
        var not0 = ModInt.Pow(9, N);

        //9を含まない
        var not9 = not0;

        //0と9を含まない
        var not0Or9 = ModInt.Pow(8, N);

        var ans = all - not0 - not9 + not0Or9;
        Console.WriteLine(ans);
    }

    #endregion

    #region "177"

    public static void DontBeLate()
    {
        var (D, T, S) = IOLibrary.ReadInt3();
        var ans = S * T >= D;
        Console.WriteLine(IOLibrary.YesOrNo(ans));
    }

    public static void SubString()
    {
        var S = IOLibrary.ReadLine();
        var T = IOLibrary.ReadLine();

        var ans = T.Length;

        for (var sIndex = 0; sIndex < S.Length - T.Length + 1; sIndex++)
        {
            var count = 0;
            for (var tIndex = 0; tIndex < T.Length; tIndex++)
            {
                if (T[tIndex] != S[sIndex + tIndex])
                {
                    count++;
                }
            }

            ans = Math.Min(ans, count);
        }

        Console.WriteLine(ans);
    }

    public static void SumOfProductOfPairs()
    {
        var N = IOLibrary.ReadInt();
        var A = IOLibrary.ReadLongArray();

        var partSumList = new List<ModInt>() { 0 };

        foreach (var a in A)
        {
            var sum = partSumList[partSumList.Count - 1] + a;
            partSumList.Add(sum);
        }

        ModInt ans = 0;
        for (var i = 0; i < N - 1; i++)
        {
            ModInt ai = A[i];
            // i+1からN番目までの和
            var sum = partSumList[partSumList.Count - 1] - partSumList[i + 1];

            ans += ai * sum;
        }

        Console.WriteLine(ans);
    }

    #endregion

    #region "176"

    public static void Takoyaki()
    {
        var (N, X, T) = IOLibrary.ReadInt3();
        var times = (N + X - 1) / X;
        var t = times * T;
        Console.WriteLine(t);
    }

    public static void MultipleOf9()
    {
        var input = IOLibrary.ReadLine();
        ModInt.Init(9);
        ModInt sum = 0;

        foreach (var c in input)
        {
            var num = int.Parse(c.ToString());
            sum += num;
        }

        var ans = sum == 0;
        Console.WriteLine(IOLibrary.YesOrNo(ans));
    }

    public static void Step()
    {
        var N = IOLibrary.ReadInt();
        var A = IOLibrary.ReadLongArray();

        var ans = 0L;
        var maxNum = 0L;

        for (var i = 0; i < N; i++)
        {
            maxNum = Math.Max(maxNum, A[i]);
            ans += maxNum - A[i];
        }

        Console.WriteLine(ans);
    }

    #endregion

    #region "175"

    public static void RainySeason()
    {
        var S = IOLibrary.ReadLine();

        var count = 0;
        var strR = "R";
        for (var i = 0; i < S.Length; i++)
        {
            //Rがi+1回連続した文字列を含むか
            if (!S.Contains(strR))
            {
                Console.WriteLine(count);
                return;
            }
            else
            {
                count++;
                strR += "R";
            }
        }

        Console.WriteLine(count);
    }

    public static void MakingTriangle()
    {
        var N = IOLibrary.ReadInt();
        var L = IOLibrary.ReadIntArray();
        var sortedL = L.Sort();

        if (N < 3)
        {
            Console.WriteLine(0);
            return;
        }

        var count = 0;
        foreach (var combinationIndex in MathLibrary.GetCombinationIndexCollection(N, 3))
        {
            var i = combinationIndex[0];
            var j = combinationIndex[1];
            var k = combinationIndex[2];

            if (sortedL[i] != sortedL[j]
                && sortedL[j] != sortedL[k]
                && sortedL[i] + sortedL[j] > sortedL[k])
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }

    public static void WalkingTakahashi()
    {
        var (X, K, D) = IOLibrary.ReadLong3();

        //原点の方向へ移動する回数
        var startX = Math.Abs(X);

        var count = startX / D;
        var remainder = startX - D * K;
        if (count > K)
        {
            //同じ方向へK回移動
            Console.WriteLine(remainder);
            return;
        }

        var remainingNum = K - count;
        var currentX = startX - D * count;

        if (remainingNum % 2 == 0)
        {
            //残り回数が偶数の場合
            //正の方向と負の方向に同じ回数だけ移動
            Console.WriteLine(currentX);
        }
        else
        {
            //残り回数が偶数の場合
            //1度だけ原点の方向へD移動し、
            //残りを正の方向と負の方向に同じ回数だけ移動
            currentX = Math.Abs(currentX - D);
            Console.WriteLine(currentX);
        }
    }

    #endregion

    #region "174"

    public static void AirConditioner()
    {
        var X = IOLibrary.ReadInt();
        var ans = X >= 30;
        Console.WriteLine(IOLibrary.YesOrNo(ans));
    }

    public static void Distance()
    {
        var (N, D) = IOLibrary.ReadLong2();
        var pointArray = IOLibrary.ReadLong2DArray(N);

        var count = 0;
        for (var i = 0; i < N; i++)
        {
            var (X, Y) = IOLibrary.ReadLong2();
            var distanceSquare = X * Y + Y * Y;
            if (distanceSquare <= D * D)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }

    public static void Repsept()
    {
        var K = IOLibrary.ReadInt();
        ModInt.Init(K);

        ModInt a = 7;
        for (var i = 1; i <= K; i++)
        {
            if (a == 0)
            {
                Console.WriteLine(i);
                return;
            }

            a = 10 * a + 7;
        }

        Console.WriteLine(-1);
    }

    #endregion

    #region "173"

    public static void Payment()
    {
        var N = IOLibrary.ReadInt();
        var money = 1000;
        var bills = (N + money - 1) / money;
        var change = money * bills - N;
        Console.WriteLine(change);
    }

    public static void JudgeStatusSummary()
    {
        var N = IOLibrary.ReadInt();
        var S = IOLibrary.ReadStringArray(N);

        var results = new string[]
        {
            $"AC",
            $"WA",
            $"TLE",
            $"RE",
        };

        var table = results.GroupJoin(S,
                                      r => r,
                                      c => c,
                                      (r, cArray) => new
                                      {
                                          Reult = r,
                                          Count = cArray?.Count(),
                                      });

        foreach (var item in table)
        {
            Console.WriteLine($"{item.Reult} x {item.Count.GetValueOrDefault()}");
        }
    }

    public static void HAndV()
    {
        var (H, W, K) = IOLibrary.ReadInt3();

        var black = '#';
        var blackNum = 0;

        var hArray = new string[H + 1];
        hArray[0] = string.Join("", Enumerable.Repeat(" ", W + 1));

        for (var i = 1; i < H + 1; i++)
        {
            var str = IOLibrary.ReadLine();
            blackNum += str.Count(item => item == black);
            hArray[i] = " " + str;
        }

        var wArray = new string[W + 1];
        wArray[0] = string.Join("", Enumerable.Repeat(" ", H + 1));

        for (var i = 1; i < W + 1; i++)
        {
            wArray[i] = string.Join("", hArray.Select(item => item[i]));
        }

        //削除時に含まれる黒の個数
        var hDeleteBlackCountArray = new int[(1 << hArray.Length)];
        for (var h = 0; h < hDeleteBlackCountArray.Length; h++)
        {
            var hIndexes = MathLibrary.GetSubsetFromBits(h);
            var count = 0;
            foreach (var hIndex in hIndexes)
            {
                count += hArray[hIndex].Count(c => c == black);
            }
            hDeleteBlackCountArray[h] = count;
        }

        var wDeleteBlackCountArray = new int[(1 << W + 1)];
        for (var w = 0; w < wDeleteBlackCountArray.Length; w++)
        {
            var wIndexes = MathLibrary.GetSubsetFromBits(w);
            var count = 0;
            foreach (var wIndex in wIndexes)
            {
                count += wArray[wIndex].Count(c => c == black);
            }
            wDeleteBlackCountArray[w] = count;
        }

        //集計
        var ans = 0;
        for (var h = 0; h < hDeleteBlackCountArray.Length; h++)
        {
            for (var w = 0; w < wDeleteBlackCountArray.Length; w++)
            {
                var deleteCount = hDeleteBlackCountArray[h] + wDeleteBlackCountArray[w];

                //重複分を削除
                var duplicateNum = MathLibrary.bitCount(h) * MathLibrary.bitCount(w);

                deleteCount = duplicateNum;

                if (blackNum - deleteCount == K)
                {
                    ans++;
                }
            }
        }

        Console.WriteLine(ans);
    }

    #endregion

    #region "172"

    public static void Calc()
    {
        var a = IOLibrary.ReadInt();
        var ans = a + a * a + a * a * a;
        Console.WriteLine(ans);
    }

    public static void MinorChange()
    {
        var S = IOLibrary.ReadLine();
        var T = IOLibrary.ReadLine();

        var ans = S.Zip(T, (s, t) => (s != t) ? 1 : 0).Sum();
        Console.WriteLine(ans);
    }

    #endregion

    #region "171"

    public static void Alphabet()
    {
        var a = IOLibrary.ReadLine();
        var ans = char.IsUpper(a[0]) ? "A" : "a";
        Console.WriteLine(ans);
    }

    public static void MixJuice()
    {
        var (N, K) = IOLibrary.ReadInt2();
        var p = IOLibrary.ReadIntArray();
        var total = p.Sort().Take(K).Sum();
        Console.WriteLine(total);
    }

    #endregion

    #region "170"

    #endregion

    public static void Method()
    {

    }
}