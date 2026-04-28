using FrenchAdjectives.AllConstants;

namespace FrenchAdjectives.AllAdjectiveRepository;

internal static partial class AdjectiveRepository
{
    public static readonly IReadOnlyList<string> U = new[]
    {
        Constants.Unique,
        Constants.Urbain,
        Constants.Urgent,
        Constants.Usuel,
        Constants.Utile,
    };
}
