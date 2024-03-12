namespace LearningStatistics.src.distributions.continuous
{
    public class UniformDistribution : ContinuousDistributionBase
    {
        public UniformDistribution() : this(0, 1)
        {
        }

        public UniformDistribution(double a, double b)
        {
            // Can you decipher this? :)
            _func = x => x >= a && x <= b ? 1 / (b - a) : 0;
        }
    }
}
