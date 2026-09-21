namespace GodwinPortfolioApi.Models;

public sealed class PortfolioProfile
{
    public string Name { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Summary { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string GitHub { get; init; } = string.Empty;
    public string PortfolioUrl { get; init; } = string.Empty;
    public string Education { get; init; } = string.Empty;
}