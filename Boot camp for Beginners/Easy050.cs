using System;
using System.Collections.Generic;
using System.Linq;

public static class Easy050
{
    #region "1-10"

    /// <summary>
    /// 1
    /// </summary>
    public static void PowerSocket()
    {
        var (A, B) = IOLibrary.ReadInt2();
        if (B == 1)
        {
            Console.WriteLine(0);
            return;
        }

        var ans = (B - 2) / (A - 1) + 1;
        Console.WriteLine(ans);
    }

    /// <summary>
    /// 2
    /// </summary>
    public static void Rally()
    {
        var N = IOLibrary.ReadInt();
        var X = IOLibrary.ReadIntArray();

        //Xの平均に近い整数
        var P = (int)(X.Average() + 0.5);

        var sumSquare = 0L;
        for (var i = 0; i < N; i++)
        {
            sumSquare += (X[i] - P) * (X[i] - P);
        }

        Console.WriteLine(sumSquare);
    }

    /// <summary>
    /// 3
    /// </summary>
    public static void QualificationSimulator()
    {
        var (N, A, B) = IOLibrary.ReadInt3();
        var S = IOLibrary.ReadLine();

        var passList = S.Select(s => false).ToArray();

        var totalCount = 0;
        var bCount = 0;
        for (var i = 0; i < passList.Length; i++)
        {
            if (totalCount >= A + B)
            {
                break;
            }

            if (S[i] == 'a')
            {
                passList[i] = true;
                totalCount++;
            }
            else if (S[i] == 'b')
            {
                var result = bCount < B;
                passList[i] = result;

                if (result)
                {
                    bCount++;
                    totalCount++;
                }
            }
        }

        foreach (var result in passList)
        {
            IOLibrary.WriteLine(IOLibrary.ToYesOrNo(result));
        }
    }

    /// <summary>
    /// 4
    /// </summary>
    public static void TaxRate()
    {
        var N = IOLibrary.ReadInt();
        var rate = 1.08;
        //小数部分を切り上げ
        var X = (int)Math.Ceiling(N / rate);

        //検算
        if (N == (int)(X * rate))
        {
            Console.WriteLine(X);
        }
        else
        {
            Console.WriteLine($":(");
        }
    }

