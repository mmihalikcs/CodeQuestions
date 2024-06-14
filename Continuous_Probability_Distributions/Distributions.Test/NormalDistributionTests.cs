using Distributions.Implementations;
using Distributions.Interface;
using NuGet.Frameworks;

namespace Distributions.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Normal_CalculateNormal_WithSuccessfulControlValues()
        {
            IContinuousProbabilityDistribution normalDistro = new NormalDistribution(3, 1.5);
            Assert.True(normalDistro.Mean == 3);
            Assert.True(normalDistro.Variance == 1.5);
            Assert.True(normalDistro.PDF(3.6) == 0.2889);
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
    }
}