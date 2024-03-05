using System;

namespace WariorsWar
{
    internal class Utility
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int maxValue) =>
            s_random.Next(maxValue);

        public static bool CalculateChanse(double probability) =>
            s_random.NextDouble() < probability;
    }
}
