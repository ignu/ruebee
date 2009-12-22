using System;

namespace ruebee
{
    public static class IntegerExtensions
    {
        public static void Times(this int numberOfTimes, Action action)
        {
            for (int i = 0; i < numberOfTimes; i++)            
                action();            
        }

        public static void UpTo(this int starting, int ending, Action<int> action)
        {
            for (int i = starting; i <= ending; i++)            
                action(i);            
        }

        public static void DownTo(this int starting, int ending, Action<int> action)
        {
            for (int i = starting; i >= ending; i--)
                action(i);
        }

        public static int Gcd(this int value, int other)
        {
            while (other != 0)
            {
                var remainder = value % other;
                value = other;
                other = remainder;
            }
            return value;
        }

        public static int Lcm(this int value, int other)
        {
            int rv = 0, gcd = Gcd(value, other);

            if (gcd != 0)
            {
                if (value > other)
                    rv = (other / gcd) * value;
                else 
                    rv = (value / gcd) * other;
            }
            return rv;     
        }

        public static char Chr(this int value)
        {
            return Convert.ToChar(value);
        }
    }
}