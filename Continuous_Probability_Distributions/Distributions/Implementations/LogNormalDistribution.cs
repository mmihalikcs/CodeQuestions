using Distributions.Interface;

namespace Distributions.Implementations
{
    public class LogNormalDistribution : IContinuousProbabilityDistribution
    {
        public double Mean => ComputeMean();

        public double Variance => ComputeVariance();

        // Fields
        double _mu = 0.0;
        double _sigmaSquared = 0.0;

        public LogNormalDistribution(double mu, double sigmaSquared)
        {
            _mu = mu;
            _sigmaSquared = sigmaSquared > 0 ? sigmaSquared : throw new ArgumentException("Value is not greater than zero", "sigmaSquared");
        }

        public double PDF(double x)
        {
            // Get the sigma value - since we have the square
            var sigma = Math.Sqrt(_sigmaSquared);
            // Lay out the formula
            var exponent = -(Math.Pow(Math.Log(x) - _mu, 2)) / (2 * _sigmaSquared);
            // Construct the formula
            var constructedFormula = (1 / (x * Math.Sqrt(2 * Math.PI*_sigmaSquared)) * Math.Pow(Math.E, exponent));
            return Math.Round(constructedFormula, 4);
        }

        #region Private Helpers

        /// <summary>
        /// Function for computing the mean. Pull logic into function since its complex
        /// </summary>
        /// <returns></returns>
        private double ComputeMean()
        {
            var meanConstructedFormula = Math.Pow(Math.E, (_mu + (_sigmaSquared / 2)));
            return Math.Round(meanConstructedFormula, 4);
        }

        /// <summary>
        /// Function for computing the variance. Pull logic into function since its complex
        /// </summary>
        /// <returns></returns>
        private double ComputeVariance()
        {
            var meanConstructedFormula = ((Math.Pow(Math.E, _sigmaSquared) - 1) * Math.Pow(Math.E, 2*_mu+_sigmaSquared));
            return Math.Round(meanConstructedFormula, 4);
        }

        #endregion Private Helpers
    }
}
