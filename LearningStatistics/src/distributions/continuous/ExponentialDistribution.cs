using LearningStatistics.src.interfaces;

namespace LearningStatistics.src.distributions.continuous
{
    public class ExponentialDistribution : ContinuousDistributionBase
    {
        public ExponentialDistribution(IIntegralCalculator integral, double lambda) : base(integral)
        {
            _func = x => (x >= 0) ? lambda * Math.Exp(-lambda * x) : 0;
        }
    }
}
