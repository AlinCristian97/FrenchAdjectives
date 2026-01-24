using System.Globalization;
using System.Text;
using System.Text.Json;

namespace FrenchAdjectives
{
    internal static class AdjectiveRepository
    {
        private static readonly Dictionary<string, WordMetadata> _cache = new();
        private static readonly Random _random = new();
        private const string BaseFolderName = "Sentences";
        private const string FileExtension = ".json";

        public static readonly IReadOnlyList<string> A = new[]
        {
            Constants.Adorable,
            Constants.Agreable,
            Constants.Aimable,
            Constants.Amusant,
            Constants.Ancien,
            Constants.Attentionne,
            Constants.Audacieux,
            Constants.Affectionne,
            Constants.Admirable,
            Constants.Authentique,
        };

        public static readonly IReadOnlyList<string> B = new[]
        {
            Constants.Blanc,
        };

        public static readonly IReadOnlyList<string> C = new[]
        {
            Constants.Calme,
        };

        public static readonly IReadOnlyList<string> D = new[]
        {
            Constants.Dangereux,
        };

        public static readonly IReadOnlyList<string> E = new[]
        {
            Constants.Energique,
        };

        public static readonly IReadOnlyList<string> F = new[]
        {
            Constants.Facile,
        };

        public static readonly IReadOnlyList<string> G = new[]
        {
            Constants.Generueux,
        };

        public static readonly IReadOnlyList<string> H = new[]
        {
            Constants.Habile,
        };

        public static readonly IReadOnlyList<string> I = new[]
        {
            Constants.Ideal,
        };

        public static readonly IReadOnlyList<string> J = new[]
        {
            Constants.Jeune,
        };

        public static readonly IReadOnlyList<string> K = new[]
        {
            Constants.Kaki,
        };

        public static readonly IReadOnlyList<string> L = new[]
        {
            Constants.Leger,
        };

        public static readonly IReadOnlyList<string> M = new[]
        {
            Constants.Macho,
        };

        public static readonly IReadOnlyList<string> N = new[]
        {
            Constants.Naturel,
        };

        public static readonly IReadOnlyList<string> O = new[]
        {
            Constants.Obscur,
        };

        public static readonly IReadOnlyList<string> P = new[]
        {
            Constants.Paisible,
        };

        public static readonly IReadOnlyList<string> Q = new[]
        {
            Constants.Quelconque,
        };

        public static readonly IReadOnlyList<string> R = new[]
        {
            Constants.Rapide,
        };

        public static readonly IReadOnlyList<string> S = new[]
        {
            Constants.Simple,
        };

        public static readonly IReadOnlyList<string> T = new[]
        {
            Constants.Tendre,
        };

        public static readonly IReadOnlyList<string> U = new[]
        {
            Constants.Unique,
        };

        public static readonly IReadOnlyList<string> V = new[]
        {
            Constants.Vif,
        };

        public static readonly IReadOnlyList<string> W = new[]
        {
            Constants.Walkyrien,
        };

        public static readonly IReadOnlyList<string> X = new[]
        {
            Constants.Xenophile,
        };

        public static readonly IReadOnlyList<string> Y = new[]
        {
            Constants.Yiddish,
        };

        public static readonly IReadOnlyList<string> Z = new[]
        {
            Constants.Zele,
        };

        // Super-list that contains every letter list
        public static readonly IReadOnlyList<string> All = A
            .Concat(B)
            .Concat(C)
            .Concat(D)
            .Concat(E)
            .Concat(F)
            .Concat(G)
            .Concat(H)
            .Concat(I)
            .Concat(J)
            .Concat(K)
            .Concat(L)
            .Concat(M)
            .Concat(N)
            .Concat(O)
            .Concat(P)
            .Concat(Q)
            .Concat(R)
            .Concat(S)
            .Concat(T)
            .Concat(U)
            .Concat(V)
            .Concat(W)
            .Concat(X)
            .Concat(Y)
            .Concat(Z)
            .ToArray();

