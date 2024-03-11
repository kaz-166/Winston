namespace LearningStatistics.src.lib
{
    public class ProbabilityFunctions
    {
        public static double Saikoro(int x)
        {
           return (x > 0 && x <= 6) ? 1 / (double)6 : 0;
        }

        public static double Impulse(int x)
        {
            return x == 0 ? 1 : 0;
        }
    }
}
