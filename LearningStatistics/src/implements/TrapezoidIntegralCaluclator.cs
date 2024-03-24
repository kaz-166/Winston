using LearningStatistics.src.interfaces;

namespace LearningStatistics.src.implements
{
    /// <summary>
    /// TrapezoidIntegralCaluclator Class
    /// </summary>
    /// <remarks>This Calculation uses Trapezoid Approximation</remarks>
    public class TrapezoidIntegralCaluclator : IIntegralCalculator
    {
        public double Integral(Func<double, double> func, double a, double b)
        {
            const double RESOLUTION = 0.005;

            var sum = 0.0;
            for (var x = a; x < b; x += RESOLUTION)
            {
                sum += ((func(x) + func(x + 1)) / 2.0) * RESOLUTION;
            }
            return sum;
        }

        public double Integral(Func<double, double, double> func, double a, double b)
        {
            const double RESOLUTION = 0.005;

            var sum = 0.0;
            for (var x = a; x < b; x+= RESOLUTION) 
            {
                for (var y = a; y < b; y += RESOLUTION)
                {
                    sum += ((func(x, y) + func(x + 1, y + 1)) / 2.0) * RESOLUTION;
                }
            }

            return sum;
        }
    }
}
