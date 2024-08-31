namespace AtCoderCs.Common.ValueObjects;

/// <summary>
/// ディレクトリ用の値オブジェクトクラスです。
/// </summary>
public class SampleDirectory : ValueObjectBase
{
    private readonly DirectoryInfo _directory;

    private SampleDirectory(DirectoryInfo directory)
    {
        _directory = directory;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _directory.FullName;
    }

    /// <summary>
    /// パスの結合
    /// </summary>
    /// <param name="relativePath"></param>
    /// <returns></returns>
    public DirectoryInfo Combine(string relativePath)
    {
        return new DirectoryInfo(Path.Combine(_directory.FullName, relativePath));
    }

    public static implicit operator string(SampleDirectory directory)
    {
        return directory._directory.FullName;
    }

    public static SampleDirectory Create(DirectoryInfo directory)
    {
        if (!Directory.Exists(directory.FullName))
        {
            throw new DirectoryNotFoundException();
        }

        return new SampleDirectory(directory);
    }
}
