﻿using LearningStatistics.src.extensions;

namespace LearningStatistics.src.distributions.discrete
{
    public class DiscreteDistributionBase
    {
        protected Func<int, double> _func;

        /// <summary>
        /// Return function value : f(x)
        /// </summary>
        /// <param name="x">x</param>
        /// <returns>f(x)</returns>
        public double Value(int x)
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
        public double Expectation(Func<int, double> phy)
        {
            Func<int, double> f = x => phy(x) * _func(x);
            return f.Sum();
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
        /// Calculate summation from -∞ to +∞
        /// </summary>
        /// <returns>Summation</returns>
        public double Sum()
        {
            return _func.Sum();
        }

        /// <summary>
        /// Calculate summation from a to b
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        /// <returns>Summation</returns>
        public double Sum(int a, int b)
        {
            return _func.Sum(a, b);
        }
    }
}
