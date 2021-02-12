using System;
using System.Collections.Generic;
using System.Linq;

public struct IndexValue<T>
{
    public IndexValue(T value, int index)
    {
        this.Value = value;
        this.Index = index;
    }

    public T Value { get; }

    public int Index { get; }
}