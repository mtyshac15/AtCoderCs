using System;
using System.Collections.Generic;
using System.Linq;

public static class ABC110
{
    #region "117"

    public static void Polygon()
    {
        var N = IOLibrary.ReadInt();
        var L = IOLibrary.ReadIntArray();

        var max = L.Max();
        var sum = L.Sum();

        IOLibrary.WriteYesOrNo(sum - max > max);
    }

    #endregion

    #region "116"

    public static void GrandGarden()
    {
        var N = IOLibrary.ReadInt();
        var h = IOLibrary.ReadIntArray();

        var ans = h.Zip(h.Prepend(0), (e1, e2) => e1 - e2)
                   .Where(e => e > 0)
                   .Sum();

        Console.WriteLine(ans);
    }

    #endregion

    public static void Method()
    {

    }
}