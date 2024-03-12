namespace LearningStatistics.src.distributions.discrete
{
    public class GeneralDistribution : DiscreteDistributionBase
    {
        public GeneralDistribution(double[] param)
        {
            _func = x => x >= 0 && x < param.Length ? param[x] : 0;
        }
    }
}
