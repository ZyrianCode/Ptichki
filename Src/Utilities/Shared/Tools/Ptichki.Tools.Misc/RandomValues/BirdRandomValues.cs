using System.Collections.Generic;

namespace Ptichki.Tools.Misc.RandomValues
{
    public static class BirdRandomValues
    {
        private static List<string> _birdsGenders = new()
        {
            "Male",
            "Female"
        };
        public static IList<string> BirdsGenders => _birdsGenders;

        public const int MinimalAge = 0;
        public const int MaximalAge = 10;

        public const float MinimumWeight = 0.2f;
        public const float MaximumWeight = 6.0f;

        public const float MinimalWaterConsumption = 0.15f;
        public const float MaximalWaterConsumption = 1.05f;

        public const float MinimalFeedConsumption = 0.20f;
        public const float MaximalFeedConsumption = 1.4f;
    }
}
