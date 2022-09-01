using System;

namespace Ptichki.Tools.Misc.RandomExtensions
{
    public static class RandomExtension
    {
        public static T NextItem<T>(this Random random, params T[] items) =>
            items[random.Next(items.Length)];
        public static double NextDouble(this Random random, double min, double max) =>
            random.NextDouble() * (max - min) + min;

        public static float NextFloat(this Random random, float min, float max) =>
            (float)random.NextDouble(min, max);
    }
}
