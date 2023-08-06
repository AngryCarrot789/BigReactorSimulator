namespace BigReactorSimulator.Utilities
{
    public static class MathsHelper
    {
        public static int Clamp(this int value, int min, int max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }
    }
}
