using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Practice
{
    public static void Execute()
    {
        // 整数の入力
        int a = int.Parse(Console.ReadLine());
        // スペース区切りの整数の入力
        string[] input = Console.ReadLine().Split(' ');
        int b = int.Parse(input[0]);
        int c = int.Parse(input[1]);
        // 文字列の入力
        string s = Console.ReadLine();
        //出力
        Console.WriteLine(a + b + c + " " + s);
    }

    #region ""

    public static void Product()
    {
        var (a, b) = IOLibrary.ReadInt2();
        var c = a * b;
        var ans = (c % 2 == 0) ? $"Even" : $"Odd";
        Console.WriteLine(ans);
    }

    public static void PlacingMarbles()
    {
        var s = IOLibrary.ReadLine();
        var ans = s.Count(c => c == '1');
        Console.WriteLine(ans);
    }

    public static void ShiftOnly()
    {
        var N = IOLibrary.ReadInt();
        var A = IOLibrary.ReadIntArray();

        var count = 0;
        var list = A.DeepClone();
        while (!list.Any(x => x % 2 == 1))
        {
            for (var i = 0; i < list.Length; i++)
            {
                list[i] >>= 1;
            }
            count++;
        }

        Console.WriteLine(count);
    }

    public static void Coins()
    {
        var A = IOLibrary.ReadInt();
        var B = IOLibrary.ReadInt();
        var C = IOLibrary.ReadInt();
        var X = IOLibrary.ReadInt();

        var count = 0;
        for (var a = 0; a <= A; a++)
        {
            for (var b = 0; b <= B; b++)
            {
                for (var c = 0; c <= C; c++)
                {
                    var total = 500 * a + 100 * b + 50 * c;
                    if (total == X)
                    {
                        count++;
                    }
                }
            }
        }
        Console.WriteLine(count);
    }

    public static void SomeSums()
    {
        var (N, A, B) = IOLibrary.ReadInt3();

        var sum = 0;
        for (var i = 1; i <= N; i++)
        {
            var digitSum = MathLibrary.SumOfDigits(i);
            if (digitSum >= A && digitSum <= B)
            {
                sum += i;
            }
        }
        Console.WriteLine(sum);
    }

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

    public static void KagamiMochi()
    {
        var N = IOLibrary.ReadInt();
        var d = IOLibrary.ReadIntArray(N);
        var ans = d.Distinct().Count();
        Console.WriteLine(ans);
    }

    public static void Otoshidama()
    {
        var (N, Y) = IOLibrary.ReadInt2();

        for (var x = 0; x <= N; x++)
        {
            for (var y = 0; y <= N; y++)
            {
                var z = N - x - y;
                if (z >= 0)
                {
                    var total = 10000 * x + 5000 * y + 1000 * z;
                    if (total == Y)
                    {
                        Console.WriteLine($"{x} {y} {z}");
                        return;
                    }
                }
            }
        }

        Console.WriteLine($"-1 -1 -1");
    }

    public static void Daydream()
    {
        var S = IOLibrary.ReadLine();
        S = new string(S.Reverse().ToArray());

        var words = new string[]
        {
            "dream",
            "dreamer",
            "erase",
            "eraser",
        };
        for (var i = 0; i < words.Length; i++)
        {
            words[i] = new string(words[i].Reverse().ToArray());
        }

        var sIndex = 0;

        while (sIndex < S.Length)
        {
            var hasCut = false;
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (S.SubStringEx(sIndex, word.Length) == word)
                {
                    hasCut = true;
                    sIndex += word.Length;
                    break;
                }
            }

            if (!hasCut)
            {
                Console.WriteLine("NO");
                return;
            }
        }

        Console.WriteLine("YES");
    }

    public static void Ants()
    {
        var L = IOLibrary.ReadInt();
        var n = IOLibrary.ReadInt();
        var x = IOLibrary.ReadIntArray();

        var minTime = 0;
        var maxTime = 0;

        for (var i = 0; i < n; i++)
        {
            var tmpTime = Math.Min(L - x[i], x[i]);
            minTime = Math.Max(minTime, tmpTime);
        }

        for (var i = 0; i < n; i++)
        {
            var tmpTime = Math.Max(L - x[i], x[i]);
            maxTime = Math.Max(maxTime, tmpTime);
        }

        Console.WriteLine(minTime);
        Console.WriteLine(maxTime);
    }

    public static void Lottery()
    {
        var n = IOLibrary.ReadInt();
        var m = IOLibrary.ReadInt();
        var x = IOLibrary.ReadIntArray().Sort().ToArray();

        var cdArray = new int[n * n];
        for (var c = 0; c < n; c++)
        {
            for (var d = 0; d < n; d++)
            {
                cdArray[c * d + d] = c + d;
            }
        }

        for (var a = 0; a < n; a++)
        {
            for (var b = 0; b < n; b++)
            {
                var xd = m - x[a] + x[b];
                var d = x.BinarySearch(xd);
                if (d >= 0)
                {
                    Console.WriteLine(IOLibrary.ToYesOrNo(true));
                }
            }
        }

        Console.WriteLine(IOLibrary.ToYesOrNo(false));
    }

    #endregion

    public static void Method()
    {

    }
}
