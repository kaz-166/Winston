using LearningStatistics.src.distributions;
using LearningStatistics.src.distributions.continuous;
using LearningStatistics.src.distributions.discrete;
using LearningStatistics.src.implements;

namespace LearningStatistics.src.view
{
    public static class DisplayStatistics
    {
        public static void Display() 
        {
            Console.WriteLine("確率密度関数の種類を選択してください。");
            Console.WriteLine("0:一様分布 ");
            Console.WriteLine("1:離散一様分布 ");
            Console.WriteLine("2:二項分布 ");
            Console.WriteLine("3:ベルヌーイ分布 ");
            Console.WriteLine("4:超幾何分布 ");
            Console.WriteLine("5:幾何分布 ");
            Console.WriteLine("6:ポアソン分布 ");
            Console.WriteLine("7:指数分布 ");
            Console.WriteLine("8:正規分布 ");

            _ = int.TryParse(Console.ReadLine(), out var number);

            var calculator = new MontecarloIntegralCalculator(1000);

            switch (number) 
            {
                // Uniform Distribution
                case 0:
                    Console.WriteLine("下限値を入力してください。");
                    _ = double.TryParse(Console.ReadLine(), out var a);

                    Console.WriteLine("上限値を入力してください。");
                    _ = double.TryParse(Console.ReadLine(), out var b);

                    Display(new UniformDistribution(calculator, a, b));

                    break;

                // Discrete Uniform Distribution
                case 1:

                    Console.WriteLine("上限値を入力してください。");
                    _ = int.TryParse(Console.ReadLine(), out var max);

                    Display(new DiscreteUniformDistribution(max));

                    break;

                // Binomial Distribution
                case 2:
                    Console.WriteLine("nを入力してください。");
                    _ = int.TryParse(Console.ReadLine(), out var n);
                    Console.WriteLine("pを入力してください。");
                    _ = double.TryParse(Console.ReadLine(), out var p);

                    Display(new BinomialDistribution(n, p));
                    break;

                // Bernouli Distribution
                case 3:
                    Console.WriteLine("pを入力してください。");
                    _ = double.TryParse(Console.ReadLine(), out var pp);

                    Display(new BernoulliDistribution(pp));
                    break;

                // Hypergeometric Distribution
                case 4:
                    Console.WriteLine("Nを入力してください。");
                    _ = int.TryParse(Console.ReadLine(), out var N);

                    Console.WriteLine("Mを入力してください。");
                    _ = int.TryParse(Console.ReadLine(), out var M);

                    Console.WriteLine("nを入力してください。");
                    _ = int.TryParse(Console.ReadLine(), out var nn);

                    Display(new HypergeometricDistribution(N, M, nn));
                    break;

                // Geometric Distribution
                case 5:
                    Console.WriteLine("pを入力してください。");
                    _ = double.TryParse(Console.ReadLine(), out var ppp);

                    Display(new GeometricDistribution(ppp));
                    break;
            }
        }

        private static void Display(AbstractDistribution<double> d) 
        {
            Console.WriteLine("-------------- 統計量 --------------");
            Console.WriteLine("期待値：{0}", d.Expectation());
            Console.WriteLine("分散：{0}", d.Variance());
            Console.WriteLine("歪度：{0}", d.Skewness());
            Console.WriteLine("突度：{0}", d.Variance());
        }

        private static void Display(AbstractDistribution<int> d)
        {
            Console.WriteLine("-------------- 統計量 --------------");
            Console.WriteLine("期待値：{0}", d.Expectation());
            Console.WriteLine("分散：{0}", d.Variance());
            Console.WriteLine("歪度：{0}", d.Skewness());
            Console.WriteLine("突度：{0}", d.Variance());
        }

    }
    
}
