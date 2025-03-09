namespace Tests.Contents.Services;

class SampleRepository : ISampleRepository
{
    private static readonly string _baseFileName = "Sample";

    private DirectoryInfo _baseDirectory;
    private string _problemNumber;

    private SampleSet? _sampleSet;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="baseDirectory"></param>
    /// <param name="problemNumber"></param>
    public SampleRepository(DirectoryInfo baseDirectory, string problemNumber)
    {
        _baseDirectory = baseDirectory;
        _problemNumber = problemNumber;
    }

    public SampleSet Find(string level)
    {
        if (_sampleSet is null)
        {
            var fileName = $"{_baseFileName}{_problemNumber}{level}.txt";
            var filePath = new FileInfo(Path.Combine(_baseDirectory.FullName, fileName));
            _sampleSet = SampleSet.LoadSample(filePath);
        }

        return _sampleSet;
    }
}
