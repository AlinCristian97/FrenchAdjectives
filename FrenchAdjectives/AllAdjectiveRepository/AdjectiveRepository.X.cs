using FrenchAdjectives.AllConstants;

namespace FrenchAdjectives.AllAdjectiveRepository;

internal static partial class AdjectiveRepository
{
    public static readonly IReadOnlyList<string> X = new[]
    {
        Constants.Xenophile,
        Constants.Xenophobe,
        Constants.Xero,
        Constants.Xylographique,
        Constants.Xylophonique,
    };

    public static readonly IReadOnlyList<string> X_Popular = new[]
    {
        Constants.Xenophile,
        Constants.Xenophobe,
    };
}
