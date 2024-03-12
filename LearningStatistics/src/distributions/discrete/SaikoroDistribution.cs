namespace LearningStatistics.src.distributions.discrete
{
    public class SaikoroDistribution : DiscreteDistributionBase
    {
        /// <summary>
        /// 6-sided, most popular dice distribution
        /// </summary>
        public SaikoroDistribution() : this(6)
        {
        }

        /// <summary>
        /// n-sided dice distribution
        /// </summary>
        /// <param name="n">number of sides</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw exception when invalid number is given.</exception>
        public SaikoroDistribution(int n)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);
            _func = x => x > 0 && x <= n ? 1 / (double)n : 0;
        }
    }
}
