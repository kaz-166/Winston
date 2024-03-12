using LearningStatistics.src.distributions.discrete;

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
    }
}
