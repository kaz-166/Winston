using LearningStatistics.src.extensions;

namespace LearningStatistics.src.distributions.continuous
{
    public class ContinuousDistributionBase
    {
        protected Func<double, double> _func;

        /// <summary>
        /// Return function value : f(x)
        /// </summary>
        /// <param name="x">x</param>
        /// <returns>f(x)</returns>
        public double Value(double x)
        {
            return _func(x);
        }

        /// <summary>
        /// Calculate Expectation : E[X]
        /// </summary>
        /// <returns></returns>
        public double Expectation()
        {
            return Expectation(x => x);
        }

        /// <summary>
        /// Calculate Expectation : E[phy(X)]
        /// </summary>
        /// <param name="phy"></param>
        /// <returns>Expectation</returns>
        public double Expectation(Func<double, double> phy)
        {
            Func<double, double> f = x => phy(x) * _func(x);
            return f.Integral();
        }

        /// <summary>
        /// Calculate Variant: E[(X - u)^2]
        /// </summary>
        /// <returns>Variant</returns>
        public double Variant()
        {
            // V[X] = E[X^2] - (E[X])^2
            return Expectation(x => x * x) - Expectation() * Expectation();
        }

        /// <summary>
        /// Calculate Skewness: E[(X - u)^3]
        /// </summary>
        /// <returns>Skewness</returns>
        public double Skewness()
        {
            return Expectation(x => Math.Pow(x - Expectation(), 3));
        }

        /// <summary>
        /// Calculate Kurtosis: E[(X - u)^4]
        /// </summary>
        /// <returns>Kurtosis</returns>
        public double Kurtosis()
        {
            return Expectation(x => Math.Pow(x - Expectation(), 4)); ;
        }

        /// <summary>
        /// Calculate N dimentional moment
        /// </summary>
        /// <param name="dimension">dimension</param>
        /// <returns>Moment of N dimension</returns>
        public double Moment(int dimension)
        {
            return Expectation(x => Math.Pow(x - Expectation(), dimension));
        }

        /// <summary>
        /// Calculate integral from -∞ to +∞
        /// </summary>
        /// <returns></returns>
        public double Integral()
        {
            return _func.Integral();
        }

        /// <summary>
        /// Calculate integral from a to b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Integral(double a, double b)
        {
            return _func.Integral(a, b);
        }
    }
}
