using LearningStatistics.src.distributions.discrete;
using LearningStatistics.src.multi_distributions.continuous;
using LearningStatistics.src.multi_distributions.discrete;
using System.Diagnostics;

namespace LearningStatistics.calcs
{
    public static class Example
    {
        public static void Table5_5() 
        {
            double[] param = { 32/243d, 80/243d, 80/243d, 40/243d, 10/243d, 1/243d};
            var dist = new GeneralDistribution(param);

            Console.WriteLine("期待値: {0}", dist.Expectation());
            Console.WriteLine("分散: {0}", dist.Variance());
            Console.WriteLine("標準偏差: {0}", dist.StdDeviation());
            Console.WriteLine("歪度: {0}", dist.Skewness());
            Console.WriteLine("尖度: {0}", dist.Kurtosis());
        }

        public static void p139() 
        {
            var dist = new SampleXYDistribution();
            Console.WriteLine("周辺確率密度関数X 0.5: {0}", dist.MarginalProbabilityDistributionX(0.5));
            Console.WriteLine("周辺確率密度関数X 0.3: {0}", dist.MarginalProbabilityDistributionX(0.3));
            Console.WriteLine("周辺確率密度関数X 0.3: {0}", dist.MarginalProbabilityDistributionX(0.1));
            Console.WriteLine("期待値Y: {0}", dist.ExpectationY());
            Console.WriteLine("期待値X: {0}", dist.ExpectationX());

            Console.WriteLine("分散X: {0}", dist.VarianceX());
            Console.WriteLine("分散Y: {0}", dist.VarianceY());
            Console.WriteLine("共分散: {0}", dist.Covariance());
            Console.WriteLine("相関係数: {0}", dist.CorrelativeCoefficient());
        }
    }
}
