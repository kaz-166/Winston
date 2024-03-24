namespace LearningStatistics.src.interfaces
{
    /// <summary>
    /// Interface of Integral Calculator
    /// </summary>
    public interface IIntegralCalculator
    {
        public double Integral(Func<double, double> func, double a, double b);

        public double Integral(Func<double, double, double> func, double a, double b);
    }
}
