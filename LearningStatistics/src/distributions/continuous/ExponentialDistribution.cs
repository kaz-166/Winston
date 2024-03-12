namespace LearningStatistics.src.distributions.continuous
{
    public class ExponentialDistribution : ContinuousDistributionBase
    {
        public ExponentialDistribution(double lambda)
        {
            _func = x => (x >= 0) ? lambda * Math.Exp(-lambda * x) : 0;
        }
    }
}
