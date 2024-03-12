using LearningStatistics.src.extensions;

namespace LearningStatistics.calcs
{
    public static class Answer
    {
        public static void Section4_3()
        {
            // 看護婦は30人
            var nurse = 30;
            
            // 15人ずつ2組に分けるので30C15通り
            var comb = nurse.Combination(15);

            Console.WriteLine("4-3: {0}通り", comb);
        }
    }
}
