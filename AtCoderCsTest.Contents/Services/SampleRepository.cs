namespace AtCoderCsTest.Contents.Services;

public class SampleRepository : ISampleRepository
{
    private static readonly string _baseFileName = "TestSample";

    private DirectoryInfo _baseDirectory;

    private SampleSet? _sampleSet;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="baseDirectory"></param>
    public SampleRepository(DirectoryInfo baseDirectory)
    {
        _baseDirectory = baseDirectory;
    }

    public SampleSet Find(string problemNumber, string level)
    {
        var fileName = $"{_baseFileName}{problemNumber}{level}.txt";
        var filePath = new FileInfo(Path.Combine(_baseDirectory.FullName, fileName));
        _sampleSet = SampleSet.LoadSample(filePath);

        return _sampleSet;
    }
}
