namespace LearningStatistics.src.distributions.discrete
{
    /// <summary>
    /// Bernoulli Distribution
    /// </summary>
    /// <remarks>Bernoulli Distribution is defined by Bi(1, p)</remarks>
    /// <param name="p"></param>
    public class BernoulliDistribution(double p) : BinomialDistribution(1, p)
    {
    }
}
