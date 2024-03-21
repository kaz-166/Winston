using LearningStatistics.src.extensions;

namespace LearningStatistics.src.multi_distributions.continuous
{
    public class ContinuousXYDistributionBase
    {
        protected Func<double, double, double> _func = (x, y) => 0;

        protected double PSEUDO_INFINITY = 10;

        protected double RESOLUTION = 0.005;

        /// <summary>
        /// Marginal Probability Distribution X
        /// This calculation uses Trapezoidal Approximation
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public virtual double MarginalProbabilityDistributionX(double x)
        {
            var sum = 0.0;
            for (var y = -PSEUDO_INFINITY; y < PSEUDO_INFINITY; y += RESOLUTION)
            {
                sum += ((_func(x, y) + _func(x, y + 1)) / 2) * RESOLUTION;
            }
            return sum;
        }

        /// <summary>
        /// Marginal Probability Distribution Y
        /// This calculation uses Trapezoidal Approximation
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual double MarginalProbabilityDistributionY(double y)
        {
            var sum = 0.0;
            for (var x = -PSEUDO_INFINITY; x < PSEUDO_INFINITY; x += RESOLUTION)
            {
                sum += ((_func(x, y) + _func(x + 1, y)) / 2) * RESOLUTION;
            }
            return sum;
        }

        public double ExpectationX() 
        {
            Func<double, double> f = x => x * MarginalProbabilityDistributionX(x);
            return f.Integral();
        }

        public double ExpectationY()
        {
            Func<double, double> f = y => y * MarginalProbabilityDistributionY(y);
            return f.Integral();
        }

        /// <summary>
        /// Calculate Expectation(X, Y)
        /// </summary>
        /// <param name="phy"></param>
        /// <returns></returns>
        public double Expectation(Func<double, double, double> phy)
        {
            Func<double, double, double> f = (x, y) => phy(x, y) * _func(x, y);
            return f.Integral();
        }

        /// <summary>
        /// Calculate Variance V(X)
        /// </summary>
        /// <returns></returns>
        public double VarianceX()
        {
            return Expectation((x, y) => Math.Pow(x - Expectation((x, y) => x), 2));
        }

        /// <summary>
        /// Calculate Variance V(Y)
        /// </summary>
        /// <returns></returns>
        public double VarianceY()
        {
            return Expectation((x, y) => Math.Pow(y - Expectation((x, y) => y), 2));
        }

        /// <summary>
        /// Calculate Covariance(X, Y)
        /// </summary>
        /// <returns></returns>
        public double Covariance()
        {
            return Expectation((x, y) => x * y) - Expectation((x, y) => x) * Expectation((x, y) => y);
        }

        /// <summary>
        /// Calculate Corelative Coefficient
        /// </summary>
        /// <returns></returns>
        public double CorrelativeCoefficient()
        {
            return Covariance() / Math.Sqrt((VarianceX() * VarianceY()));
        }

    }
}
