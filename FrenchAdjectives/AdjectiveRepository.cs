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
            Constants.Autochtone,
            Constants.Agacant,
            Constants.Ardent,
            Constants.Apparent,
            Constants.Artistique,
            Constants.Abject,
            Constants.Ambiant,
            Constants.Amer,
            Constants.Adorable,
            Constants.Agreable,
            Constants.Attentif,
            Constants.Attrayant,
            Constants.Aimable,
            Constants.Amusant,
            Constants.Ancien,
            Constants.Attentionne,
            Constants.Audacieux,
            Constants.Affectionne,
            Constants.Admirable,
            Constants.Authentique,
            Constants.Autre,
            Constants.Americain,
            Constants.Anglais,
            Constants.Abbandoned,
            Constants.Arrete,
        };

        public static readonly IReadOnlyList<string> B = new[]
        {
            Constants.Bete,
            Constants.Brutal,
            Constants.Bouillonnant,
            Constants.Blanc,
            Constants.Blond,
            Constants.Brun,
            Constants.Bleu,
            Constants.Boueux,
            Constants.Brave,
            Constants.Brillant,
            Constants.Beau,
            Constants.Bienveillant,
            Constants.Bizarre,
            Constants.Bon,
            Constants.Bonne,
            Constants.Bruyant,
        };

        public static readonly IReadOnlyList<string> C = new[]
        {
            Constants.Calamiteux,
            Constants.Concret,
            Constants.Commun,
            Constants.Climatique,
            Constants.Coriace,
            Constants.Chaleureux,
            Constants.Colerique,
            Constants.Cru,
            Constants.Competent,
            Constants.Culpable,
            Constants.Compatissant,
            Constants.Contournable,
            Constants.Contextuelle,
            Constants.Corrompu,
            Constants.Crasseux,
            Constants.Cense,
            Constants.Celebre,
            Constants.Convulsif,
            Constants.Certain,
            Constants.Critique,
            Constants.Calme,
            Constants.Complet,
            Constants.Chaud,
            Constants.Cher,
            Constants.Court,
            Constants.Cruel,
            Constants.Clair,
            Constants.Complique,
            Constants.Celibataire,
            Constants.Courageux,
            Constants.Curieux,
            Constants.Creatif,
            Constants.Content,
            Constants.Complexe,
            Constants.Chaque,
            Constants.Condescendant,
        };

        public static readonly IReadOnlyList<string> D = new[]
        {
            Constants.Desoriente,
            Constants.Douce,
            Constants.Digne,
            Constants.Desole,
            Constants.Depenaille,
            Constants.Docile,
            Constants.Dangereux,
            Constants.Dispensable,
            Constants.Droite,
            Constants.Delicat,
            Constants.Difficile,
            Constants.Drole,
            Constants.Different,
            Constants.Doux,
            Constants.Durable,
            Constants.Dynamique,
            Constants.Decisif,
            Constants.Defiant,
            Constants.Desirable,
            Constants.Determine,
            Constants.Devoue,
            Constants.Divin,
            Constants.Domestique,
            Constants.Dramatique,
            Constants.Diligent,
            Constants.Discret,
            Constants.Distinctif,
            Constants.Distrayant,
            Constants.Documente,
            Constants.Dolent,
            Constants.Douteux,
            Constants.Draconien,
            Constants.Dubitatif,
            Constants.Dulcissime,
            Constants.Disponible,
            Constants.Desireux,
            Constants.Desireuse,
        };

        public static readonly IReadOnlyList<string> E = new[]
        {
            Constants.Eternel,
            Constants.Encombrant,
            Constants.Emblematique,
            Constants.Entetante,
            Constants.Extreme,
            Constants.Environnant,
            Constants.Egale,
            Constants.Energique,
            Constants.Enorme,
            Constants.Ecrit,
            Constants.Excite,
            Constants.Excitee,
            Constants.Epais,
            Constants.Etrange,
            Constants.Evident,
            Constants.Excellent,
            Constants.Exotique,
            Constants.Extraordinaire,
            Constants.Exuberant,
            Constants.Elegant,
            Constants.Electrique,
            Constants.Emouvant,
            Constants.Enchanteur,
            Constants.Ensoleille,
            Constants.Enthousiaste,
            Constants.Ephemere,
            Constants.Equitable,
            Constants.Essentiel,
            Constants.Esthetique,
            Constants.Ethique,
            Constants.Etonnant,
            Constants.Euphorique,
            Constants.Evocateur,
            Constants.Extravagant,
            Constants.Espagnol,
            Constants.Excessif,
        };

        public static readonly IReadOnlyList<string> F = new[]
        {
            Constants.Fier,
            Constants.Fragile,
            Constants.Frustrant,
            Constants.Funeraire,
            Constants.Familier,
            Constants.Fervent,
            Constants.Flexible,
            Constants.Farouche,
            Constants.Fou,
            Constants.Foncier,
            Constants.Fichu,
            Constants.Final,
            Constants.Fascinant,
            Constants.Faux,
            Constants.Furtif,
            Constants.Fidele,
            Constants.Fantaisiste,
            Constants.Facile,
            Constants.Faible,
            Constants.Formel,
            Constants.Fatigue,
            Constants.Fort,
            Constants.Frais,
            Constants.Frequent,
            Constants.Francais,
            Constants.Ferme,
        };

        public static readonly IReadOnlyList<string> G = new[]
        {
            Constants.Gigantesque,
            Constants.Geant,
            Constants.Genant,
            Constants.Generueux,
            Constants.Gauche,
            Constants.Gentil,
            Constants.Glacial,
            Constants.Grand,
            Constants.Gros,
        };

        public static readonly IReadOnlyList<string> H = new[]
        {
            Constants.Horrible,
            Constants.Honorable,
            Constants.Hautain,
            Constants.Habile,
            Constants.Heureux,
            Constants.Honnete,
            Constants.Humain,
            Constants.Humide,
            Constants.Haute,
        };

        public static readonly IReadOnlyList<string> I = new[]
        {
            Constants.Incompetent,
            Constants.Insignifiant,
            Constants.Indifferent,
            Constants.Inviolable,
            Constants.Imbecile,
            Constants.Intermediaire,
            Constants.Impossible,
            Constants.Impuissant,
            Constants.Irrespectueux,
            Constants.Ironique,
            Constants.Immortel,
            Constants.Interdit,
            Constants.Impermeable,
            Constants.Iconique,
            Constants.Incontournable,
            Constants.Inedit,
            Constants.Inattendu,
            Constants.Inconnu,
            Constants.Inutile,
            Constants.Innocent,
            Constants.Invisible,
            Constants.Infernal,
            Constants.Impressionnant,
            Constants.Inhabituel,
            Constants.Inintelligible,
            Constants.Insupportable,
            Constants.Incapable,
            Constants.Inoffensif,
            Constants.Ideal,
            Constants.Important,
            Constants.Illegitime,
            Constants.Intelligent,
            Constants.Interessant,
            Constants.Improbable,
            Constants.Isole,
            Constants.Impeccable,
            Constants.Imposant,
            Constants.Incroyable,
            Constants.Indispensable,
            Constants.Inoubliable,
            Constants.Insolite,
            Constants.Inspirant,
            Constants.Intense,
            Constants.Intriguant,
            Constants.Invincible,
            Constants.Irresistible,
            Constants.Irritable,
            Constants.Immateriel,
            Constants.Incassable,
        };

        public static readonly IReadOnlyList<string> J = new[]
        {
            Constants.Jaloux,
            Constants.Judiciaire,
            Constants.Jeune,
            Constants.Joli,
            Constants.Japonais,
            Constants.Joyeux,
            Constants.Juste,
            Constants.Juteux,
        };

        public static readonly IReadOnlyList<string> K = new[]
        {
            Constants.Kaki,
            Constants.Kitsch,
            Constants.Kitschable,
            Constants.Kilometrique,
            Constants.Karmique,
        };

        public static readonly IReadOnlyList<string> L = new[]
        {
            Constants.Legitime,
            Constants.Local,
            Constants.Legal,
            Constants.Logique,
            Constants.Levant,
            Constants.Leger,
            Constants.Lamentable,
            Constants.Lointain,
            Constants.Libre,
            Constants.Lisse,
            Constants.Long,
            Constants.Lumineux,
            Constants.Loyal,
            Constants.Lourd,
            Constants.Legendaire,
            Constants.Limite,
        };

        public static readonly IReadOnlyList<string> M = new[]
        {
            Constants.Morose,
            Constants.Mineure,
            Constants.Majeure,
            Constants.Maudit,
            Constants.Meconnaissable,
            Constants.Malsaine,
            Constants.Minimal,
            Constants.Mortel,
            Constants.Moribond,
            Constants.Meconnu,
            Constants.Mince,
            Constants.Muet,
            Constants.Moindre,
            Constants.Meme,
            Constants.Macho,
            Constants.Medical,
            Constants.Majeur,
            Constants.Mechant,
            Constants.Mignon,
            Constants.Moderne,
            Constants.Mouille,
            Constants.Mysterieux,
            Constants.Magnifique,
            Constants.Majestueux,
            Constants.Memorable,
            Constants.Minuscule,
            Constants.Monumental,
            Constants.Magique,
            Constants.Mexicain,
        };

        public static readonly IReadOnlyList<string> N = new[]
        {
            Constants.Nombreux,
            Constants.Natural,
            Constants.Nuisible,
            Constants.Notoire,
            Constants.Negligent,
            Constants.Necessaire,
            Constants.Naturel,
            Constants.Nerveux,
            Constants.Niais,
            Constants.Neuf,
            Constants.Noir,
            Constants.Nouveau,
            Constants.Nouvelle,
        };

        public static readonly IReadOnlyList<string> O = new[]
        {
            Constants.Opportuniste,
            Constants.Original,
            Constants.Optimal,
            Constants.Obscur,
            Constants.Officiel,
            Constants.Orale,
            Constants.Ordinaire,
            Constants.Optimiste,
            Constants.Ouvert,
        };

        public static readonly IReadOnlyList<string> P = new[]
        {
            Constants.Personnel,
            Constants.Profonde,
            Constants.Penetrable,
            Constants.Possible,
            Constants.Pleutre,
            Constants.Penale,
            Constants.Principal,
            Constants.Pourri,
            Constants.Proche,
            Constants.Pire,
            Constants.Pale,
            Constants.Paisible,
            Constants.Pareil,
            Constants.Parle,
            Constants.Parfait,
            Constants.Petit,
            Constants.Plein,
            Constants.Propre,
            Constants.Pauvre,
            Constants.Prochain,
            Constants.Pret,
            Constants.Precieux,
            Constants.Precaire,
            Constants.Precis,
            Constants.Preemptif,
            Constants.Prehistorique,
            Constants.Prejudiciable,
            Constants.Preliminaire,
            Constants.Prenatal,
            Constants.Prescient,
            Constants.Prestigieux,
            Constants.Primitif,
            Constants.Privilegie,
            Constants.Probable,
            Constants.Prodigieux,
            Constants.Profond,
            Constants.Prolifique,
            Constants.Prudent,
            Constants.Pugnace,
            Constants.Puissant,
            Constants.Pittoresque,
            Constants.Pluvieux,
            Constants.Polyvalent,
            Constants.Pondere,
            Constants.Portatif,
            Constants.Posthume,
            Constants.Prefere,
        };

        public static readonly IReadOnlyList<string> Q = new[]
        {
            Constants.Quasi,
            Constants.Quelque,
            Constants.Quelconque,
            Constants.Querelleux,
            Constants.Questionnable,
            Constants.Quotidien,
        };

        public static readonly IReadOnlyList<string> R = new[]
        {
            Constants.Ridicule,
            Constants.Revigorant,
            Constants.Rugueux,
            Constants.Recente,
            Constants.Rich,
            Constants.Regional,
            Constants.Raffine,
            Constants.Rapide,
            Constants.Rare,
            Constants.Reserve,
            Constants.Rigoureux,
            Constants.Riche,
            Constants.Rond,
            Constants.Rouge,
            Constants.Respectueux,
            Constants.Rude,
            Constants.Rationnel,
            Constants.Realiste,
            Constants.Recherche,
            Constants.Recommande,
            Constants.Redoutable,
            Constants.Refroidi,
            Constants.Regulier,
            Constants.Renouvele,
            Constants.Renversante,
        };

        public static readonly IReadOnlyList<string> S = new[]
        {
            Constants.Supreme,
            Constants.Signifiant,
            Constants.Semblable,
            Constants.Solitaire,
            Constants.Soigne,
            Constants.Seul,
            Constants.Specifique,
            Constants.Sincere,
            Constants.Sinistre,
            Constants.Splendide,
            Constants.Sense,
            Constants.Soigneux,
            Constants.Supportable,
            Constants.Servile,
            Constants.Sournoise,
            Constants.Simple,
            Constants.Sur,
            Constants.Special,
            Constants.Sombre,
            Constants.Sacre,
            Constants.Solide,
            Constants.Sucre,
            Constants.Sympathique,
            Constants.Serein,
            Constants.Silencieux,
            Constants.Souple,
            Constants.Sportif,
            Constants.Stable,
            Constants.Style,
            Constants.Suave,
            Constants.Satisfaisant,
            Constants.Scintillant,
            Constants.Seduisant,
            Constants.Symbolic,
            Constants.Super,
            Constants.Soulage,
            Constants.Sceptique,
            Constants.Scientifique,
            Constants.Scrupuleux,
            Constants.Sensationnel,
            Constants.Sensible,
            Constants.Sentimental,
            Constants.Solennel,
            Constants.Somptueux,
            Constants.Spontane,
            Constants.Stupefiant,
            Constants.Subtil,
            Constants.Suggere,
            Constants.Surprenant,
            Constants.Systematique,
            Constants.Satisfait,
            Constants.Sponsorise,
            Constants.Strict,
        };

        public static readonly IReadOnlyList<string> T = new[]
        {
            Constants.Typique,
            Constants.Total,
            Constants.Trompeur,
            Constants.Touchant,
            Constants.Theatral,
            Constants.Taciturne,
            Constants.Technique,
            Constants.Tentante,
            Constants.Torve,
            Constants.Tendre,
            Constants.Tranquille,
            Constants.Translucide,
            Constants.Transparent,
            Constants.Triste,
            Constants.Termine,
            Constants.Terminee,
            Constants.Talentueux,
        };

        public static readonly IReadOnlyList<string> U = new[]
        {
            Constants.Unique,
            Constants.Urbain,
            Constants.Urgent,
            Constants.Usuel,
            Constants.Utile,
        };

        public static readonly IReadOnlyList<string> V = new[]
        {
            Constants.Vain,
            Constants.Veuf,
            Constants.Visqueux,
            Constants.Visible,
            Constants.Verdatre,
            Constants.Violent,
            Constants.Veritable,
            Constants.Vrai,
            Constants.Vif,
            Constants.Verrouille,
            Constants.Vert,
            Constants.Vieux,
            Constants.Vide,
            Constants.Volumineux,
            Constants.Vieille,
        };

        public static readonly IReadOnlyList<string> W = new[]
        {
            Constants.Walkyrien,
            Constants.Warrant,
            Constants.Web,
            Constants.Western,
            Constants.Witty,
        };

        public static readonly IReadOnlyList<string> X = new[]
        {
            Constants.Xenophile,
            Constants.Xenophobe,
            Constants.Xero,
            Constants.Xylographique,
            Constants.Xylophonique,
        };

        public static readonly IReadOnlyList<string> Y = new[]
        {
            Constants.Yiddish,
            Constants.Yeuxlike,
            Constants.Yogaesque,
            Constants.Youngish,
            Constants.Yummy,
        };

        public static readonly IReadOnlyList<string> Z = new[]
        {
            Constants.Zele,
            Constants.Zen,
            Constants.Zigzagant,
            Constants.Zonal,
            Constants.Zoologique,
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