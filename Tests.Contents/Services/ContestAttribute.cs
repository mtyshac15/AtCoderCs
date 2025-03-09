namespace Tests.Contents.Services;

[AttributeUsage(AttributeTargets.Class)]
public class ContestAttribute : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="section"></param>
    /// <param name="number"></param>
    public ContestAttribute(string section, string number)
    {
        Section = section;
        Number = number;
    }

    /// <summary>
    /// コンテストの種別を取得します。
    /// </summary>
    public string Section { get; }

    /// <summary>
    /// コンテストの番号を取得します。
    /// </summary>
    public string Number { get; }

    public override string ToString()
    {
        return $"{this.Section} {this.Number}";
    }
}
