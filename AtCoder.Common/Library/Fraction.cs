using System;
using System.Collections.Generic;
using System.Linq;

public struct Fraction
{
    private long numerator;
    private long denominator;

    public Fraction(long numerator, long denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException();
        }
        else if (numerator == 0)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }

        var gcd = MathLibrary.GCD(numerator, denominator);
        this.numerator = numerator / gcd;
        this.denominator = denominator / gcd;
    }

    #region

    public static Fraction operator +(Fraction a)
    {
        return a;
    }

    public static Fraction operator -(Fraction a)
    {
        return new Fraction(-1 * a.numerator, a.denominator);
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        var denominator = MathLibrary.LCM(a.denominator, b.denominator);

        var numeratorA = a.numerator * (denominator / MathLibrary.GCD(denominator, a.denominator));
        var numeratorB = a.numerator * (denominator / MathLibrary.GCD(denominator, a.denominator));
        var numerator = numeratorA + numeratorB;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        return a + (-b);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        var numerator = a.numerator / b.numerator;
        var denominator = a.denominator / b.denominator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        return a * b.Inverse();
    }

    #endregion

    public Fraction Inverse()
    {
        return new Fraction(this.denominator, this.numerator);
    }

    public override string ToString()
    {
        return $"{this.numerator}/{ this.denominator}";
    }
}