using LearningStatistics.src.interfaces;

namespace LearningStatistics.src.multi_distributions.continuous
{
    public class SampleXYDistribution : ContinuousXYDistributionBase
    {
        public SampleXYDistribution(IIntegralCalculator integral) : base(integral)
        {         
            PSEUDO_INFINITY = 1;
            _func = (x, y) => (y >= 0.0 && x > y && x <= 1.0) ? 6 * (x - y) : 0;
        }
    }
}
