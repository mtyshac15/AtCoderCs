namespace AtCoderCsTest.Contents.Services;

public interface ISampleRepository
{
    SampleSet Find(string problemNumber, string level);
}