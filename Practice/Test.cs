using System;
using System.Collections.Generic;
using System.Linq;

static class Test
{
    public static System.Random Random = new System.Random();

    public static void Execute()
    {
        var array = MathLibrary.GetDivisorSortedList(25);
        Test.Output(array);
    }

    public static void Knapsack()
    {
        var N = Test.Random.Next(1000, 10000);
        var W = (long)Test.Random.Next(100, 20000);

        var wheightArray = Enumerable.Repeat(0, N)
                                .Select(item => Test.Random.Next(1, 100))
                                .ToArray();

        var valueArray = Enumerable.Repeat(0, N)
                              .Select(item => Test.Random.Next(1, 100))
                              .ToArray();

        var dp = new long[N + 1, W + 1];

        var count = 0L;

        for (var i = 0; i < N; i++)
        {
            for (var w = 0; w < W + 1; w++)
            {
                if (w >= wheightArray[i])
                {
                    var tempValue = dp[i, w - wheightArray[i]] + valueArray[i];
                    dp[i + 1, w] = Math.Max(tempValue, dp[i, w]);
                }
                else
                {
                    dp[i + 1, w] = dp[i, w];
                }

                count++;
            }
        }

        Console.WriteLine();

        Console.WriteLine($"総数:{N}");
        Console.WriteLine($"重量:{W}");

        Console.WriteLine($"解:{dp[N, W]}");
        Console.WriteLine($"計算量:{count}");

        //入っているもの
        var totalWeight = W;
        var totalValue = dp[N, W];

        var indexList = new List<int>();
        for (var i = N - 1; i >= 0; i--)
        {
            if (dp[i, totalWeight] < dp[i + 1, totalWeight])
            {
                //i番目が入っている場合
                indexList.Add(i);
                totalWeight -= wheightArray[i];
                totalValue -= valueArray[i];
            }
        }

        Console.WriteLine($"個数:{indexList.Count}");
    }

    public static void Traveling()
    {
        //都市の作成
        var N = 20;

        var cityNums = Enumerable.Range(0, N);

        var lengthList = new double[N, N];

        //各都市間の距離を設定
        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < N; j++)
            {
                if (i != j)
                {
                    lengthList[i, j] = Test.Random.Next(1, 10000);
                }
            }
        }

        //個体生成
        var geneticNum = 15;
        var geneticList = new int[geneticNum][];
        var circleGeneticList = new int[geneticNum][];
        for (var i = 0; i < geneticList.Length; i++)
        {
            var path = cityNums.Shuffle().ToArray();
            geneticList[i] = path;

            //最初の要素を最後に追加
            circleGeneticList[i] = path.Concat(new int[] { path.First() }).ToArray();
        }

        //各個体の距離を算出し、距離の逆数のテーブルを作成
        var inversePathList = circleGeneticList.Select(item => 1 / Test.SumPath(item, lengthList)).ToArray();
        var min = inversePathList.Min();
        inversePathList = inversePathList.Select(item => item / min).ToArray();

        //親を抽選
        var nextGenes = Test.RouletteChoices(inversePathList);
        var parents = nextGenes.Select(index => geneticList[index]).ToArray();

        //次世代
        var children = Test.PartialCrossOver(parents);
        var a = 0;
    }

    private static double SumPath(int[] path, double[,] pathTable)
    {
        var sum = 0d;
        for (var i = 0; i < path.Length - 1; i++)
        {
            sum += pathTable[path[i], path[i + 1]];
        }
        return sum;
    }

    private static double[] GenerateRoulette(double[] fitnessTabe)
    {
        var total = fitnessTabe.Sum();

        var rouletteTable = new double[fitnessTabe.Length];

        for (var i = 0; i < fitnessTabe.Length; i++)
        {
            rouletteTable[i] = fitnessTabe[i] / total;
        }

        return rouletteTable;
    }

    private static int RouletteChoice(double[] fitnessTabe)
    {
        var roulette = Test.GenerateRoulette(fitnessTabe);
        var chicedIndex = Test.GetRandomIndex(roulette);
        return chicedIndex;
    }

    private static int[] RouletteChoices(double[] fitnessTabe)
    {
        var choicedInexes = new int[2];

        var roulette = Test.GenerateRoulette(fitnessTabe);

        var chicedIndex0 = Test.GetRandomIndex(roulette);
        choicedInexes[0] = chicedIndex0;

        //異なる2つの個体を抽選
        while (true)
        {
            var chicedIndex1 = Test.GetRandomIndex(roulette);
            if (chicedIndex1 != chicedIndex0)
            {
                choicedInexes[1] = chicedIndex1;
                break;
            }
        }

        return choicedInexes;
    }

    /// <summary>
    /// 重み付き確率の抽選
    /// </summary>
    /// <param name="weightTable">重みを表す配列</param>
    /// <returns></returns>
    private static int GetRandomIndex(params double[] weightTable)
    {
        var retValue = 0;
        var intWeightTable = weightTable.Select(item => (int)(item * 1000)).ToArray();
        var totalWeight = intWeightTable.Sum();

        var value = Test.Random.Next(1, totalWeight + 1);

        for (var index = 0; index < weightTable.Length; index++)
        {
            if (value <= weightTable[index])
            {
                retValue = index;
                break;
            }

            value -= intWeightTable[index];
        }

        return retValue;
    }

    private static int[][] PartialCrossOver(int[][] parents)
    {
        var children = IOLibrary.DeepClone(parents);

        var children0 = children[0];
        var children1 = children[1];

        var index = Test.Random.Next(0, children0.Length);

        for (var i = index; i < children0.Length; i++)
        {
            var num0 = children0[i];
            var num1 = children1[i];

            //入れ替え
            var index0 = Array.IndexOf(children0, num1);
            children0.Swap(i, index0);

            var index1 = Array.IndexOf(children1, num0);
            children1.Swap(i, index1);
        }

        return children;
    }

    /// <summary>
    /// 配列のi番目とj番目を入れ替え
    /// </summary>
    /// <param name="array"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    public static void Swap(this int[] array, int i, int j)
    {
        var tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }

    public static void Output<T>(IList<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }

    public static void Timer(string text, Action method)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();

        method();

        sw.Stop();
        var secondTime = (int)(sw.Elapsed.TotalMilliseconds / 1000);
        Console.WriteLine($"{text}: {secondTime} 秒");
    }
}