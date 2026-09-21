namespace GodwinPortfolioApi.Models;

public sealed class Experience
{
    public string Company { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    public string Period { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public List<string> Highlights { get; init; } = [];
    public List<string> Technologies { get; init; } = [];
}