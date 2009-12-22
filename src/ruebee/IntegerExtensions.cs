using System;

namespace ruebee
{
    public static class IntegerExtensions
    {
        public static void Times(this int numberOfTimes, Action action)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                action();
            }
        }
    }
}