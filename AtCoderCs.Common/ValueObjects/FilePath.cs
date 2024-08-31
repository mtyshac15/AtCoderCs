namespace AtCoderCs.Common.ValueObjects;

/// <summary>
/// ファイルパスクラスです。
/// </summary>
public class FilePath : ValueObjectBase
{
    private FileInfo _file;

    public FilePath(FileInfo file)
    {
        _file = file;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _file.FullName;
    }

    public SampleDirectory GetParentDirectory()
    {
        return SampleDirectory.Create(_file.Directory!);
    }

    /// <summary>
    /// ファイル名を取得
    /// </summary>
    /// <returns></returns>
    public string GetFileName()
    {
        return _file.Name;
    }

    public static implicit operator string(FilePath filePath)
    {
        return filePath._file.FullName;
    }

    public static FilePath Create(FileInfo file)
    {
        if (!File.Exists(file.FullName))
        {
            throw new DirectoryNotFoundException();
        }

        return new FilePath(file);
    }

    public static FilePath Create(SampleDirectory directory, string fileName)
    {
        var path = Path.Combine(directory, fileName);
        return FilePath.Create(new FileInfo(path));
    }
}
