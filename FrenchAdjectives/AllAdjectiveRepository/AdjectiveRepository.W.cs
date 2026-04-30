using FrenchAdjectives.AllConstants;

namespace FrenchAdjectives.AllAdjectiveRepository;

internal static partial class AdjectiveRepository
{
    public static readonly IReadOnlyList<string> W = new[]
    {
        Constants.Walkyrien,
        Constants.Warrant,
        Constants.Web,
        Constants.Western,
        Constants.Witty,
    };

    public static readonly IReadOnlyList<string> W_Popular = new[]
    {
        Constants.Western,
        Constants.Web,
        Constants.Witty,
    };
}
