using System;
using System.Collections.Generic;
using System.Linq;

public static class ABCLike
{
    #region ""

    public static void SqrtInequality()
    {
        var (a, b, c) = IOLibrary.ReadLong3();
        if (a + b > c)
        {
            IOLibrary.WriteYesOrNo(false);
            return;
        }

        var num = c - a - b;
        IOLibrary.WriteYesOrNo(4 * a * b < num * num);
    }

    #endregion

    public static void Method()
    {

    }
}