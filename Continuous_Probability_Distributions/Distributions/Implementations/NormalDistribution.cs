using Distributions.Interface;

namespace Distributions.Implementations
{
    public class NormalDistribution : IContinuousProbabilityDistribution
    {
        // Properties
        public double Mean => _mu;
        public double Variance => _sigmaSquared;

        // Fields
        double _mu = 0.0;
        double _sigmaSquared = 0.0;

        public NormalDistribution(double mu, double sigmaSquared)
        {
            _mu = mu;
            _sigmaSquared = sigmaSquared > 0? sigmaSquared : throw new ArgumentException("Value is not greater than zero", "sigmaSquared");
        }

        public double PDF(double x)
        {
            // Get the sigma value - since we have the square
            var sigma = Math.Sqrt(_sigmaSquared);
            // Lay out the formula
            var exponent = -(Math.Pow(x - _mu, 2) / (2 * _sigmaSquared));
            // Construct the formula
            var constructedFormula = (1 / (sigma * Math.Sqrt(2*Math.PI))*Math.Pow(Math.E, exponent));
            return Math.Round(constructedFormula, 4);
        }
    }
}
