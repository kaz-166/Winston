using LearningStatistics.src.interfaces;

namespace LearningStatistics.src.implements
{
    public class IntegralCaluclator : IIntegralCalculator
    {
        public double Integral(Func<double, double> func, double a, double b)
        {
            const double RESOLUTION = 0.005;

            var sum = 0.0;
            for (var x = a; x < b; x += RESOLUTION)
            {
                sum += func(x) * RESOLUTION;
            }
            return sum;
        }

        public double Integral(Func<double, double, double> func, double a, double b)
        {
            throw new NotImplementedException();
        }
    }
}
