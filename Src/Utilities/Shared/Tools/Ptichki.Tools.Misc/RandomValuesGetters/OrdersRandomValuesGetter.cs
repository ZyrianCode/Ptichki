using System;
using Ptichki.Tools.Misc.RandomExtensions;
using static Ptichki.Tools.Misc.RandomValues.OrderRandomValues;
using static Ptichki.Tools.Misc.Generators.RandomTransactionCodeGenerator;
namespace Ptichki.Tools.Misc.RandomValuesGetters
{
    public static class OrdersRandomValuesGetter
    {
        public static float GetRandomPrice() => new Random().NextFloat(MinimalPrice, MaximalPrice);
        public static string GetRandomTransactionCode() => GenerateTransactionCode().ToString();
    }
}
