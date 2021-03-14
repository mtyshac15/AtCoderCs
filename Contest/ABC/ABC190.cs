using System;
using System.Collections.Generic;
using System.Linq;

public static class ABC190
{
    #region "192"

    public static void Star()
    {
        var x = IOLibrary.ReadInt();
        var ans = 100 - x % 100;
        Console.WriteLine(ans);
    }

    public static void uNrEaDaBlEsTrInG()
    {
        var S = IOLibrary.ReadLine();
        for (var i = 0; i < S.Length; i++)
        {
            var str = S[i];
            if ((i + 1 & 1) == 1)
            {
                if (Char.IsUpper(str))
                {
                    IOLibrary.WriteYesOrNo(false);
                    return;
                }
            }
            else
            {
                if (!Char.IsUpper(str))
                {
                    IOLibrary.WriteYesOrNo(false);
                    return;
                }
            }
        }

        IOLibrary.WriteYesOrNo(true);
    }

    public static void KaprekarNumber()
    {
        var (N, K) = IOLibrary.ReadLong2();

        Func<long, long> f = (x) =>
        {
            var array = x.ToString()
                         .Select(str => int.Parse(str.ToString()))
                         .ToArray();
            var sortedArray = array.Sort();

            var num1 = long.Parse(string.Join("", sortedArray.Reverse()));
            var num2 = long.Parse(string.Join("", sortedArray));
            var num = num1 - num2;
            return num;
        };

        var ans = N;
        for (var i = 0; i < K; i++)
        {
            ans = f(ans);
        }

        Console.WriteLine(ans);
    }

    public static void Basen()
    {
        var X = IOLibrary.ReadLine();
        var M = IOLibrary.ReadLong();

        if (X.Length == 1)
        {
            var x = int.Parse(X);
            var ans = (x <= M) ? 1 : 0;
            Console.WriteLine(ans);
            return;
        }

        var d = X.Select(str => long.Parse(str.ToString()))
                 .Max();

        Func<long, bool> isOk = (n) =>
        {
            //Mをn進表記に変換
            var Y = new List<long>();
            var m = M;

            while (m > 0)
            {
                Y.Add(m % n);
                m /= n;
            }

            Y.Reverse();

            if (Y.Count != X.Length)
            {
                return (Y.Count > X.Length);
            }

            if (Y.Count == X.Length)
            {
                for (var i = 0; i < X.Length; i++)
                {
                    var x = long.Parse(X[i].ToString());
                    var y = Y[i];
                    if (x != y)
                    {
                        return (x < y);
                    }
                }
            }

            return true;
        };

        var ok = d;
        var ng = long.MaxValue;
        var maxNum = MathLibrary.BinarySearch(ok, ng, isOk);

        var count = maxNum - d;
        Console.WriteLine(count);
    }

    public static void Train()
    {
        var (N, M, X, Y) = IOLibrary.ReadInt4();
    }

    #endregion

    #region "191"

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

