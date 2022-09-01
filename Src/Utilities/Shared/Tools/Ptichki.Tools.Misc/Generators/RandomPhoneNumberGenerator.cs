using System;
using static  Ptichki.Tools.Misc.RandomValues.PhoneNumberValues;

namespace Ptichki.Tools.Misc.Generators
{
    public static class RandomPhoneNumberGenerator
    {
        public static string GeneratePhoneNumber()
        {
            Random random = new Random();
            int countryCode = random.Next(MinimalCountryCode, MaximalCountryCode);
            int operatorCode = random.Next(MinimalOperatorCode, MaximalOperatorCode);
            int firstAbonentNumericCode = random.Next(MinimalFirstAbonentNumericCode, MaximalFirstAbonentNumericCode);
            int secondAbonentNumericCode = random.Next(MinimalSecondAbonentNumericCode, MaximalSecondAbonentNumericCode);
            int thirdAbonentNumericCode = random.Next(MinimalThirdAbonentNumericCode, MaximalThirdAbonentNumericCode);

            string fullPhoneNumber = $"+{countryCode} ( {operatorCode} ) {firstAbonentNumericCode}-{secondAbonentNumericCode}-{thirdAbonentNumericCode}";

            return fullPhoneNumber;
        }
    }
}
