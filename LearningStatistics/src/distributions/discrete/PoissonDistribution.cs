using LearningStatistics.src.extensions;

namespace LearningStatistics.src.distributions.discrete
{
    public class PoissonDistribution : DiscreteDistributionBase
    {
        public PoissonDistribution(double lambda)
        {
            // Validation
            ArgumentOutOfRangeException.ThrowIfLessThan(lambda, 0);

            _func = x => (x >= 0) ? Math.Exp(-lambda) * Math.Pow(lambda, x) / (double)x.Factorial() : 0;
        }
    }
}
