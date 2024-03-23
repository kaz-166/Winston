using LearningStatistics.src.interfaces;

namespace LearningStatistics.src.multi_distributions.continuous
{
    public class ContinuousXYDistributionBase(IIntegralCalculator integral)
    {
        protected Func<double, double, double> _func = (x, y) => 0;

        protected double PSEUDO_INFINITY = 10;

        private readonly IIntegralCalculator _integral = integral;

        /// <summary>
        /// Joint Probability Function (x, y)
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>value</returns>
        public double Value(double x, double y) => _func(x, y);

        /// <summary>
        /// Marginal Probability Distribution X
        /// This calculation uses Trapezoidal Approximation
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double MarginalProbabilityDistributionX(double x)
        {
            Func<double, double> partial(double x) => y => _func(x, y);
            return _integral.Integral(partial(x), -PSEUDO_INFINITY, PSEUDO_INFINITY);
        }

        /// <summary>
        /// Marginal Probability Distribution Y
        /// This calculation uses Trapezoidal Approximation
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public double MarginalProbabilityDistributionY(double y)
        {
            Func<double, double> partial(double y) => x => _func(x, y);
            return _integral.Integral(partial(y), -PSEUDO_INFINITY, PSEUDO_INFINITY);
        }

        /// <summary>
        /// Conditional Probability Density Function : p(Y|x)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Func<double, double> ConditionalProbabilityFunctionWithX(double x)
        {
            Func<double, double> partial(double x) => y => _func(x, y);
            return partial(x);
        }

        /// <summary>
        /// Conditional Probability Density Function : p(X|y)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Func<double, double> ConditionalProbabilityFunctionWithY(double y)
        {
            Func<double, double> partial(double y) => x => _func(x, y);
            return partial(y);
        }

        /// <summary>
        /// Calculate Expectation X : E(X)
        /// </summary>
        /// <returns></returns>
        public double ExpectationX() => _integral.Integral(x => x * MarginalProbabilityDistributionX(x), -1, 1);

        /// <summary>
        /// Calculate Expectation Y : E(Y)
        /// </summary>
        /// <returns></returns>
        public double ExpectationY() => _integral.Integral(y => y * MarginalProbabilityDistributionY(y), -1, 1);

        /// <summary>
        /// Calculate Expectation(X, Y)
        /// </summary>
        /// <param name="phy"></param>
        /// <returns></returns>
        public double Expectation(Func<double, double, double> phy) => _integral.Integral((x, y) => phy(x, y) * _func(x, y), -1, 1);


        /// <summary>
        /// Calculate Variance V(X)
        /// </summary>
        /// <returns></returns>
        public double VarianceX() => Expectation((x, y) => Math.Pow(x - Expectation((x, y) => x), 2));

        /// <summary>
        /// Calculate Variance V(Y)
        /// </summary>
        /// <returns></returns>
        public double VarianceY() => Expectation((x, y) => Math.Pow(y - Expectation((x, y) => y), 2));

        /// <summary>
        /// Calculate Covariance(X, Y)
        /// </summary>
        /// <returns></returns>
        public double Covariance() => Expectation((x, y) => x * y) - Expectation((x, y) => x) * Expectation((x, y) => y);

        /// <summary>
        /// Calculate Corelative Coefficient
        /// </summary>
        /// <returns></returns>
        public double CorrelativeCoefficient() => Covariance() / Math.Sqrt((VarianceX() * VarianceY()));
    }
}
