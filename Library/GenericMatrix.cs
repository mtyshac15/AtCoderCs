using System;
using System.Collections.Generic;
using System.Linq;

public struct GenericMatrix<T>
{
    private T[] array;

    public GenericMatrix(long row, long col)
    {
        this.RowCount = row;
        this.ColumnCount = col;
        this.array = new T[row * col];
    }

    #region 

    #endregion

    public long RowCount { get; }

    public long ColumnCount { get; }

    public T this[long row, long column]
    {
        get
        {
            var index = this.ColumnCount * row + column;
            return this.array[index];
        }
    }

    public void Init(long rowIndex, T[] rowItem)
    {
        if (rowItem.Length != this.ColumnCount)
        {
            throw new InvalidOperationException();
        }

        for (var i = 0; i < rowItem.Length; i++)
        {
            var index = rowItem.Length * rowIndex + i;
            this.array[index] = rowItem[i];
        }
    }

    public T[] GetRow(long rowIndex)
    {
        var vector = new T[this.ColumnCount];
        for (var i = 0; i < vector.Length; i++)
        {
            vector[i] = this[rowIndex, i];
        }
        return vector;
    }

    public T[] GetColumn(long colIndex)
    {
        var vector = new T[this.RowCount];
        for (var i = 0; i < vector.Length; i++)
        {
            var rowIndex = this.ColumnCount * i + colIndex;
            vector[i] = this[rowIndex, colIndex];
        }
        return vector;
    }
}