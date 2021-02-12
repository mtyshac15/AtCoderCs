using System;
using System.Collections.Generic;
using System.Linq;

public struct Matrix
{
    private GenericMatrix<long> matrix;

    public Matrix(long row, long col)
    {
        this.matrix = new GenericMatrix<long>(row, col);
    }

    #region 

    public long RowCount
    {
        get { return this.matrix.RowCount; }
    }

    public long ColumnCount
    {
        get { return this.matrix.ColumnCount; }
    }

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
        if (a.RowCount != b.RowCount || a.ColumnCount != b.ColumnCount)
        {
            throw new InvalidOperationException();
        }

        var result = new Matrix(a.RowCount, a.ColumnCount);

        for (var rowIndex = 0; rowIndex < a.RowCount; rowIndex++)
        {
            var rowItem = a.GetRow(rowIndex).Zip(b.GetRow(rowIndex), (elementA, elementB) => elementA + elementB)
                                            .ToArray();
            result.Init(rowIndex, rowItem);
        }
        return result;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        return a + (-b);
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.ColumnCount != b.RowCount)
        {
            throw new InvalidOperationException();
        }

        var result = new Matrix(a.RowCount, b.ColumnCount);
        for (var rowIndex = 0; rowIndex < a.RowCount; rowIndex++)
        {
            var rowItem = new long[result.ColumnCount];
            var vectorA = a.GetRow(rowIndex);

            for (var columnIndex = 0; columnIndex < b.ColumnCount; columnIndex++)
            {
                var vectorB = b.GetColumn(columnIndex);

                var index = a.ColumnCount * rowIndex + columnIndex;
                var value = vectorA.Zip(vectorB, (elementA, elementB) => elementA * elementB)
                                   .Sum();
                rowItem[index] = value;
            }
            result.Init(rowIndex, rowItem);
        }

        return result;
    }

    public static Matrix operator *(long c, Matrix a)
    {
        var result = new Matrix(a.RowCount, a.ColumnCount);
        for (var rowIndex = 0; rowIndex < a.RowCount; rowIndex++)
        {
            var rowItem = a.GetRow(rowIndex);
            result.Init(rowIndex, rowItem.Select(element => element * c).ToArray());
        }
        return result;
    }

    public static Matrix operator *(Matrix a, long c)
    {
        return c * a;
    }

    #endregion

    public long this[long row, long column]
    {
        get { return this.matrix[row, column]; }
    }

    public void Init(long rowIndex, long[] rowItem)
    {
        this.matrix.Init(rowIndex, rowItem);
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
        return this.matrix.GetRow(rowIndex);
    }

    public long[] GetColumn(long colIndex)
    {
        return this.matrix.GetColumn(colIndex);
    }
}