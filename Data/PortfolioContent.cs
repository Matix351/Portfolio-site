using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace Portfolio.Data;

public sealed class PortfolioContent(HttpClient http)
{
    private Task<Content>? pending;
    public Task<Content> Load() => pending ??= LoadCore();
    private async Task<Content> LoadCore()
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "data/portfolio.json");
            request.SetBrowserRequestCache(BrowserRequestCache.NoStore);
            using var response = await http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Content>() ?? new();
        }
        catch { pending = null; throw; }
    }
    public static readonly Category[] Categories = [
        new("games/2d", "2D Games", "Small worlds. Big ideas.", "Arcade mechanics, tilemap worlds, and playful experiments in two dimensions.", "01", "2D"),
        new("games/3d", "3D Games", "Another dimension of play.", "Interactive worlds, satisfying mechanics, and systems that bring them to life.", "02", "3D"),
        new("games/tools", "Unity Tools & Systems", "Build once. Create more.", "Reusable gameplay architecture and editor tools for a better development workflow.", "03", "{}"),
        new("android", "Android Projects", "Made for the small screen.", "Mobile applications and game prototypes, built with Unity, Kotlin, and Firebase.", "04", "[]"),
        new("other", "Other Projects", "Room to experiment.", "Explorations in programming, artificial intelligence, and everything in between.", "05", "↗")
    ];
}
public record Category(string Path, string Name, string Title, string Description, string Number, string Symbol);
public sealed class Content
{
    public Profile Profile { get; set; } = new();
    public List<Project> Projects { get; set; } = [];
}
public sealed class Profile
{
    public string Name { get; set; } = "Mateusz Ciszek";
    public string Role { get; set; } = "C# & Unity Developer";
    public string Bio { get; set; } = "";
    public string Github { get; set; } = "https://github.com/Matix351";
    public string? ContactEmail { get; set; }
    public string? ContactUrl { get; set; }
    public string? LinkedIn { get; set; }
    public string[] Skills { get; set; } = [];
    public List<Experience> Experience { get; set; } = [];
}
public record Experience(string Role, string Company, string Dates, string Description);
public sealed class Project
{
    public string Slug { get; set; } = "";
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public string Summary { get; set; } = "";
    public string? Subtitle { get; set; }
    public string? Technologies { get; set; }
    public string? FocusAreas { get; set; }
    public int? ImageWidth { get; set; }
    public int? ImageHeight { get; set; }
    public string Status { get; set; } = "";
    public string Role { get; set; } = "";
    public string[] Tags { get; set; } = [];
    public string[] Overview { get; set; } = [];
    public string? Challenge { get; set; }
    public string? Solution { get; set; }
    public string? Lessons { get; set; }
    public string? Image { get; set; }
    public string? ImageAlt { get; set; }
    public string? VideoUrl { get; set; }
    public string Art { get; set; } = "code";
    public bool Featured { get; set; }
    public List<ProjectLink> Links { get; set; } = [];
    public List<ProjectImage> Screenshots { get; set; } = [];
    public List<ScreenshotGroup> ScreenshotGroups { get; set; } = [];
    public bool ShowScreenshotCaptions { get; set; } = true;
    public string ScreenshotsHeading { get; set; } = "Gameplay screenshots.";
    public List<MiniGame> MiniGames { get; set; } = [];
    public List<ProjectSection> Sections { get; set; } = [];
    public List<GameVideo> Videos { get; set; } = [];
    public string VideosHeading { get; set; } = "Gameplay.";
    public bool ShowDevelopmentNotice { get; set; } = true;
}
public sealed class ProjectSection
{
    public string? Badge { get; set; }
    public List<ProjectImage> Gallery { get; set; } = [];
    public string Title { get; set; } = "";
    public string Summary { get; set; } = "";
    public string[] Paragraphs { get; set; } = [];
    public ProjectImage? Image { get; set; }
    public List<ProjectImage> AdditionalImages { get; set; } = [];
    public string? Caption { get; set; }
}
public sealed class MiniGame
{
    public List<GameVideo> Videos { get; set; } = [];
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string[] TechnicalNotes { get; set; } = [];
    public string? VideoUrl { get; set; }
}
public record GameVideo(string Title, string YoutubeId);
public record ProjectLink(string Label, string Url);
public record ProjectImage(string Url, string Alt, string? CropStyle = null, string? Caption = null, int? Width = null, int? Height = null);
public record ScreenshotGroup(string Title, List<ProjectImage> Images);
