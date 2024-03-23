using LearningStatistics.src.interfaces;

namespace LearningStatistics.src.distributions.continuous
{
    public class UniformDistribution : ContinuousDistributionBase
    {
        public UniformDistribution(IIntegralCalculator integral) : this(integral, 0, 1) {}

        public UniformDistribution(IIntegralCalculator integral, double a, double b) : base(integral)
        {
            _func = x => (x >= a && x <= b) ? 1 / (b - a) : 0;
        }
    }
}
