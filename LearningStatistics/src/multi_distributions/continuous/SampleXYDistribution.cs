using LearningStatistics.src.multi_distributions.discrete;

namespace LearningStatistics.src.multi_distributions.continuous
{
    public class SampleXYDistribution : ContinuousXYDistributionBase
    {
        public SampleXYDistribution()
        {
            // いやがらせ
            _func = (x, y) => y >= 0 && x > y && x <= 1 ? 6 / (x - y) : 0;
        }
    }
}
