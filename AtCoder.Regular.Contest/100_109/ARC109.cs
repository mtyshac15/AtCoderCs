using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC109
{
    public class Problem : ProblemBase
    {
        public override void SolveA()
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

        public override void SolveB()
        {
            var n = IOLibrary.ReadLong();
            var cost = n;

            //1+・・・+k<=n+1を満たす最大のkを求める
            var dividedNum = MathLibrary.BinarySearch(0L,
                                                      n + 1,
                                                      (x) => x * (x + 1) / 2 <= n + 1);
            cost = cost - dividedNum + 1;
            IOLibrary.WriteLine(cost);
        }

        public override void SolveC()
        {
            var (n, k) = IOLibrary.ReadInt2();
            var s = IOLibrary.ReadLine();
            var queue = new Queue<char>(s);
            var gameCount = 0;

            while (k > 0)
            {
                queue = Problem.TwiceQueue(queue);

                var queueNum = queue.Count;
                while (queueNum > 0)
                {
                    var a = queue.Dequeue();
                    var b = queue.Dequeue();
                    queueNum -= 2;
                    var winner = Problem.Judge(a, b);
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

        public override void SolveD()
        {

        }

        public override void SolveE()
        {

        }

        public override void SolveF()
        {

        }
    }
}

