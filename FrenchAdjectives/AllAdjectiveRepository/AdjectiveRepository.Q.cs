using FrenchAdjectives.AllConstants;

namespace FrenchAdjectives.AllAdjectiveRepository;

internal static partial class AdjectiveRepository
{
    public static readonly IReadOnlyList<string> Q = new[]
    {
        Constants.Quasi,
        Constants.Quelque,
        Constants.Quelconque,
        Constants.Querelleux,
        Constants.Questionnable,
        Constants.Quotidien,
    };
}
