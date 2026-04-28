# Add a French Adjective

## Trigger

The user provides a French adjective to add to the project.

## Input

- **Adjective value**: the French word itself (e.g. `magnifique`, `élégant`).
- **Constant name**: the C# identifier to use. If not provided, derive it from the adjective value by removing diacritics and using PascalCase (e.g. `élégant` → `Elegant`, `déterminé` → `Determine`).

## Steps

### 1. Add the constant to split `Constants` partial files

- Edit: `FrenchAdjectives\AllConstants\Constants.{LETTER}.cs`
- `{LETTER}` = uppercase ASCII first letter of the adjective (`é` → `E`, `ç` → `C`, etc.).
- Add at end of file/class:

```csharp
public const string <ConstantName> = "<adjective value>";
```

Rules:
- Constant name: PascalCase, no accents/hyphens.
- Value: lowercase adjective, accents preserved.

### 2. Add the constant to split `AdjectiveRepository` partial files

- Edit: `FrenchAdjectives\AllAdjectiveRepository\AdjectiveRepository.{LETTER}.cs`
- `{LETTER}` = same uppercase ASCII first letter as above.
- Add the constant to that letter's list (`A`, `B`, ...).
- List order does **not** need to be alphabetical; append `Constants.<ConstantName>,` at the **end** of the array, just before the closing `};`.

> No other changes are needed — the `All` list and `BuildLetterMap()` already aggregate the per-letter arrays automatically.

### 3. Create the JSON sentence file

- Determine the folder letter by stripping diacritics from the first character and uppercasing it (e.g. `é` → `E`).
- Create the file at `FrenchAdjectives\Sentences\{Letter}\{adjective value}.json`.
- The file name must exactly match the adjective **value** (including any accented characters), with a `.json` extension.
- Use this structure:

```json
{
  "description": "<Two sentences in French describing the adjective — what it means and how it is typically used, naturally in french, with english synonyms in pharantesis.>",
  "sentences": [
    "<sentence 1>",
    "<sentence 2>",
    "<sentence 3>",
    "<sentence 4>",
    "<sentence 5>"
  ]
}
```

#### JSON content rules

- **`description`**: Write exactly **2 French sentences**. The first sentence should explain the meaning of the adjective in a natural french way, with english synonim in pharantesis.
- **`sentences`**: Provide exactly **5 French sentences** that use the adjective naturally. Each sentence should be **at least 15 words long** — avoid very short or trivial sentences.
- The file must be encoded as **UTF-8 without BOM**.

### 4. Validate

- Build the solution and confirm there are no compilation errors.

## Example

Given the adjective `familier`:

**Constants.F.cs** — at the end of the file:

```csharp
public const string Familier = "familier";
```

**AdjectiveRepository.F.cs** — last entry in the `F` array:

```csharp
Constants.Familier,
```

**File** `FrenchAdjectives\Sentences\F\familier.json`:

```json
{
  "description": "« Familier » (English: familiar, informal, casual) qualifie ce qui est bien connu, habituel, ou un registre de langue détendu et sans cérémonie.",
  "sentences": [
    "Le journaliste a rapporté que le discours prononcé hier soir au parlement était familier, marquant un tournant dans le débat public.",
    "Pendant la conférence internationale de cette semaine, plusieurs intervenants ont qualifié le nouveau projet de recherche de particulièrement familier.",
    "En traversant le grand parc de la ville ce matin-là, il a trouvé que le cadre qui l'entourait était remarquablement familier.",
    "Le romancier a choisi de décrire son personnage principal comme étant profondément familier, ce qui confère une grande profondeur au récit.",
    "La bibliothécaire a chaleureusement recommandé ce livre en le décrivant comme familier, une lecture captivante qui ne laisse personne indifférent."
  ]
}
```
