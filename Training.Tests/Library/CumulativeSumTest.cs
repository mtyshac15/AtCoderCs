using System.ComponentModel;
using Xunit;
using Xunit.Abstractions;

namespace Training.Tests.Library
{
    [Trait("Category", "learning")]
    public class CumulativeSumTest
    {
        private ITestOutputHelper _output;

        public CumulativeSumTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void _1次元の累積和()
        {
            _output.WriteLine("Arrange");
            var N = 5;
            var K = 3;
            var array = new int[] { 2, 5, -4, 10, 3 };

            _output.WriteLine("Act");
            var sum = new int[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                sum[i + 1] = sum[i] + array[i];
            }

            var max = int.MinValue;
            for (int i = 0; i < sum.Length - K; i++)
            {
                max = Math.Max(sum[i + K] - sum[i], max);
            }

            _output.WriteLine("Assert");
            var ans = max;
            Assert.Equal(11, ans);
        }
    }
}
