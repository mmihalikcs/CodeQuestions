using Distributions.Implementations;
using Distributions.Interface;
using NuGet.Frameworks;

namespace Distributions.Test
{
    public class NormalDistributionTests
    {
        // Fact based unit test
        [Fact]
        public void Normal_CalculateNormal_WithSuccessfulControlValues()
        {
            IContinuousProbabilityDistribution normalDistro = new NormalDistribution(3, 1.5);
            Assert.True(normalDistro.Mean == 3);
            Assert.True(normalDistro.Variance == 1.5);
            Assert.True(normalDistro.PDF(3.6) == 0.2889);
        }

        [Fact]
        public void Normal_CalculateNormal_WithSuccessfulUpperBound()
        {
            IContinuousProbabilityDistribution normalDistro = new NormalDistribution(3, 0.1);
            Assert.True(normalDistro.Mean == 3);
            Assert.True(normalDistro.Variance == 0.1);
            Assert.True(normalDistro.PDF(3.6) == 0.2085);
        }

        [Fact]
        public void Normal_CalculateNormal_WithSigmaEqualZero()
        {
            var testAction = () =>
            {
                IContinuousProbabilityDistribution normalDistro = new NormalDistribution(3, 0.0);
            };
            Assert.Throws<ArgumentException>("sigmaSquared", testAction);
        }

        [Fact]
        public void Normal_CalculateNormal_WithSigmaLessThanZero()
        {
            var testAction = () =>
            {
                IContinuousProbabilityDistribution normalDistro = new NormalDistribution(3, -1.0);
            };
            Assert.Throws<ArgumentException>("sigmaSquared", testAction);
        }

        // Theory Tests
        // Multiple values
        [Theory]
        [InlineData(3, 1.5, 3.6, 0.2889)]
        [InlineData(8, 4, 4.2, 0.0328)]
        [InlineData(23, 12, 1.0, 0)]
        [InlineData(2, 9, 3, 0.1258)]
        public void Normal_CalculateNormal_WithMyInputValuesValues(double mu, double sigmaSquared, double x, double pdfResult)
        {
            IContinuousProbabilityDistribution normalDistro = new NormalDistribution(mu, sigmaSquared);
            Assert.True(normalDistro.Mean == mu);
            Assert.True(normalDistro.Variance == sigmaSquared);
            Assert.True(normalDistro.PDF(x) == pdfResult);
        }
    }
}