        private static IReadOnlyDictionary<char, IReadOnlyList<string>> BuildLetterMap()
        {
            return new Dictionary<char, IReadOnlyList<string>>(26)
            {
                [Constants.A[0]] = A,
                [Constants.B[0]] = B,
                [Constants.C[0]] = C,
                [Constants.D[0]] = D,
                [Constants.E[0]] = E,
                [Constants.F[0]] = F,
                [Constants.G[0]] = G,
                [Constants.H[0]] = H,
                [Constants.I[0]] = I,
                [Constants.J[0]] = J,
                [Constants.K[0]] = K,
                [Constants.L[0]] = L,
                [Constants.M[0]] = M,
                [Constants.N[0]] = N,
                [Constants.O[0]] = O,
                [Constants.P[0]] = P,
                [Constants.Q[0]] = Q,
                [Constants.R[0]] = R,
                [Constants.S[0]] = S,
                [Constants.T[0]] = T,
                [Constants.U[0]] = U,
                [Constants.V[0]] = V,
                [Constants.W[0]] = W,
                [Constants.X[0]] = X,
                [Constants.Y[0]] = Y,
                [Constants.Z[0]] = Z
            };
        }

        public static bool TryGetRandomByLetter(char letter, out string? result)
        {
            result = null;
            var key = char.ToLowerInvariant(letter);

            if (!BuildLetterMap().TryGetValue(key, out var list) || list == null || list.Count == 0)
            {
                return false;
            }

            result = list[Random.Shared.Next(list.Count)];
            return true;
        }

        public static bool TryGetRandom(out string? result)
        {
            result = null;

            if (All is null || All.Count == 0)
            {
                return false;
            }

            result = All[Random.Shared.Next(All.Count)];
            return true;
        }

        public static List<string> GetSentencesForWord(string word, int count = Constants.NumberOfRandomExampleSentences)
        {
            if (string.IsNullOrWhiteSpace(word) || count <= 0)
                return new List<string>();

            // For adjectives we expect the input to be the adjective itself (no article).
            var adjective = word.ToLower().Trim();

            if (!_cache.ContainsKey(adjective))
            {
                LoadAdjectiveJson(adjective);
            }

            if (_cache.TryGetValue(adjective, out var metadata) && metadata?.Sentences != null && metadata.Sentences.Any())
            {
                return metadata.Sentences
                    .OrderBy(_ => _random.Next())
                    .Take(count)
                    .ToList();
            }

            return new List<string>();
        }

        public static string GetDescriptionForWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return string.Empty;

            var adjective = word.ToLower().Trim();

            if (!_cache.ContainsKey(adjective))
                LoadAdjectiveJson(adjective);

            if (_cache.TryGetValue(adjective, out var metadata) && !string.IsNullOrWhiteSpace(metadata.Description))
                return metadata.Description.Trim();

            return string.Empty;
        }

        private static void LoadAdjectiveJson(string adjective)
        {
            // Defensive default
            _cache[adjective] = new WordMetadata();

            if (string.IsNullOrWhiteSpace(adjective))
                return;

            // First letter folder (A, B, C, ...)
            char firstLetter = RemoveDiacritics(adjective[0]).ToString().ToUpperInvariant()[0];

            // Base folder (runtime)
            string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BaseFolderName);

            if (!Directory.Exists(baseDir))
            {
                // Go up from bin/... to project root
                string projectRoot = Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..")
                );

                baseDir = Path.Combine(projectRoot, BaseFolderName);
            }

            if (!Directory.Exists(baseDir))
                return;

            // Sentences/A/adorable.json
            string adjFolder = Path.Combine(baseDir, firstLetter.ToString());
            string filePath = Path.Combine(adjFolder, $"{adjective}{FileExtension}");

            if (!File.Exists(filePath))
                return;

            try
            {
                string jsonContent = File.ReadAllText(filePath);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var metadata = JsonSerializer.Deserialize<WordMetadata>(jsonContent, options)
                               ?? new WordMetadata();

                metadata.Description ??= string.Empty;

                metadata.Sentences = (metadata.Sentences ?? new List<string>())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s => s.Trim())
                    .ToList();

                _cache[adjective] = metadata;
            }
            catch
            {
                // keep default empty metadata
                _cache[adjective] = new WordMetadata();
            }
        }

        private static char RemoveDiacritics(char c)
        {
            string normalized = c.ToString().Normalize(NormalizationForm.FormD);
            foreach (char ch in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    return ch;
            }
            return c;
        }
    }
}