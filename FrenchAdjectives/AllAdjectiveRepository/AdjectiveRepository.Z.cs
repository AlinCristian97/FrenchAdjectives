using FrenchAdjectives.AllConstants;

namespace FrenchAdjectives.AllAdjectiveRepository;

internal static partial class AdjectiveRepository
{
    public static readonly IReadOnlyList<string> Z = new[]
    {
        Constants.Zele,
        Constants.Zen,
        Constants.Zigzagant,
        Constants.Zonal,
        Constants.Zoologique,
    };

    public static readonly IReadOnlyList<string> Z_Popular = new[]
    {
        Constants.Zen,
        Constants.Zele,
        Constants.Zigzagant,
    };
}
