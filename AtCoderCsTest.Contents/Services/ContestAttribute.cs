namespace AtCoderCsTest.Contents.Services;

[AttributeUsage(AttributeTargets.Class)]
public class ContestAttribute : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="section"></param>
    /// <param name="args"></param>
    public ContestAttribute(string section, string prnubmer)
    {
        Section = section;
        Number = prnubmer;
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
