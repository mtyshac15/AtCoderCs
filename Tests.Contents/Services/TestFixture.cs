namespace Tests.Contents.Services;

public class TestFixture
{
    private static readonly string _solutionName = "AtCoderCs.sln";
    private static DirectoryInfo _solutionDirectory;

    static TestFixture()
    {
        var directory = new DirectoryInfo(Environment.CurrentDirectory);
        _solutionDirectory = GetDirectory(directory, _solutionName);
    }

    public TestFixture()
    {
    }

    public DirectoryInfo GetBaseDirectory(string contestSection, string problemFolder, string problemNumber)
    {
        var array = new string[]
        {
            $"Sample",
            contestSection,
            problemFolder,
            problemNumber,
        }.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

        var sampleFolder = Path.Combine(array);
        var fullPath = Path.Combine(_solutionDirectory.FullName, sampleFolder);
        return new DirectoryInfo(fullPath);
    }

    public ISampleRepository GetSampleRepository(string contestSection, string problemFolder, string problemNumber)
    {
        var baseDirectory = GetBaseDirectory(contestSection, problemFolder, problemNumber);
        return new SampleRepository(baseDirectory, problemNumber);
    }

    private static DirectoryInfo GetDirectory(DirectoryInfo directory, string fileName)
    {
        var path = Path.Combine(directory.FullName, fileName);
        if (File.Exists(path))
        {
            return directory;
        }

        if (directory.Parent != null)
        {
            return GetDirectory(directory.Parent, fileName);
        }

        throw new DirectoryNotFoundException();
    }
}