namespace AtCoderCsTest.Contents.Services;

[AttributeUsage(AttributeTargets.Class)]
public class SampleAttribute : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public SampleAttribute(params string[] args)
    {
        Directory = Path.Combine(args.Where(e => !string.IsNullOrWhiteSpace(e)).ToArray());
    }

    public string Directory { get; }

    public override string ToString()
    {
        return $"{this.Directory}";
    }
}
