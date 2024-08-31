namespace AtCoderCs.Common.ValueObjects;

/// <summary>
/// 値オブジェクトのベースクラスです。
/// </summary>
public abstract class ValueObjectBase : IEquatable<ValueObjectBase>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    //比較演算子
    public static bool operator ==(ValueObjectBase left, ValueObjectBase right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }

        return ReferenceEquals(left, right) || left!.Equals(right);
    }

    public static bool operator !=(ValueObjectBase left, ValueObjectBase right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueObjectBase? other)
    {
        if (other is null || other.GetType() != this.GetType())
        {
            return false;
        }

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override bool Equals(object? obj)
    {
        return this.Equals(obj as ValueObjectBase);
    }

    /// <summary>
    /// 
    /// </summary>
    /// https://stackoverflow.com/questions/59375124/how-to-use-system-hashcode-combine-with-more-than-8-values
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var component in GetEqualityComponents())
        {
            hash.Add(component);
        }

        return hash.ToHashCode();
    }

    public override string ToString()
    {
        return string.Join(" ", this.GetEqualityComponents());
    }
}
