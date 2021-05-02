using System;
using System.Collections.Generic;
using System.Linq;

public struct Cell : IEquatable<Cell>
{
    public Cell(long row, long column)
    {
        this.Row = row;
        this.Column = column;
    }

    public long Row { get; }

    public long Column { get; }

    #region 

    public static bool operator ==(Cell cell1, Cell cell12)
    {
        return cell1.Equals(cell12);
    }

    public static bool operator !=(Cell cell1, Cell cell12)
    {
        return !(cell1 == cell12);
    }

    #endregion

    public bool Equals(Cell other)
    {
        return this.Row == other.Row && this.Column == other.Column;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Cell))
        {
            return false;
        }

        return this.Equals((Cell)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Row, this.Column);
    }

    public override string ToString()
    {
        return $"({this.Row}, {this.Column})";
    }
}