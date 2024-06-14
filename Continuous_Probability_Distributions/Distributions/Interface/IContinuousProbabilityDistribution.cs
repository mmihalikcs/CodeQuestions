using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.Interface
{
    public interface IContinuousProbabilityDistribution
    {
        public double Mean { get; }
        public double Variance { get; }

        public double PDF(double x);
    }
}
