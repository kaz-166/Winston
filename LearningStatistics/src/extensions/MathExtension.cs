namespace LearningStatistics.src.extensions
{
    /// <summary>
    /// Extension Methods
    /// </summary>
    public static class MathExtension
    {
        /// <summary>
        /// Calculate Factorial
        /// </summary>
        /// <param name="n">Natural number</param>
        /// <remarks>
        /// Result of factorial(n!) is TOO large number to be represented by primary type such as int or long.
        /// So, this method uses Int128 which represents 128-bit signed integer.(Supported version is .NET 7,8,9)
        /// </remarks>
        /// <returns>Factorial</returns>
        public static Int128 Factorial(this int n) 
        {
            return n > 0 ? n * Factorial(n - 1) : 1;
        }

        /// <summary>
        /// Calculate Permutation
        /// </summary>
        /// <param name="n">Natural number</param>
        /// <param name="r">Natural number</param>
        /// <remarks>
        /// Calculation of Permutation uses Factorial(nPr = n!/(n-r)!).
        /// And result of factorial(n!) is TOO large number to be represented by primary type such as int or long.
        /// So, this method uses Int128 which represents 128-bit signed integer.(Supported version is .NET 7,8,9)
        /// </remarks>
        /// <returns>Permutation</returns>
        public static Int128 Permutation(this int n, int r)
        {
            return Factorial(n) / Factorial(r);
        }

        /// <summary>
        /// Calculate Combination
        /// </summary>
        /// <param name="n">Natural number</param>
        /// <param name="r">Natural number</param>
        /// <remarks>
        /// Calculation of Combination uses Factorial(nCr = n!/(n-r)!r!).
        /// And result of factorial(n!) is TOO large number to be represented by primary type such as int or long.
        /// So, this method uses Int128 which represents 128-bit signed integer.(Supported version is .NET 7,8,9)
        /// </remarks>
        /// <returns>Combination</returns>
        public static Int128 Combination(this int n, int r)
        {
            return Factorial(n) / (Factorial(n - r) * Factorial(r));
        }

        /// <summary>
        /// Calculate integral from -∞ to +∞
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public static double Integral(this Func<double, double> func)
        {
            const double PSEUDO_INFINITY = 10000;

            return Integral(func, -PSEUDO_INFINITY, PSEUDO_INFINITY);
        }

        /// <summary>
        /// Calculate integral from a to b
        /// </summary>
        /// <param name="func"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Integral(this Func<double, double> func, double a, double b)
        {
            const double RESOLUTION = 0.01;

            var sum = 0.0;
            for (var x = a; x < b; x += RESOLUTION)
            {
                sum += func(x) * RESOLUTION;
            }
            return sum;
        }

        /// <summary>
        /// Calculate summation from -∞ to +∞
        /// </summary>
        /// <returns>Summation</returns>
        public static double Sum(this Func<int, double> func)
        {
            const int PSEUDO_INFINITY = 10000;

            return Sum(func, - PSEUDO_INFINITY, PSEUDO_INFINITY);
        }

        /// <summary>
        /// Calculate summation from a to b
        /// </summary>
        /// <param name="func"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Sum(this Func<int, double> func, int a, int b)
        {
            var sum = 0.0;
            for (var i = a; i < b; i++)
            {
                sum += func(i);
            }
            return sum;
        }
    }
}
