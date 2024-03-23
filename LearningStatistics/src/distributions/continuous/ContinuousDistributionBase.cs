using LearningStatistics.src.interfaces;

namespace LearningStatistics.src.distributions.continuous
{
    public class ContinuousDistributionBase(IIntegralCalculator integral) : AbstractDistribution<double>
    {
        protected Func<double, double> _func = x => 0;

        private readonly IIntegralCalculator _integral = integral;

        protected double PSEUDO_INFINITY = 10;

        /// <summary>
        /// Return function value : f(x)
        /// </summary>
        /// <param name="x">x</param>
        /// <returns>f(x)</returns>
        public override double Value(double x)
        {
            return _func(x);
        }

        /// <summary>
        /// Calculate Expectation : E[X]
        /// </summary>
        /// <returns></returns>
        public override double Expectation()
        {
            return Expectation(x => x);
        }

        /// <summary>
        /// Calculate Expectation : E[phy(X)]
        /// </summary>
        /// <param name="phy"></param>
        /// <returns>Expectation</returns>
        public override double Expectation(Func<double, double> phy)
        {
            return _integral.Integral(x => phy(x) * _func(x), -PSEUDO_INFINITY, PSEUDO_INFINITY);
        }

        /// <summary>
        /// Calculate Variance: E[(X - u)^2]
        /// </summary>
        /// <returns>Variance</returns>
        public override double Variance()
        {
            return Expectation(x => x * x) - Expectation() * Expectation();
        }

        /// <summary>
        /// Calculate standard deviation
        /// </summary>
        /// <returns>standart deviation</returns>
        public override double StdDeviation() 
        {
            return Math.Sqrt(Variance());
        }

        /// <summary>
        /// Calculate Skewness: E[(X - u)^3]
        /// </summary>
        /// <returns>Skewness</returns>
        public override double Skewness()
        {
            return Expectation(x => Math.Pow(x - Expectation(), 3)) / Math.Pow(StdDeviation(), 3);
        }

        /// <summary>
        /// Calculate Kurtosis: E[(X - u)^4]
        /// </summary>
        /// <returns>Kurtosis</returns>
        public override double Kurtosis()
        {
            return Expectation(x => Math.Pow(x - Expectation(), 4)) / Math.Pow(StdDeviation(), 4);
        }

        /// <summary>
        /// Calculate N dimentional moment
        /// </summary>
        /// <param name="dimension">dimension</param>
        /// <returns>Moment of N dimension</returns>
        public override double Moment(int dimension)
        {
            return Expectation(x => Math.Pow(x - Expectation(), dimension));
        }

        /// <summary>
        /// Calculate standard N dimentional moment
        /// </summary>
        /// <param name="dimension">dimension</param>
        /// <returns>Moment of N dimension</returns>
        public override double StdMoment(int dimension)
        {
            return Expectation(x => Math.Pow(x - Expectation(), dimension)) / Math.Pow(StdDeviation(), dimension);
        }

        /// <summary>
        /// Calculate integral from -∞ to +∞
        /// </summary>
        /// <returns></returns>
        public double Integral()
        {
            return _integral.Integral(_func, -PSEUDO_INFINITY, PSEUDO_INFINITY);
        }

        /// <summary>
        /// Calculate integral from a to b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Integral(double a, double b)
        {
            return _integral.Integral(_func, a, b);
        }
    }
}
