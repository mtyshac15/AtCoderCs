using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ARC100
{
    #region "109"

    public static void Hands()
    {
        var (a, b, x, y) = IOLibrary.ReadInt4();

        //1階分の移動時間
        var unitTime = Math.Min(2 * x, y);

        // 階数の差
        var floorDiff = (a > b) ? a - 1 - b : b - a;

        if (a == b)
        {
            Console.WriteLine(x);
        }
        else
        {
            var time = x + unitTime * floorDiff;
            Console.WriteLine(time);
        }
    }

    public static void Log()
    {
        var n = IOLibrary.ReadLong();
        var cost = n;

        //n+1の分割
        var ng = n + 1;
        var ok = 0L;

        //1+・・・+k<=n+1を満たす最大のkを求める
        while (Math.Abs(ok - ng) > 1)
        {
            var middle = ok + (ng - ok) / 2;
            //1からkまでの和
            var sum = middle * (middle + 1) / 2;
            if (sum <= n + 1)
            {
                ok = middle;
            }
            else
            {
                ng = middle;
            }
        }

        var dividedNum = ok;
        cost = cost - dividedNum + 1;
        Console.WriteLine(cost);
    }

    public static void LargeRPSTournament()
    {
        var (n, k) = IOLibrary.ReadInt2();
        var s = IOLibrary.ReadLine();
        var queue = new Queue<char>(s);
        var gameCount = 0;

        while (k > 0)
        {
            queue = ARC100.TwiceQueue(queue);

            var queueNum = queue.Count;
            while (queueNum > 0)
            {
                var a = queue.Dequeue();
                var b = queue.Dequeue();
                queueNum -= 2;
                var winner = ARC100.Judge(a, b);
                gameCount++;
                queue.Enqueue(winner);
            }

            if (gameCount >= k)
            {
                //第i回戦終了
                k--;
                gameCount = 0;
            }
        }

        var champion = queue.Dequeue();
        Console.WriteLine(champion);
    }

    public static char Judge(char a, char b)
    {
        if (a == b)
        {
            return a;
        }
        else if (a == 'R' && b == 'S'
            || a == 'S' && b == 'P'
            || a == 'P' && b == 'R')
        {
            return a;
        }

        return b;
    }

    public static Queue<T> TwiceQueue<T>(Queue<T> source)
    {
        var newQueue = new Queue<T>(source);
        foreach (var item in source)
        {
            newQueue.Enqueue(item);
        }
        return newQueue;
    }

    #endregion

    #region "108"

    public static void SumAndProduct()
    {
        var (S, P) = IOLibrary.ReadLong2();

        for (var N = 1L; N * N <= P; N++)
        {
            var M = P - N;
            if (N * M == S)
            {
                Console.WriteLine(IOLibrary.YesOrNo(true));
                return;
            }
        }

        Console.WriteLine(IOLibrary.YesOrNo(false));
    }

    public static void AbbreviateFox()
    {
        var N = IOLibrary.ReadInt();
        var s = IOLibrary.ReadLine();
        var t = new List<char>(N);

        foreach (var str in s)
        {
            t.Add(str);

            if (t.Count >= 3)
            {
                if (t[t.Count - 3] == 'f' && t[t.Count - 2] == 'o' && t[t.Count - 1] == 'x')
                {
                    t.RemoveAt(t.Count - 1);
                    t.RemoveAt(t.Count - 1);
                    t.RemoveAt(t.Count - 1);
                }
            }
        }

        Console.WriteLine(t.Count);
    }

    #endregion
}
