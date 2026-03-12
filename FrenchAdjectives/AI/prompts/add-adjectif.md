# Add a French Adjective

## Trigger

The user provides a French adjective to add to the project.

## Input

- **Adjective value**: the French word itself (e.g. `magnifique`, `élégant`).
- **Constant name**: the C# identifier to use. If not provided, derive it from the adjective value by removing diacritics and using PascalCase (e.g. `élégant` → `Elegant`, `déterminé` → `Determine`).

## Steps

### 1. Add the constant to `Constants.cs`

- Open `FrenchAdjectives\Constants.cs`.
- Determine the **first letter** of the adjective value (strip diacritics: `é` → `e`, `ç` → `c`, etc.) to identify the correct `#region "{Letter}" Adjectives` block.
- Add a new line inside that region following the existing pattern:

```csharp
public const string <ConstantName> = "<adjective value>";
```

- Append the new entry **at the end** of the region, just before the `#endregion` line.

### 2. Add the constant to `AdjectiveRepository.cs`

- Open `FrenchAdjectives\AdjectiveRepository.cs`.
- Locate the `public static readonly IReadOnlyList<string>` array that corresponds to the same uppercase letter (e.g. list `D` for an adjective starting with `d`/`d`).
- Append `Constants.<ConstantName>,` as the **last entry** in that array, just before the closing `};`.

> No other changes are needed — the `All` list and `BuildLetterMap()` already aggregate the per-letter arrays automatically.

### 3. Create the JSON sentence file

- Determine the folder letter by stripping diacritics from the first character and uppercasing it (e.g. `é` → `E`).
- Create the file at `FrenchAdjectives\Sentences\{Letter}\{adjective value}.json`.
- The file name must exactly match the adjective **value** (including any accented characters), with a `.json` extension.
- Use this structure:

```json
{
  "description": "<Two sentences in French describing the adjective — what it means and how it is typically used.>",
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

- **`description`**: Write exactly **2 French sentences**. The first sentence should explain the meaning of the adjective. The second should describe typical usage contexts.
- **`sentences`**: Provide exactly **5 French sentences** that use the adjective naturally. Each sentence should be **at least 15 words long** — avoid very short or trivial sentences.
- The file must be encoded as **UTF-8 without BOM**.

### 4. Validate

- Build the solution and confirm there are no compilation errors.

## Example

Given the adjective `féroce`:

**Constants.cs** — inside `#region "F" Adjectives`, before `#endregion`:

```csharp
public const string Feroce = "féroce";
```

**AdjectiveRepository.cs** — last entry in the `F` array:

```csharp
Constants.Feroce,
```

**File** `FrenchAdjectives\Sentences\F\féroce.json`:

```json
{
  "description": "L'adjectif « féroce » décrit quelque chose ou quelqu'un d'une grande violence, d'une cruauté sauvage ou d'une intensité redoutable. On l'emploie couramment pour qualifier des animaux, des combats, des critiques ou des appétits dans des registres variés allant du littéraire au quotidien.",
  "sentences": [
    "Le lion féroce surveillait son territoire depuis le sommet de la colline, prêt à défendre sa fierté contre tout intrus.",
    "Les critiques ont été particulièrement féroces à l'égard du nouveau film, reprochant au réalisateur un manque flagrant d'originalité.",
    "Une compétition féroce s'est installée entre les deux entreprises pour conquérir le marché des nouvelles technologies.",
    "Le vent féroce de la tempête a arraché plusieurs toitures dans le village côtier pendant la nuit de samedi.",
    "Malgré son apparence féroce, le chien du voisin se révèle être un animal doux et affectueux avec les enfants."
  ]
}
```