    public static void DigitalGraffiti()
    {
        var (H, W) = IOLibrary.ReadInt2();
        var S = IOLibrary.ReadStringArray(H, W);

        var brack = "#";
        var white = ".";

        var ans = 0;
        for (var h = 0; h < H; h++)
        {
            for (var w = 0; w < W; w++)
            {
                if (S[h, w] == brack)
                {
                    //辺、または辺の一部かどうか判定

                    //左
                    if (S[h, w - 1] == white)
                    {
                        if (S[h - 1, w] == white)
                        {
                            ans++;
                        }
                        else if (S[h - 1, w - 1] == brack)
                        {
                            ans++;
                        }
                    }

                    //上
                    if (S[h - 1, w] == white)
                    {
                        if (S[h, w - 1] == white)
                        {
                            ans++;
                        }
                        else if (S[h - 1, w - 1] == brack)
                        {
                            ans++;
                        }
                    }

                    //右
                    if (S[h, w + 1] == white)
                    {
                        if (S[h - 1, w] == white)
                        {
                            ans++;
                        }
                        else if (S[h - 1, w + 1] == brack)
                        {
                            ans++;
                        }
                    }

                    //下
                    if (S[h + 1, w] == white)
                    {
                        if (S[h, w - 1] == white)
                        {
                            ans++;
                        }
                        else if (S[h + 1, w - 1] == brack)
                        {
                            ans++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(ans);
    }

    #region ""

    public static void DigitalGraffitiOld()
    {
        var (H, W) = IOLibrary.ReadInt2();
        var S = IOLibrary.ReadStringArray(H, W);

        var unexploredCellStack = new Stack<int[]>();
        var whiteCountArray = new int[H, W];

        for (var h = 0; h < H; h++)
        {
            for (var w = 0; w < W; w++)
            {
                whiteCountArray[h, w] = -1;
                if (S[h, w] == "#")
                {
                    if (!unexploredCellStack.Any())
                    {
                        unexploredCellStack.Push(new int[] { h, w });
                    }
                }
            }
        }

        var count = ABC190.SearchGrid(S, unexploredCellStack, 0, whiteCountArray);
        Console.WriteLine(count);
    }

    public static int SearchGrid(string[,] field, Stack<int[]> unexploredcellStack, int edgeCount, int[,] whiteCountArray)
    {
        if (!unexploredcellStack.Any())
        {
            return edgeCount;
        }

        var dh = new int[] { 0, 1, 0, -1 };
        var dw = new int[] { 1, 0, -1, 0 };

        var currentCell = unexploredcellStack.Pop();
        var currentH = currentCell[0];
        var currentW = currentCell[1];

        var whiteCount = ABC190.RecordCell(field, unexploredcellStack, currentCell, whiteCountArray);
        if (whiteCount == 4)
        {
            return whiteCount;
        }
        else if (whiteCount == 3)
        {
            edgeCount += whiteCount;

            var h = currentH;
            var w = currentW;

            var directionIndex = 0;
            for (var i = 0; i < 4; i++)
            {
                var nextH = h + dh[i];
                var nextW = w + dw[i];

                var cell = field[nextH, nextW];
                if (cell == "#")
                {
                    directionIndex = i;
                }
            }

            //未探索のマスか、隣接する白のマスの数が3マスになるまで探索
            while (true)
            {
                h += dh[directionIndex];
                w += dw[directionIndex];

                if (field[h, w] != "#")
                {
                    break;
                }

                var nextWhiteCount = whiteCountArray[h, w];

                if (nextWhiteCount == -1
                    || nextWhiteCount == 0)
                {
                    break;
                }

                if (whiteCountArray[h + dh[directionIndex], w + dw[directionIndex]] == 3)
                {
                    edgeCount -= nextWhiteCount;
                    break;
                }
            }

            return ABC190.SearchGrid(field, unexploredcellStack, edgeCount, whiteCountArray);
        }
        else if (whiteCount == 2)
        {
            var h = currentH;
            var w = currentW;

            var direction = "";

            //同じ方向にある場合は辺の一部
            if (field[h - 1, w] == "#"
                && field[h + 1, w] == "#")
            {
                var countUpper = ABC190.RecordCell(field, unexploredcellStack, new int[] { h - 1, w }, whiteCountArray);
                var countLower = ABC190.RecordCell(field, unexploredcellStack, new int[] { h + 1, w }, whiteCountArray);

                if (countUpper == 1 && countLower == 1)
                {
                    edgeCount += 2;
                }

                direction = "h";
            }
            else if (field[h, w - 1] == "#"
                 && field[h, w + 1] == "#")
            {
                var countLeft = ABC190.RecordCell(field, unexploredcellStack, new int[] { h, w - 1 }, whiteCountArray);
                var countRight = ABC190.RecordCell(field, unexploredcellStack, new int[] { h, w + 1 }, whiteCountArray);

                if (countLeft == 1 && countRight == 1)
                {
                    edgeCount += 2;
                }

                direction = "w";
            }

            //隣接するマスが探索済みの場合は、一辺減らす
            if (string.IsNullOrWhiteSpace(direction))
            {
                edgeCount += 2;

                for (var i = 0; i < 4; i++)
                {
                    var distance = 0;
                    while (true)
                    {
                        distance++;

                        var nextH = h + dh[i] * distance;
                        var nextW = w + dw[i] * distance;

                        if (field[nextH, nextW] != "#")
                        {
                            break;
                        }

                        var nextWhitCount = whiteCountArray[nextH, nextW];
                        if (nextWhitCount == 0)
                        {
                            break;
                        }

                        if (nextWhitCount == 2)
                        {
                            edgeCount--;
                            break;
                        }
                    }
                }
            }

            return ABC190.SearchGrid(field, unexploredcellStack, edgeCount, whiteCountArray);
        }

        return ABC190.SearchGrid(field, unexploredcellStack, edgeCount, whiteCountArray);
    }

    public static int RecordCell(string[,] field, Stack<int[]> unexploredcellStack, int[] cell, int[,] whiteCountArray)
    {
        //4方向を探索
        var dh = new int[] { 0, 1, 0, -1 };
        var dw = new int[] { 1, 0, -1, 0 };

        var whiteCount = 4;

        for (var i = 0; i < 4; i++)
        {
            var nextH = cell[0] + dh[i];
            var nextW = cell[1] + dw[i];

            if (field[nextH, nextW] == "#")
            {
                whiteCount--;
                var nextCell = new int[] { nextH, nextW };
                if (whiteCountArray[nextH, nextW] == -1 && unexploredcellStack.All(x => x[0] != nextCell[0] || x[1] != nextCell[1]))
                {
                    unexploredcellStack.Push(nextCell);
                }
            }
        }

        whiteCountArray[cell[0], cell[1]] = whiteCount;
        return whiteCount;
    }

    #endregion

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