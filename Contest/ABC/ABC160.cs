using System;
using System.Collections.Generic;
using System.Linq;

public static class ABC160
{
    #region "167"

    public static void Registration()
    {
        var S = IOLibrary.ReadLine();
        var T = IOLibrary.ReadLine();
        var last = T[T.Length - 1];
        IOLibrary.WriteYesOrNo(S + last.ToString() == T);
    }

    #endregion

    public static void Method()
    {

    }
}