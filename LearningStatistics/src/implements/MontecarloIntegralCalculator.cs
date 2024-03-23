using LearningStatistics.src.interfaces;

namespace LearningStatistics.src.implements
{
    /// <summary>
    /// Monte Carlo Arlgorithm
    /// </summary>
    /// <param name="count"></param>
    public class MontecarloIntegralCalculator(int count = 1000) : IIntegralCalculator
    {
        private readonly int _count = count;

        public double Integral(Func<double, double> func, double a, double b)
        {
            var rand = new Random();
            var sum = 0.0;
            for (var i = 0; i < _count; i++)
            {
                var x = a + (b - a) * rand.NextDouble();
                sum += func(x) * (b - a);
            }

            return sum / _count;
        }

        public double Integral(Func<double, double, double> func, double a, double b)
        {
            var rand = new Random();
            var sum = 0.0;
            for (var i = 0; i < _count; i++)
            {
                var x = a + (b - a) * rand.NextDouble();
                for (var j = 0; j < _count; j++)
                {
                    var y = a + (b - a) * rand.NextDouble();
                    sum += func(x, y) * (b - a);
                }
            }

            return sum / (_count * _count);
        }
    }
}
