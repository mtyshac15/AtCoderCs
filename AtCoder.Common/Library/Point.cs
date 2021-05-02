using System;
using System.Collections.Generic;
using System.Linq;

public struct Point
{
    public Point(double x, double y, double z = 0)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public double X { get; }

    public double Y { get; }

    public double Z { get; }

    #region

    public static Point operator +(Point a)
    {
        return a;
    }

    public static Point operator -(Point a)
    {
        return new Point(-a.X, -a.Y, -a.Z);
    }

    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Point operator -(Point a, Point b)
    {
        return a + (-b);
    }

    public static Point operator *(int k, Point a)
    {
        return new Point(k * a.X, k * a.Y, k * a.Z);
    }

    #endregion

    #region

    public static double CalcLength(Point a)
    {
        var length = Math.Sqrt(a.X * a.X + a.Y * a.Y + a.Z * a.Z);
        return length;
    }

    #region "Point"

    public static double CalcScalarProduct(Point a, Point b)
    {
        var product = a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        return product;
    }

    public static Point CalcVectorProduct(Point a, Point b)
    {
        var x = a.Y * b.Z - a.Z * b.Y;
        var y = a.Z * b.X - a.X * b.Z;
        var z = a.X * b.Y - a.Y * b.X;
        var p = new Point(x, y, z);
        return p;
    }

    /// <summary>
    /// OAとOBのなす角
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double CalcCosTheta(Point a, Point b)
    {
        var scalar = Point.CalcScalarProduct(a, b);
        var lengthA = Point.CalcLength(a);
        var lengthB = Point.CalcLength(b);
        var cos = scalar / (lengthA * lengthB);
        return cos;
    }

    /// <summary>
    /// 三角形OABの面積
    /// </summary>
    /// <returns></returns>
    public static double CalcTriangleArea(Point a, Point b)
    {
        var vectorProduct = Point.CalcVectorProduct(a, b);
        var length = Point.CalcLength(vectorProduct);
        var area = length / 2;
        return area;
    }

    #endregion

    #endregion
}