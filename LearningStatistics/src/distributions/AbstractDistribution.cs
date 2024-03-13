namespace LearningStatistics.src.distributions
{
    public abstract class AbstractDistribution<T>
    {
        /// <summary>
        /// Return function value : f(x)
        /// </summary>
        /// <param name="x">x</param>
        /// <returns>f(x)</returns>
        public abstract double Value(T x);

        /// <summary>
        /// Calculate Expectation : E[X]
        /// </summary>
        /// <returns></returns>
        public abstract double Expectation();

        /// <summary>
        /// Calculate Expectation : E[phy(X)]
        /// </summary>
        /// <param name="phy"></param>
        /// <returns>Expectation</returns>
        public abstract double Expectation(Func<T, double> phy);

        /// <summary>
        /// Calculate Variance: E[(X - u)^2]
        /// </summary>
        /// <returns>Variance</returns>
        public abstract double Variance();

        /// <summary>
        /// Calculate standard deviation
        /// </summary>
        /// <returns>standart deviation</returns>
        public abstract double StdDeviation();

        /// <summary>
        /// Calculate Skewness: E[(X - u)^3]
        /// </summary>
        /// <returns>Skewness</returns>
        public abstract double Skewness();

        /// <summary>
        /// Calculate Kurtosis: E[(X - u)^4]
        /// </summary>
        /// <returns>Kurtosis</returns>
        public abstract double Kurtosis();

        /// <summary>
        /// Calculate N dimentional moment
        /// </summary>
        /// <param name="dimension">dimension</param>
        /// <returns>Moment of N dimension</returns>
        public abstract double Moment(int dimension);

        /// <summary>
        /// Calculate standard N dimentional moment
        /// </summary>
        /// <param name="dimension">dimension</param>
        /// <returns>Moment of N dimension</returns>
        public abstract double StdMoment(int dimension);
    }
}
