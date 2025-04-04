namespace AtCoderCsTest.Contents.Services;

public class TestResult
{
    public TestResult(int index, string expected, string actual)
    {
        this.Number = index;
        this.Expected = expected;
        this.Actual = actual;
    }

    public int Number { get; }

    public string Expected { get; }

    public string Actual { get; }

    public IReadOnlyCollection<TestResult> CalcDetailErrors(decimal epsilon)
    {
        var expectedValues = this.Expected.Split();
        var actuaValues = this.Actual.Split();

        var errors = new List<TestResult>();

        foreach (var item in actuaValues.Zip(expectedValues))
        {
            decimal.TryParse(item.First, out decimal actualValue);
            decimal.TryParse(item.Second, out decimal expectedValue);

            var sub = Math.Abs(expectedValue - actualValue);
            if (sub > epsilon)
            {
                errors.Add(new TestResult(this.Number, expectedValue.ToString(), actualValue.ToString()));
            }
        }

        return errors;
    }
}
