namespace LearningStatistics.src.distributions.discrete
{
    public class GeometricDistribution : DiscreteDistributionBase
    {
        public GeometricDistribution(double p)
        {
            // Validation
            ArgumentOutOfRangeException.ThrowIfLessThan(p, 0);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(p, 1);

            _func = x => p * Math.Pow(1 - p, x - 1);
        }
    }
}
