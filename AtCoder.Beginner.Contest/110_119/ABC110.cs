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
}