    /// <summary>
    /// 5
    /// </summary>
    public static void CanYouSolveThis()
    {
        var (N, M, C) = IOLibrary.ReadInt3();
        var B = IOLibrary.ReadIntArray();
        var A = IOLibrary.ReadInt2DArray(N);

        var count = 0;
        for (var i = 0; i < N; i++)
        {
            var sum = C;
            for (var j = 0; j < M; j++)
            {
                sum += A[i][j] * B[j];
            }

            if (sum > 0)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }

    /// <summary>
    /// 6
    /// </summary>
    public static void Bishop()
    {
        var (H, W) = IOLibrary.ReadLong2();
        if (H == 1 || W == 1)
        {
            Console.WriteLine(1);
            return;
        }

        var count = (H * W + 1) / 2;
        Console.WriteLine(count);
    }

    /// <summary>
    /// 7
    /// </summary>
    public static void Bingo()
    {
        var gridNum = 3;
        var A = IOLibrary.ReadInt2DArray(gridNum, gridNum);
        var N = IOLibrary.ReadInt();
        var b = new int[N];
        for (var i = 0; i < N; i++)
        {
            b[i] = IOLibrary.ReadInt();
        }

        var judgeList = new bool[gridNum, gridNum];

        for (var i = 0; i < gridNum; i++)
        {
            for (var j = 0; j < gridNum; j++)
            {
                //数字をマーク
                var num = A[i, j];
                if (b.Contains(num))
                {
                    judgeList[i, j] = true;
                }
            }
        }

        //ビンゴかどうかチェック
        //横
        for (var i = 0; i < gridNum; i++)
        {
            if (judgeList[i, 0] & judgeList[i, 1] & judgeList[i, 2])
            {
                Console.WriteLine(IOLibrary.ToYesOrNo(true));
                return;
            }
        }

        //縦
        for (var i = 0; i < gridNum; i++)
        {
            if (judgeList[0, i] & judgeList[1, i] & judgeList[2, i])
            {
                Console.WriteLine(IOLibrary.ToYesOrNo(true));
                return;
            }
        }

        //ななめ
        if (judgeList[0, 0] & judgeList[1, 1] & judgeList[2, 2]
            || judgeList[0, 2] & judgeList[1, 1] & judgeList[2, 0])
        {
            Console.WriteLine(IOLibrary.ToYesOrNo(true));
            return;
        }

        Console.WriteLine(IOLibrary.ToYesOrNo(false));
    }

    /// <summary>
    /// 8
    /// </summary>
    public static void One21()
    {
        var a = IOLibrary.ReadLine();
        var b = IOLibrary.ReadLine();
        var num = int.Parse(a + b);

        var n = 1000;
        for (var i = 0; i < n; i++)
        {
            if (i * i == num)
            {
                Console.WriteLine(IOLibrary.ToYesOrNo(true));
                return;
            }
        }

        Console.WriteLine(IOLibrary.ToYesOrNo(false));
    }

    /// <summary>
    /// 9
    /// </summary>
    public static void CollectingBallsEasy()
    {
        var N = IOLibrary.ReadInt();
        var K = IOLibrary.ReadInt();
        var x = IOLibrary.ReadIntArray();

        var sum = 0;
        for (var i = 0; i < N; i++)
        {
            var length = Math.Min(x[i], K - x[i]);
            sum += 2 * length;
        }

        Console.WriteLine(sum);
    }

    /// <summary>
    /// 10
    /// </summary>
    public static void CardGameForTwo()
    {
        var N = IOLibrary.ReadInt();
        var a = IOLibrary.ReadIntArray();
        var sortedA = a.Sort()
                       .Reverse()
                       .Select((a, index) => new
                       {
                           Value = a,
                           Index = index,
                       });

        var AliceSum = sortedA.Where(a => a.Index % 2 == 0).Sum(a => a.Value);
        var BobSum = sortedA.Where(a => a.Index % 2 != 0).Sum(a => a.Value);

        var ans = AliceSum - BobSum;
        Console.WriteLine(ans);
    }

    #endregion

    #region "11-20"

    /// <summary>
    /// 11
    /// </summary>
    public static void BreakNumber()
    {
        var N = IOLibrary.ReadInt();
        var product = 1;

        while (product * 2 <= N)
        {
            product <<= 1;
        }

        Console.WriteLine(product);
    }

    /// <summary>
    /// 12
    /// </summary>
    public static void TravelingSalesmanAroundLake()
    {
        var (K, N) = IOLibrary.ReadInt2();
        var A = IOLibrary.ReadModIntArray(K);

        var ans = ModInt.Max;
        var startIndex = 0;

        do
        {
            var start = A[startIndex];
            var goal = A[(startIndex + N - 1) % N];
            var length = goal - start;
            if (length < ans)
            {
                ans = length;
            }
            startIndex++;
            startIndex %= N;
        } while (startIndex != 0);

        Console.WriteLine(ans);
    }

    /// <summary>
    /// 13
    /// </summary>
    public static void CookieExhanges()
    {
        var (A, B, C) = IOLibrary.ReadLong3();

        if (A == B
            && B == C)
        {
            if (A % 2 == 0)
            {
                Console.WriteLine(-1);
                return;
            }
            else
            {
                Console.WriteLine(0);
                return;
            }
        }

        var count = 0;

        var An1 = A;
        var Bn1 = B;
        var Cn1 = C;

        while (An1 % 2 == 0
            && Bn1 % 2 == 0
            && Cn1 % 2 == 0)
        {
            var tmpA = (Bn1 + Cn1) / 2;
            var tmpB = (Cn1 + An1) / 2;
            var tmpC = (An1 + Bn1) / 2;

            An1 = tmpA;
            Bn1 = tmpB;
            Cn1 = tmpC;
            count++;
        }

        Console.WriteLine(count);
    }

    public static void ReplacingInteger()
    {
        var (N, K) = IOLibrary.ReadLong2();
        var remainder = N % K;
        Console.WriteLine(Math.Min(remainder, K - remainder));
    }

    public static void DivideTheProblems()
    {
        var N = IOLibrary.ReadInt();
        var d = IOLibrary.ReadIntArray();
        var sortedD = d.Sort();

        var middle = N / 2;
        var maxABC = sortedD[middle - 1];
        var minARC = sortedD[middle];
        Console.WriteLine(minARC - maxABC);
    }

    public static void GoToSchool()
    {
        var N = IOLibrary.ReadInt();
        var A = IOLibrary.ReadIntArray()
                         .Select((content, index) => new
                         {
                             Content = content,
                             Index = index,
                         })
                         .ToArray();

        Array.Sort(A,
                   (x, y) =>
                   {
                       if (x.Content == y.Content)
                       {
                           return 0;
                       }
                       else if (x.Content < y.Content)
                       {
                           return -1;
                       }
                       else
                       {
                           return 1;
                       }
                   });

        var ans = string.Join(" ", A.Select(a => a.Index + 1));
        Console.WriteLine(ans);
    }

    public static void Alchemist()
    {
        var N = IOLibrary.ReadInt();
        var v = IOLibrary.ReadIntArray();

        var ans = v.Sort().Skip(1).Aggregate((double)v[0], (x, y) => (x + y) / 2.0);
        Console.WriteLine(ans);
    }

    public static void ATCoder()
    {
        var S = IOLibrary.ReadLine();

        var str = "ACGT";

        var ans = 0;
        var count = 0;

        foreach (var s in S)
        {
            if (str.Contains(s))
            {
                count++;
            }
            else
            {
                count = 0;
            }

            ans = Math.Max(ans, count);
        }

        Console.WriteLine(ans);
    }

    public static void TollGates()
    {
        var (N, M, X) = IOLibrary.ReadInt3();
        var A = IOLibrary.ReadIntArray();

        //0からX-1までのコスト
        var cost0 = A.Count(a => a < X);

        //X+1からN-1までのコスト
        var costN = A.Count(a => a > X);

        var ans = Math.Min(cost0, costN);
        Console.WriteLine(ans);
    }

    public static void CollatzProblem()
    {
        var s = IOLibrary.ReadInt();
        var hashSet = new HashSet<int>();

        var an = s;
        var index = 1;

        while (!hashSet.Contains(an))
        {
            hashSet.Add(an);

            if (an % 2 == 0)
            {
                an = an / 2;
            }
            else
            {
                an = 3 * an + 1;
            }

            index++;
        }

        Console.WriteLine(index);
    }

    #endregion

    #region "21-30"

    public static void NextPrime()
    {
        var X = IOLibrary.ReadInt();

        var num = X;
        while (!MathLibrary.IsPrime(num))
        {
            num++;
        }

        Console.WriteLine(num);
    }

    public static void CandyDistributionAgain()
    {
        var (N, x) = IOLibrary.ReadInt2();
        var a = IOLibrary.ReadIntArray();

        var sum = (long)x;
        var count = a.Sort().Select(num => sum -= num).Count(num => num >= 0);

        if (sum > 0)
        {
            count--;
        }

        Console.WriteLine(count);
    }

    public static void Chocolate()
    {
        var N = IOLibrary.ReadInt();
        var (D, X) = IOLibrary.ReadInt2();
        var A = IOLibrary.ReadIntArray(N);

        var count = A.Length;

        var num = 0;
        var sum = X;

        while (count > 0)
        {
            count = A.Select(a => num * a + 1).Count(a => a <= D);
            sum += count;
            num++;
        }

        Console.WriteLine(sum);
    }

    public static void NiceShopping()
    {
        var (A, B, M) = IOLibrary.ReadInt3();
        var a = IOLibrary.ReadIntArray();
        var b = IOLibrary.ReadIntArray();
        var xyc = IOLibrary.ReadInt2DArray(M);

        var minA = a.Min();
        var minB = b.Min();

        var minTotal = minA + minB;

        for (var i = 0; i < M; i++)
        {
            var set = xyc[i];
            var total = a[set[0] - 1] + b[set[1] - 1] - set[2];
            minTotal = Math.Min(total, minTotal);
        }

        Console.WriteLine(minTotal);
    }

    public static void CountOrder()
    {
        var N = IOLibrary.ReadInt();
        var P = IOLibrary.ReadIntArray();
        var Q = IOLibrary.ReadIntArray();

        var a = 0;
        var list = Enumerable.Range(1, N).ToList();
        for (var i = 0; i < N; i++)
        {
            var num = i + 1;
            var index = list.IndexOf(P[i]);
            var factorial = 1;
            for (var k = N - num; k >= 1; k--)
            {
                factorial *= k;
            }
            a += index * factorial;

            list.Remove(P[i]);
        }

        var b = 0;
        list = Enumerable.Range(1, N).ToList();
        for (var i = 0; i < N; i++)
        {
            var num = i + 1;
            var index = list.IndexOf(Q[i]);
            var factorial = 1;
            for (var k = N - num; k >= 1; k--)
            {
                factorial *= k;
            }
            b += index * factorial;

            list.Remove(Q[i]);
        }

        Console.WriteLine(Math.Abs(a - b));
    }

    public static void CaracalVsMonster()
    {
        var H = IOLibrary.ReadLong();
        var count = MathLibrary.Log(H, 2);
        var ans = MathLibrary.Pow(2, count + 1) - 1;
        Console.WriteLine(ans);
    }

    public static void CountBalls()
    {
        var (N, A, B) = IOLibrary.ReadLong3();
        var ballsSet = N / (A + B);
        var buleBallsNum = ballsSet * A;
        var remainder = N % (A + B);
        buleBallsNum += Math.Min(remainder, A);
        Console.WriteLine(buleBallsNum);
    }

    public static void SevenFiveFour()
    {
        var S = IOLibrary.ReadLine();
        var stdNum = 753;
        var length = 3;

        var minDiff = int.MaxValue;
        for (var i = 0; i < S.Length - length + 1; i++)
        {
            var numStr = S.Substring(i, length);
            var num = int.Parse(numStr);
            minDiff = Math.Min(Math.Abs(num - stdNum), minDiff);
        }
        Console.WriteLine(minDiff);
    }

    public static void RuinedSquare()
    {
        var (x1, y1, x2, y2) = IOLibrary.ReadInt4();
        var dx = x2 - x1;
        var dy = y2 - y1;

        //正の方向に90度回転
        var directionX = -dy;
        var directionY = dx;

        var x3 = x2 + directionX;
        var y3 = y2 + directionY;

        var x4 = x1 + directionX;
        var y4 = y1 + directionY;

        var p = new int[] { x3, y3, x4, y4 };
        Console.WriteLine(string.Join(" ", p));
    }

    #endregion

    #region "31-40"

    public static void Varied()
    {
        var S = IOLibrary.ReadLine();
        var result = (S.Length == S.Distinct().Count()) ? $"yes" : "no";
        Console.WriteLine(result);
    }

    public static void IncrementDecrement()
    {
        var N = IOLibrary.ReadInt();
        var S = IOLibrary.ReadLine();

        var x = 0;
        var max = x;
        foreach (var str in S)
        {
            if (str == 'I')
            {
                x++;
            }
            else if (str == 'D')
            {
                x--;
            }
            max = Math.Max(x, max);
        }

        Console.WriteLine(max);
    }

    public static void PostalCode()
    {

    }

    public static void Coins()
    {

    }

    #endregion

    #region "41-50"

    #endregion
}