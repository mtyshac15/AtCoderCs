using System;
using System.Collections.Generic;
using System.Linq;

public struct Matrix
{
    private long[] array;
    private long row;
    private long column;

    public Matrix(long row, long col)
    {
        this.row = row;
        this.column = col;
        this.array = new long[row * col];
    }

    #region 

    public static Matrix operator +(Matrix a)
    {
        return a;
    }

    public static Matrix operator -(Matrix a)
    {
        return -1 * a;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.row != b.row || a.column != b.column)
        {
            throw new InvalidOperationException();
        }

        var result = new Matrix(a.row, a.column);
        var newArray = a.array.Zip(b.array, (elementA, elementB) => elementA + elementB)
                        .ToArray();
        result.array = newArray;
        return result;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        return a + (-b);
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.column != b.row)
        {
            throw new InvalidOperationException();
        }

        var result = new Matrix(a.row, b.column);
        var newArray = new long[result.array.Length];
        for (var i = 0; i < a.row; i++)
        {
            var vectorA = a.GetRow(i);

            for (var j = 0; j < b.column; j++)
            {
                var vectorB = b.GetColumn(j);

                var index = a.column * i + j;
                var value = vectorA.Zip(vectorB, (elementA, elementB) => elementA * elementB)
                                   .Sum();
                newArray[index] = value;
            }
        }

        result.array = newArray;
        return result;
    }

    public static Matrix operator *(long c, Matrix a)
    {
        var result = new Matrix(a.row, a.column);
        var newArray = a.array.Select(element => element * c)
                        .ToArray();
        result.array = newArray;
        return result;
    }

    public static Matrix operator *(Matrix a, long c)
    {
        return c * a;
    }

    #endregion

    public long this[long row, long column]
    {
        get
        {
            var index = this.column * row + column;
            return this.array[index];
        }
    }

    public void Init(long rowIndex, long[] rowItem)
    {
        for (var i = 0; i < this.row; i++)
        {
            var index = this.column * rowIndex + i;
            this.array[index] = rowItem[i];
        }
    }

    /// <summary>
    /// 行列式
    /// </summary>
    /// <returns></returns>
    public long Determinant()
    {
        return 0;
    }

    public long[] GetRow(long rowIndex)
    {
        var vector = new long[this.column];
        for (var i = 0; i < vector.Length; i++)
        {
            vector[i] = this[rowIndex, i];
        }
        return vector;
    }

    public long[] GetColumn(long colIndex)
    {
        var vector = new long[this.row];
        for (var i = 0; i < vector.Length; i++)
        {
            var rowIndex = this.column * i + colIndex;
            vector[i] = this[rowIndex, colIndex];
        }
        return vector;
    }
}