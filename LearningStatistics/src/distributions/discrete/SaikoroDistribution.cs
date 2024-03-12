namespace LearningStatistics.src.distributions.discrete
{
    public class SaikoroDistribution : DiscreteDistributionBase
    {
        public SaikoroDistribution() : this(6)
        {
        }

        public SaikoroDistribution(int n)
        {
            if (n < 1) throw new ArgumentOutOfRangeException("N must be larger than 1.");
            _func = x => x > 0 && x <= n ? 1 / (double)n : 0;
        }
    }
}
