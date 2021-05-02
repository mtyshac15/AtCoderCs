using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC193
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {
            var (A, B) = IOLibrary.ReadInt2();
            var ans = (decimal)(A - B) * 100 / A;
            Console.WriteLine(ans);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var min = long.MaxValue;

            var A = new long[N];
            var P = new long[N];
            var X = new long[N];

            for (var i = 0; i < N; i++)
            {
                var array = IOLibrary.ReadLongArray();
                A[i] = array[0];
                P[i] = array[1];
                X[i] = array[2];
            }

            var sortedA = A.Select((a, index) => new
            {
                Value = a,
                Index = index,
            }).Shuffle()
              .OrderBy(e => e.Value);

            var hasBaught = false;
            foreach (var a in sortedA)
            {
                var index = a.Index;

                var time = a.Value + 0.5m;

                var reminder = X[index] - (int)time;
                if (reminder > 0)
                {
                    min = Math.Min(min, P[index]);
                    hasBaught = true;
                }
            }

            var ans = hasBaught ? min : -1;
            Console.WriteLine(ans);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveC()
        {
            var N = IOLibrary.ReadLong();

            var hashSet = new HashSet<long>();
            var max = (long)Math.Sqrt(N);

            for (var i = 2L; i <= max + 1; i++)
            {
                var e = i * i;
                while (e <= N)
                {
                    hashSet.Add(e);
                    e *= i;
                }
            }

            var ans = N - hashSet.Count;
            Console.WriteLine(ans);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveD()
        {
            var K = IOLibrary.ReadInt();
            var S = IOLibrary.ReadLine();
            var T = IOLibrary.ReadLine();

            var cardSArray = S.Take(4)
                              .Select(x => int.Parse(x.ToString()));

            var cardTArray = T.Take(4)
                              .Select(x => int.Parse(x.ToString()));

            var usedCards = Enumerable.Repeat(0, 9).ToArray();

            foreach (var card in cardSArray.Concat(cardTArray))
            {
                usedCards[card - 1]++;
            }

            var num = 10;
            var count = 0L;
            for (var i = 1; i < num; i++)
            {
                //既に使われている枚数
                var newCardSArray = cardSArray.Append(i);
                if (usedCards[i - 1] + 1 <= K)
                {
                    for (var j = 1; j < num; j++)
                    {
                        var newCardTArray = cardTArray.Append(j);
                        if (usedCards[j - 1] + 1 <= K)
                        {
                            //得点計算
                            var scoreS = 0L;
                            var scoreT = 0L;
                            for (var card = 1; card < num; card++)
                            {
                                {
                                    var c = newCardSArray.Count(x => x == card);
                                    scoreS += card * MathLibrary.Pow(10, c);
                                }

                                {
                                    var c = newCardTArray.Count(x => x == card);
                                    scoreT += card * MathLibrary.Pow(10, c);
                                }
                            }

                            if (scoreS > scoreT)
                            {
                                if (i == j)
                                {
                                    count += MathLibrary.Permutation(K - usedCards[i - 1], 2);
                                }
                                else
                                {
                                    count += (long)(K - usedCards[i - 1]) * (K - usedCards[j - 1]);
                                }
                            }
                        }
                    }
                }
            }

            var total = MathLibrary.Permutation(9 * K - 8, 2);
            var ans = (decimal)count / total;
            Console.WriteLine(ans);
        }

        #region 

        public void SolveDOld()
        {
            var K = IOLibrary.ReadInt();
            var S = IOLibrary.ReadLine();
            var T = IOLibrary.ReadLine();

            var cardSArray = S.Take(4)
                              .Select(x => int.Parse(x.ToString()));

            var cardTArray = T.Take(4)
                              .Select(x => int.Parse(x.ToString()));

            var allCards = Enumerable.Range(1, 9)
                                     .ToDictionary(x => x, x => K);

            //現在使われている枚数
            var usedCardNums = Enumerable.Range(1, 9)
                                         .ToDictionary(x => x, x => 0);

            foreach (var card in cardSArray.Concat(cardTArray))
            {
                usedCardNums[card]++;
            }

            var winList = MathLibrary.CreateList(new { S = 0, T = 0 });

            for (var i = 0; i < 9; i++)
            {
                var numS = i + 1;
                var reminderNumS = K - usedCardNums[numS];
                if (reminderNumS > 0)
                {
                    var scoreS = 0L;
                    var newCardSArray = cardSArray.Append(numS)
                                                  .GroupBy(x => x)
                                                  .ToArray();

                    foreach (var card in Enumerable.Range(1, 9))
                    {
                        if (newCardSArray.Any(x => x.Key == card))
                        {
                            var c = newCardSArray.FirstOrDefault(x => x.Key == card).Count();
                            scoreS += card * MathLibrary.Pow(10, c);
                        }
                        else
                        {
                            scoreS += card;
                        }
                    }

                    reminderNumS--;

                    for (var j = 0; j < 9; j++)
                    {
                        var numT = j + 1;

                        if (!(numS == numT && reminderNumS > 0))
                        {
                            var reminderNumT = K - usedCardNums[numS];
                            if (reminderNumT > 0)
                            {
                                var scoreT = 0L;
                                var newCardTArray = cardTArray.Append(numT)
                                                              .GroupBy(x => x)
                                                              .ToArray();

                                foreach (var card in Enumerable.Range(1, 9))
                                {
                                    if (newCardTArray.Any(x => x.Key == card))
                                    {
                                        var c = newCardTArray.FirstOrDefault(x => x.Key == card).Count();
                                        scoreT += card * MathLibrary.Pow(10, c);
                                    }
                                    else
                                    {
                                        scoreT += card;
                                    }
                                }

                                if (scoreS > scoreT)
                                {
                                    winList.Add(new { S = numS, T = numT });
                                }
                            }
                        }
                    }
                }
            }

            var remainderCards = allCards.Zip(usedCardNums, (e1, e2) => e1.Value - e2.Value).ToList();
            var total = MathLibrary.Combination(remainderCards.Sum(), 2);
            var ans = 0m;

            foreach (var cards in winList)
            {
                if (cards.S == cards.T)
                {
                    ans += 2m / total;
                }
                else
                {
                    ans += 1m / total;
                    ans += 1m / (total - 1);
                }
            }

            Console.WriteLine(ans);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public override void SolveE()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveF()
        {

        }
    }
}