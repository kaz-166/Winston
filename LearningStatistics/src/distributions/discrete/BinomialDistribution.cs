using LearningStatistics.src.extensions;

namespace LearningStatistics.src.distributions.discrete
{
    public class BinomialDistribution : DiscreteDistributionBase
    {
        public BinomialDistribution(int n, double p)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(p, 1);

            _func = x => (double)n.Permutation(x) * Math.Pow(x, n) * Math.Pow(1 - p, n - x);
        }
    }
}
