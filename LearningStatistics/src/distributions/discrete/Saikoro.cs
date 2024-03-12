namespace LearningStatistics.src.distributions.discrete
{
    public class Saikoro : DiscreteDistributionBase
    {
        public Saikoro()
        {
            _func = x => x > 0 && x <= 6 ? 1 / (double)6 : 0;
        }

        public Saikoro(int n)
        {
            if (n < 1) throw new ArgumentOutOfRangeException("N must be larger than 1.");
            _func = x => x > 0 && x <= n ? 1 / (double)n : 0;
        }
    }
}
