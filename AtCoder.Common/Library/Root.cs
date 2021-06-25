using System;
using System.Collections.Generic;
using System.Linq;

public struct Root
{
    private long a;
    private long numerator;
    private long denominator;

    public Root(long a, long numerator, long denominator)
    {
        this.a = a;
        this.numerator = numerator;
        this.denominator = denominator;
    }
}