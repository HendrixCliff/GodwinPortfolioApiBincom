namespace GodwinPortfolioApi.Models;

public sealed class Project
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public List<string> Technologies { get; init; } = [];
}