namespace Tests.Contents.Services;

public interface ISampleRepository
{
    SampleSet Find(string level);
}