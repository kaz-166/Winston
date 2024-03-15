using LearningStatistics.src.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningStatistics.src.multi_distributions.continuous
{
    public class ContinuousXYDistributionBase
    {
        protected Func<double, double, double> _func;

        /// <summary>
        /// Marginal Probability Distribution X
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double MarginalProbabilityDistributionX(int x)
        {
            const double PSEUDO_INFINITY = 10000;

            var sum = 0.0;
            for (var y = 0; y < PSEUDO_INFINITY; y++)
            {
                sum += _func(x, y);
            }
            return sum;
        }

        /// <summary>
        /// Marginal Probability Distribution Y
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public double MarginalProbabilityDistributionY(int y)
        {
            const double PSEUDO_INFINITY = 10000;

            var sum = 0.0;
            for (var x = 0; x < PSEUDO_INFINITY; x++)
            {
                sum += _func(x, y);
            }
            return sum;
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
