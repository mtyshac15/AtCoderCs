using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Search
{
    #region ""

    public static void OneZeroFive()
    {
        var N = IOLibrary.ReadInt();

        var count = 0;
        for (var i = 1; i <= N; i += 2)
        {
            var divisorList = MathLibrary.GetDivisorList(i);
            if (divisorList.Count() == 8)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }

    public static void UnevenNumbers()
    {
        var N = IOLibrary.ReadInt();
        var count = Enumerable.Range(1, N)
                            .Select(num => MathLibrary.Digits(num))
                            .Count(num => num % 2 == 1);
        Console.WriteLine(count);
    }

    public static void BreakNumbers()
    {

    }

    public static void GoodDistance()
    {
        var (N, D) = IOLibrary.ReadInt2();
        var X = IOLibrary.ReadInt2DArray(N, D);

        var count = 0L;
        foreach (var pair in MathLibrary.GetCombinationIndexCollection(N, 2))
        {
            var i = pair[0];
            var j = pair[1];

            var squareLength = 0L;
            for (var index = 0; index < D; index++)
            {
                var dx = X[i, index] - X[j, index];
                squareLength += dx * dx;
            }
            var length = (int)Math.Sqrt(squareLength);
            if (length * length == squareLength)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }

    #endregion

    #region 

    public static void TaxRate()
    {

    }

    public static void CakesAndDonuts()
    {
        var N = IOLibrary.ReadInt();
        var cakeCost = 4;
        var doughnutCost = 7;

        for (var cakeNum = 0; cakeNum < N; cakeNum++)
        {
            for (var doughnutNum = 0; doughnutNum < N; doughnutNum++)
            {
                var total = cakeCost * cakeNum + doughnutCost * doughnutNum;
                if (total == N)
                {
                    Console.WriteLine(IOLibrary.YesOrNo(true));
                    return;
                }
            }
        }

        Console.WriteLine(IOLibrary.YesOrNo(true));
    }

    public static void GuessTheNumber()
    {

    }

    #endregion

    public static void Method()
    {

    }
}
