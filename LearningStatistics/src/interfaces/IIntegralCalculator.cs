namespace LearningStatistics.src.interfaces
{
    public interface IIntegralCalculator
    {
        public double Integral(Func<double, double> func, double a, double b);

        public double Integral(Func<double, double, double> func, double a, double b);
    }
}
