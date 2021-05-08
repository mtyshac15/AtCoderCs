using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ABC180
{
    #region "189"

    public static void Slot()
    {
        var C = IOLibrary.ReadLine();
        var C1 = C[0];
        var C2 = C[1];
        var C3 = C[2];

        if (C1 == C2 && C2 == C3)
        {
            IOLibrary.WriteLine($"Won");
        }
        else
        {
            IOLibrary.WriteLine($"Lost");
        }
    }

    public static void Alcoholic()
    {
        var (N, X) = IOLibrary.ReadInt2();

        var total = 0;
        for (var i = 0; i < N; i++)
        {
            var (V, P) = IOLibrary.ReadInt2();

            total += V * P;
            if (total > X * 100)
            {
                Console.WriteLine(i + 1);
                return;
            }
        }

        IOLibrary.WriteLine(-1);
    }

    public static void MandarinOrange()
    {
        var N = IOLibrary.ReadInt();
        var A = IOLibrary.ReadIntArray();

        var max = 0;
        for (var l = 0; l < N; l++)
        {
            var x = A[l];
            for (var r = l; r < N; r++)
            {
                x = Math.Min(x, A[r]);
                max = Math.Max(max, x * (r - l + 1));
            }
        }

        IOLibrary.WriteLine(max);
    }

    public static void LogicalExpression()
    {
        var N = IOLibrary.ReadInt();
        var S = IOLibrary.ReadStringArray(N);

        var count = 1L;

        for (var i = 0; i < N; i++)
        {
            if (S[i] == "AND")
            {
            }
            else
            {
                count += 2L << i;
            }
        }

        IOLibrary.WriteLine(count);
    }

    #endregion

    #region "188"

    public static void ThreePointShot()
    {
        var (X, Y) = IOLibrary.ReadInt2();
        var sub = Math.Abs(X - Y);
        IOLibrary.WriteLine(IOLibrary.ToYesOrNo(sub < 3));
    }

    public static void Orthogonality()
    {
        var N = IOLibrary.ReadInt();
        var A = IOLibrary.ReadIntArray();
        var B = IOLibrary.ReadIntArray();

        var sum = A.Zip(B, (a, b) => a * b).Sum();
        IOLibrary.WriteLine(IOLibrary.ToYesOrNo(sum == 0));
    }

    public static void ABCTournament()
    {
        var N = IOLibrary.ReadInt();
        var A = IOLibrary.ReadLongArray();

        var count = A.Length / 2;

        //1から2^(N-1)までの勝者
        var championNum1 = 1;
        var rate1 = 0L;
        for (var i = 0; i < count; i++)
        {
            var a = A[i];
            if (a > rate1)
            {
                championNum1 = i;
                rate1 = a;
            }
        }

        //2^(N-1)+1から2^Nまでの勝者
        var championNum2 = 1;
        var rate2 = 0L;
        for (var i = count; i < A.Length; i++)
        {
            var a = A[i];
            if (a > rate2)
            {
                championNum2 = i;
                rate2 = a;
            }
        }

        var ans = (rate1 < rate2) ? championNum1 + 1 : championNum2 + 1;
        Console.WriteLine(ans);
    }

    public static void SnukePrime()
    {
        var (N, C) = IOLibrary.ReadLong2();

        var dic = new SortedDictionary<long, long>();

        for (var i = 0L; i < N; i++)
        {
            var (a, b, c) = IOLibrary.ReadLong3();
            if (dic.ContainsKey(a))
            {
                dic[a] += c;
            }
            else
            {
                dic.Add(a, c);
            }

            var afterB = b + 1;
            if (dic.ContainsKey(afterB))
            {
                dic[afterB] -= c;
            }
            else
            {
                dic.Add(afterB, -c);
            }
        }

        //集計
        var array = dic.Values.ToArray();
        var sum = 0L;

        var startDay = 1L;
        var prevCost = 0L;

        var isFirst = true;

        foreach (var keyValue in dic)
        {
            if (isFirst)
            {
                startDay = keyValue.Key;
                prevCost = keyValue.Value;
                isFirst = false;
            }
            else
            {
                var days = keyValue.Key - startDay;

                var minCost = Math.Min(prevCost, C);
                sum += minCost * days;

                startDay = keyValue.Key;
                prevCost += keyValue.Value; ;
            }
        }

        IOLibrary.WriteLine(sum);
    }

    #endregion

    #region "187"

    public static void LargeDigits()
    {
        var (A, B) = IOLibrary.ReadInt2();
        Console.WriteLine(Math.Max(MathLibrary.SumOfDigits(A), MathLibrary.SumOfDigits(B)));
    }

    public static void GentlePairs()
    {
        var N = IOLibrary.ReadInt();
        var points = IOLibrary.ReadInt2DArray(N);

        var ans = 0;
        for (var i = 0; i < N; i++)
        {
            for (var j = i + 1; j < N; j++)
            {
                if (i < j)
                {
                    var pointI = points[i];
                    var pointJ = points[j];

                    var dx = Math.Abs(pointI[0] - pointJ[0]);
                    var dy = Math.Abs(pointI[1] - pointJ[1]);
                    if (dx >= dy)
                    {
                        ans++;
                    }
                }
            }
        }

        Console.WriteLine(ans);
    }

    public static void OneSAT()
    {
        var N = IOLibrary.ReadInt();
        var S = IOLibrary.ReadStringArray(N);

        var hashSet = new HashSet<string>(S, StringComparer.OrdinalIgnoreCase);

        foreach (var s in S)
        {
            if (hashSet.Contains('!' + s))
            {
                IOLibrary.WriteLine($"{s}");
                return;
            }
        }

        IOLibrary.WriteLine($"satisfiable");
    }

    public static void ChooseMe()
    {
        var N = IOLibrary.ReadInt();

        var sub = 0L;
        var subList = new List<long>();

        for (var i = 0; i < N; i++)
        {
            var (A, B) = IOLibrary.ReadLong2();
            sub -= A;
            var sum = 2 * A + B;
            subList.Add(sum);
        }
        subList.Sort();

        var ans = 0;

        while (sub <= 0)
        {
            sub += subList.Last();
            subList.RemoveAt(subList.Count - 1);
            ans++;
        }

        IOLibrary.WriteLine($"{ans}");
    }

    #endregion

    #region "186"

    public static void Brick()
    {
        var (N, W) = IOLibrary.ReadInt2();
        Console.WriteLine(N / W);
    }

    public static void BlockOnGrid()
    {
        var (H, W) = IOLibrary.ReadInt2();

        var min = int.MaxValue;

        var A = new int[H][];
        for (var row = 0; row < H; row++)
        {
            A[row] = IOLibrary.ReadIntArray();

            for (var col = 0; col < A[row].Length; col++)
            {
                var num = A[row][col];
                if (num < min)
                {
                    min = num;
                }
            }
        }

        var sum = 0L;
        for (var row = 0; row < H; row++)
        {
            for (var col = 0; col < W; col++)
            {
                sum += A[row][col] - min;
            }
        }

        IOLibrary.WriteLine(sum);
    }

    public static void UnluckySeven()
    {
        var N = IOLibrary.ReadInt();

        var count = 0;
        for (var num = 1; num <= N; num++)
        {
            //10進数
            if (num.ToString().Contains("7"))
            {
                count++;
            }
            else
            {
                //8進数
                if (MathLibrary.ToOct(num).Contains("7"))
                {
                    count++;
                }
            }
        }

        var ans = N - count;
        Console.WriteLine(ans);
    }

    public static void SumOfDifference()
    {
        var N = IOLibrary.ReadLong();
        var A = IOLibrary.ReadLongArray();
        var sortedA = A.Sort();

        var dp = MathLibrary.Range(0, N).Select(index => 2 * index - N + 1);
        var ans = sortedA.Zip(dp, (a, p) => a * p).Sum();

        IOLibrary.WriteLine(ans);
    }

    #endregion

    #region "185"

    public static void ABCPreparation()
    {
        var A = IOLibrary.ReadIntArray();
        Console.WriteLine(A.Min());
    }

    public static void SmartphoneAddiction()
    {
        var (N, M, T) = IOLibrary.ReadInt3();

        var AB = IOLibrary.ReadInt2DArray(M);

        var battery = N;
        var time = 0;

        for (var i = 0; i < M; i++)
        {
            //消費
            var consumption = AB[i][0] - time;
            battery -= consumption;

            if (battery <= 0)
            {
                IOLibrary.WriteLine(IOLibrary.ToYesOrNo(false));
                return;
            }

            //充電
            var charging = AB[i][1] - AB[i][0];
            battery += charging;
            battery = Math.Min(battery, N);
            time = AB[i][1];
        }

        //最後のカフェから家
        {
            var consumption = T - AB[M - 1][1];
            battery -= consumption;
        }

        IOLibrary.WriteLine(IOLibrary.ToYesOrNo(battery > 0));
    }

    public static void DuodecimFerra()
    {
        var L = IOLibrary.ReadInt();

        //重複組合せ
        var ans = MathLibrary.Combination(L - 1, 11);
        IOLibrary.WriteLine(ans);
    }

    #endregion

    #region "184" Determinant, Quizzes, SuperRyuma, IncrementOfCoins

    public static void Determinant()
    {
        var (a, b) = IOLibrary.ReadInt2();
        var (c, d) = IOLibrary.ReadInt2();
        var determinant = a * d - b * c;
        Console.WriteLine(determinant);
    }

    public static void Quizzes()
    {
        var (N, X) = IOLibrary.ReadInt2();
        var s = IOLibrary.ReadLine();

        foreach (var ans in s)
        {
            if (ans == 'o')
            {
                X++;
            }
            else if (ans == 'x')
            {
                X = Math.Max(X - 1, 0);
            }
        }

        Console.WriteLine(X);
    }

    public static void SuperRyuma()
    {
        var (r1, c1) = IOLibrary.ReadLong2();
        var (r2, c2) = IOLibrary.ReadLong2();

        var dr = Math.Abs(r2 - r1);
        var dc = Math.Abs(c2 - c1);

        if (dr == 0 && dc == 0)
        {
            Console.WriteLine(0);
            return;
        }

        if (dr + dc == 0
            || dr - dc == 0
            || dr + dc <= 3)
        {
            Console.WriteLine(1);
            return;
        }

        if ((dr + dc) % 2 == 0)
        {
            //チェス盤で同じ色のマス
            //ななめ移動のみ
            Console.WriteLine(2);
            return;
        }

        //チェス盤で異なる色のマス
        if (Math.Abs(dr - dc) <= 6
              || Math.Abs(dr + dc) <= 6)
        {
            //x座標またはy座標が同じ位置に移動
            Console.WriteLine(2);
            return;
        }

        Console.WriteLine(3);
    }

    public static void IncrementOfCoins()
    {
        var (A, B, C) = IOLibrary.ReadInt3();

        if (A != 0)
        {
        }
    }

    #endregion

    #region "183" ReLU, Billiard, Travel WaterHeater QueenOnGrid

    public static void ReLU()
    {
        var x = IOLibrary.ReadInt();
        Console.WriteLine(Math.Max(x, 0));
    }

    public static void Billiard()
    {
        var (Sx, Sy, Gx, Gy) = IOLibrary.ReadLong4();
        var y0 = (Sx * Gy + Sy * Gx) / (Sy + Gy);
        IOLibrary.WriteLine(y0);
    }

    public static void Travel()
    {
        var (N, K) = IOLibrary.ReadInt2();
        var T = IOLibrary.ReadInt2DArray(N);

        var indexList = MathLibrary.GetPermutationIndex(Enumerable.Range(1, N - 1).ToArray());
        var count = 0;
        foreach (var index in indexList)
        {
            var sumTime = 0;

            //末尾に終点0を追加
            var newIndexList = index.Concat(new int[] { 0 });

            var beforePoint = 0;

            foreach (var currentIndex in newIndexList)
            {
                var time = T[beforePoint][currentIndex];
                sumTime += time;
                beforePoint = currentIndex;
            }

            if (sumTime == K)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }

    public static void WaterHeater()
    {
        var (N, W) = IOLibrary.ReadLong2();

        var S = new long[N];
        var T = new long[N];
        var P = new long[N];

        for (var i = 0; i < N; i++)
        {
            (S[i], T[i], P[i]) = IOLibrary.ReadLong3();
        }

        var maxTime = T.Max();
        var table = new long[maxTime + 2];

        for (var i = 0; i < N; i++)
        {
            table[S[i]] += P[i];
            table[T[i]] -= P[i];
        }

        //集計
        for (var i = 0; i < table.Length; i++)
        {
            table[i + 1] += table[i];
            if (table[i] > W)
            {
                IOLibrary.WriteLine(IOLibrary.ToYesOrNo(false));
                return;
            }
        }

        IOLibrary.WriteLine(IOLibrary.ToYesOrNo(true));
    }

    public static void QueenOnGrid()
    {
        var (H, W) = IOLibrary.ReadInt2();
        var S = IOLibrary.ReadStringArray(H);

        var ans = new ModInt[H, W];

        //初期化
        ans[0, 0] = 1;
        for (var row = 1; row < H; row++)
        {
            if (S[row][0] != '#')
            {
                if (row == 1)
                {
                    ans[row, 0] = 1;
                }
                else
                {
                    ans[row, 0] = ans[row - 1, 0] * 2;
                }
            }
        }

        for (var col = 1; col < W; col++)
        {
            if (S[0][col] != '#')
            {
                if (col == 1)
                {
                    ans[0, col] = 1;
                }
                else
                {
                    ans[0, col] = ans[0, col - 1] * 2;
                }
            }
        }

        var horizontalSum = new ModInt[H, W];
        var verticlSum = new ModInt[H, W];
        var diagonalSum = new ModInt[H, W];

        //集計
        for (var row = 1; row < H; row++)
        {
            for (var col = 1; col < W; col++)
            {
                if (S[row][col] != '#')
                {
                    horizontalSum[row, col] = horizontalSum[row - 1, col] + ans[row - 1, col];
                    verticlSum[row, col] = verticlSum[row, col - 1] + ans[row, col - 1];
                    diagonalSum[row, col] = diagonalSum[row - 1, col - 1] + ans[row - 1, col - 1];
                    ans[row, col] = horizontalSum[row, col] + verticlSum[row, col] + diagonalSum[row, col];
                }
            }
        }

        IOLibrary.WriteLine(ans[H - 1, W - 1]);
    }

    #endregion

    #region "182"

    public static void Twiblr()
    {
        var (A, B) = IOLibrary.ReadLong2();
        var diff = 2 * A + 100 - B;
        IOLibrary.WriteLine(diff);
    }

    public static void InputAlmostGCD()
    {
        var N = IOLibrary.ReadInt();
        var A = IOLibrary.ReadIntArray();

        var maxCount = 0;
        var maxGcd = 1;

        for (var k = 2; k <= A.Max(); k++)
        {
            var count = A.Count(a => a % k == 0);
            if (count > maxCount)
            {
                maxCount = count;
                maxGcd = k;
            }
        }

        Console.WriteLine(maxGcd);
    }
    public static void To3()
    {
        var line = IOLibrary.ReadLine();
        var nArray = new int[line.Length];

        for (var index = 0; index < line.Length; index++)
        {
            nArray[index] = int.Parse(line[index].ToString());
        }

        var remainder = nArray.Sum() % 3;
        if (remainder == 0)
        {
            Console.WriteLine(0);
            return;
        }

        if (nArray.Any(num => num % 3 == remainder))
        {
            if (nArray.Length <= 1)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(1);
            }
        }
        else
        {
            if (nArray.Length <= 2)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(2);
            }
        }
    }

    #endregion

    #region "181"

    public static void HeavyRotation()
    {
        var N = IOLibrary.ReadInt();
        var color = (N % 2 == 0) ? "White" : "Black";
        IOLibrary.WriteLine(color);
    }

    public static void TrapezoidSum()
    {
        var N = IOLibrary.ReadInt();
        var sum = 0L;
        for (var i = 0; i < N; i++)
        {
            var (A, B) = IOLibrary.ReadLong2();
            sum += (A + B) * (B - A + 1) / 2;
        }
        IOLibrary.WriteLine(sum);
    }

    public static void Collinearity()
    {
        var N = IOLibrary.ReadInt();
        var pArray = new Point[N];
        for (var i = 0; i < N; i++)
        {
            var (x, y) = IOLibrary.ReadInt2();
            var p = new Point(x, y);
            pArray[i] = p;
        }

        foreach (var indexArray in MathLibrary.GetCombinationIndexCollection(N, 3))
        {
            var p0 = pArray[indexArray[0]];
            var p1 = pArray[indexArray[1]];
            var p2 = pArray[indexArray[2]];
            var area = Point.CalcTriangleArea(p0 - p1, p0 - p2);
            if (area == 0)
            {
                IOLibrary.WriteLine(IOLibrary.ToYesOrNo(true));
                return;
            }
        }

        IOLibrary.WriteLine(IOLibrary.ToYesOrNo(false));
    }

    #endregion

    #region "180"

    public static void Box()
    {
        var (N, A, B) = IOLibrary.ReadInt3();
        var num = N - A + B;
        Console.WriteLine(num);
    }

    public static void Variousdistances()
    {
        var N = IOLibrary.ReadInt();
        var xArray = IOLibrary.ReadLongArray();

        var mDistance = xArray.Select(x => Math.Abs(x)).Sum();
        IOLibrary.WriteLine(mDistance);

        var eDistance = Math.Sqrt(xArray.Select(x => x * x).Sum());
        IOLibrary.WriteLine(eDistance);

        var cDistance = xArray.Select(x => Math.Abs(x)).Max();
        IOLibrary.WriteLine(cDistance);
    }

    public static void Creampuff()
    {
        var N = IOLibrary.ReadLong();
        var list = MathLibrary.GetDivisorSortedList(N);
        IOLibrary.OutputList(list);
    }

    #endregion

    public static void Method()
    {

    }
}