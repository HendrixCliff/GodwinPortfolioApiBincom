namespace GodwinPortfolioApi.Models;

public sealed class SkillGroup
{
    public string Category { get; init; } = string.Empty;
    public List<string> Skills { get; init; } = [];
}