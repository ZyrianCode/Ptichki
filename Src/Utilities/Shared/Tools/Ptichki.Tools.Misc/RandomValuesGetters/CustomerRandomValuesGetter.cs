using static Ptichki.Tools.Misc.Generators.RandomPhoneNumberGenerator;

namespace Ptichki.Tools.Misc.RandomValuesGetters
{
    public static class CustomerRandomValuesGetter
    {
        public static string GetRandomPhoneNumber() =>
            GeneratePhoneNumber();

    }
}
