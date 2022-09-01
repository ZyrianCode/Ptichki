using static Ptichki.Tools.Misc.Generators.Uuid;

namespace Ptichki.Tools.Misc.Generators
{
    public static class RandomTransactionCodeGenerator
    {
        public static Uuid GenerateTransactionCode() => NewUuid();
    }
}
