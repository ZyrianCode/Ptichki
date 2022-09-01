using System;
using Ptichki.Tools.Misc.RandomExtensions;
using static Ptichki.Tools.Misc.RandomValues.BirdRandomValues; 

namespace Ptichki.Tools.Misc.RandomValuesGetters
{
    public static class BirdRandomValuesGetter
    {
        public static string GetRandomGender() =>
            BirdsGenders[new Random().Next(1, BirdsGenders.Count)];

        public static int GetRandomAge() =>
            new Random().Next(MinimalAge, MaximalAge);

        public static float GetRandomWeight() =>
            new Random().NextFloat(MinimumWeight, MaximumWeight);

        public static float GetRandomWaterConsumption() =>
            new Random().NextFloat(MinimalWaterConsumption, MaximalWaterConsumption);
        public static float GetRandomFeedConsumption() =>
            new Random().NextFloat(MinimalFeedConsumption, MaximalFeedConsumption);
    }
}
