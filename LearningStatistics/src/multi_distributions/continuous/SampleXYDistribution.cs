using LearningStatistics.src.multi_distributions.discrete;

namespace LearningStatistics.src.multi_distributions.continuous
{
    public class SampleXYDistribution : ContinuousXYDistributionBase
    {
        public SampleXYDistribution()
        {
            // いやがらせ
            _func = (x, y) => (y >= 0.0 && x > y && x <= 1.0) ? 6 * (x - y) : 0;
            PSEUDO_INFINITY = 1;
            RESOLUTION = 0.005;
        }

        //public override double MarginalProbabilityDistributionX(double x) 
        //{
        //    return 3 * x * x;
        //}

        //public override double MarginalProbabilityDistributionY(double y)
        //{
        //    return 3 * (1 - y) * (1 - y);
        //}
    }
}
