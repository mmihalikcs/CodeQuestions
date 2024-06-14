using Distributions.Implementations;
using Distributions.Interface;

namespace Distributions.Test
{
    public class LogNormalDistributionTests
    {
        // Fact based unit test
        [Fact]
        public void LogNormal_CalculateNormal_WithSuccessfulControlValues()
        {
            IContinuousProbabilityDistribution logNormalDistro = new LogNormalDistribution(3, 1.5);
            Assert.True(logNormalDistro.Mean == 42.5211);
            Assert.True(logNormalDistro.Variance == 6295.0415);
            Assert.True(logNormalDistro.PDF(3.6) == 0.0338);
        }

        [Fact]
        public void LogNormal_CalculateNormal_WithSuccessfulUpperBound()
        {
            IContinuousProbabilityDistribution logNormalDistro = new LogNormalDistribution(3, 0.1);
            Assert.True(logNormalDistro.Mean == 21.1153);
            Assert.True(logNormalDistro.Variance == 46.8913);
            Assert.True(logNormalDistro.PDF(3.6) == 0);
        }

        [Fact]
        public void LogNormal_CalculateNormal_WithSigmaEqualZero()
        {
            var testAction = () =>
            {
                IContinuousProbabilityDistribution logNormalDistro = new NormalDistribution(3, 0.0);
            };
            Assert.Throws<ArgumentException>("sigmaSquared", testAction);
        }

        [Fact]
        public void LogNormal_CalculateNormal_WithSigmaLessThanZero()
        {
            var testAction = () =>
            {
                IContinuousProbabilityDistribution logNormalDistro = new NormalDistribution(3, -1.0);
            };
            Assert.Throws<ArgumentException>("sigmaSquared", testAction);
        }

        // Theory Tests
        // Multiple values
        [Theory]
        [InlineData(3, 1.5, 3.6, 42.5211, 6295.0415, 0.0338)]
        [InlineData(8, 4, 4.2, 22026.4658, 26003956934.4336, 0.0002)]
        [InlineData(23, 12, 1.0, 3931334297144.0361, 2.5154232155298019E+30, 0)]
        public void LogNormal_CalculateLogNormal_WithMyInputValuesValues(double mu, double sigmaSquared, double x, double expectedMean, double expectedVariance,  double pdfResult)
        {
            IContinuousProbabilityDistribution logNormalDistro = new LogNormalDistribution(mu, sigmaSquared);
            Assert.True(logNormalDistro.Mean == expectedMean);
            Assert.True(logNormalDistro.Variance == expectedVariance);
            Assert.True(logNormalDistro.PDF(x) == pdfResult);
        }
    }
}