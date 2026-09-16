# Mateusz Ciszek · Portfolio

Portfolio of C#, Unity, Android, and software development projects, featuring technical case studies, screenshots, system diagrams, and video demonstrations.

**[Visit the portfolio](https://matix351.github.io/Portfolio-site/)**

Built with standalone **Blazor WebAssembly on .NET 10**, reusable Razor components, and custom responsive CSS. Content is stored in JSON. GitHub Actions builds and deploys the static site to GitHub Pages.

## Featured work

- **MaCster Framework** — reusable Unity dialogue, inventory, shop, and construction prototype systems, plus editor tooling and supporting utilities.
- **Unity games** — 2D and 3D projects, including the 100 in 1 Game Collection and A Game About Clicking A Rock.
- **Android applications** — mobile commerce and a mobile-game engineering thesis.
- **Software and experiments** — SmartBot API, Smart City Hub, and Unity ML-Agents pathfinding.

## Run locally

Requirements: **.NET 10 SDK**. **Python 3.9 or newer** is also needed for the publish checker and static preview scripts. No API keys or database are required.

From the repository root:

```sh
dotnet restore
dotnet run -- --pathbase=/Portfolio-site
```

Open [localhost:5167/Portfolio-site/](http://localhost:5167/Portfolio-site/), or use the printed server address with `/Portfolio-site/` appended. This base path matches the production GitHub Pages subdirectory.

## Build and preview the release

```sh
dotnet build Portfolio.csproj
dotnet publish Portfolio.csproj -c Release -o publish
python scripts/check_publish.py publish/wwwroot
python scripts/serve_preview.py
```

On Windows, `py -3` can replace `python` if that is how Python is installed.

Open [localhost:5081/Portfolio-site/](http://localhost:5081/Portfolio-site/). The preview serves `publish/wwwroot`; publish again after edits to update it. Stop the preview with Ctrl+C.

The checker validates the base path, entry scripts, local media, WebAssembly files, and project records. There is currently no dedicated automated test project. Check C# formatting with:

```sh
dotnet format Portfolio.csproj --verify-no-changes
```

Before publishing, check desktop and mobile layouts, image previews, video playback, and direct navigation or refresh at `/Portfolio-site/projects/macster-framework`. The static preview reproduces the Pages `404.html` redirect for client-side routing. Unknown routes show the site's not-found page.

## Repository structure

| Location | Purpose |
| --- | --- |
| `Pages/` | Home, categories, project details, about, and not-found routes |
| `Components/` | Shared project cards, artwork, content loading, and video players |
| `Layout/` | Navigation, branding, and footer |
| `Data/PortfolioContent.cs` | Content models, JSON loading, and category definitions |
| `wwwroot/data/portfolio.json` | Profile, experience, project copy, and media references |
| `wwwroot/images/` | Screenshots, illustrations, and diagrams grouped by project |
| `wwwroot/css/` | Shared visual tokens, responsive styles, and image-preview styling |
| `scripts/` | Published-output validation and local static preview |
| `.github/workflows/deploy.yml` | Release build and GitHub Pages deployment |

Component-specific styles live beside Razor components in `.razor.css` files.

## Update project content

Edit `wwwroot/data/portfolio.json`. Copy an existing project record, choose a unique lowercase hyphenated `slug`, and set its primary `category`. The detail route is generated as `projects/{slug}`. Add public routes to `wwwroot/sitemap.xml`.

Categories: `games/2d`, `games/3d`, `games/tools`, `android`, and `other`. Use `additionalCategories` to list a project in multiple categories without duplicating its record. Set `featured` to include it in the home page's selected work; the separate featured-game panel is configured in `Pages/Home.razor`.

Common content options:

- **Metadata:** `summary`, `subtitle`, `role`, `status`, `tags`, `technologies`, and `focusAreas`.
- **Overview:** `overview` contains paragraphs; `overviewAsList: true` renders them as bullets.
- **Sections:** `sections` support `title`, `summary`, `paragraphs`, optional `badge`, images, galleries, videos, links, code examples, and tables. `detailsAsList: true` renders paragraphs as bullets. Use an em dash surrounded by spaces between a bullet's bold label and its description.
- **Images:** `image` and `imageAlt` define a project cover; `art` selects a labeled concept illustration. Section image objects use `url`, `alt`, `caption`, `width`, and `height`. Sections support `image`, `gallery`, and `additionalImages`; project-level collections include `screenshots` and `screenshotGroups`.
- **Videos:** `videos` entries contain `title` and `youtubeId`, with optional `thumbnailUrl`. Within a section, `fullWidth: true` gives a video the full gallery width. Project-level video layouts use `featureFirstVideo` or `stackVideos`.
- **Other options:** `miniGames` groups individual games and demonstrations; `links` adds external destinations. Set `showDevelopmentNotice: false` to hide the default additional-media notice.

`Data/PortfolioContent.cs` defines the complete schema. Shared components handle presentation, so ordinary content edits do not require new page components.

## Media and accessibility

Keep local assets under `wwwroot/images/<project>/` and reference them as `images/<project>/file.png`, without a leading slash. Supply descriptive alternative text and dimensions where supported. Preserve screenshot aspect ratios and original UI content; use separate vector annotations for explanatory diagrams rather than redrawing screenshots.

Images open in the existing keyboard-accessible preview. Videos show thumbnails first and load a `youtube-nocookie.com` iframe after a click, with a direct YouTube link available. The site includes a skip link, visible focus states, responsive navigation, and reduced-motion support.

Local screenshots, SVG diagrams, and CSS concept illustrations appear alongside external media such as YouTube thumbnails and Steam artwork. Captions distinguish screenshots, diagrams, and illustrations. JSON content and static assets are public when deployed.

Page titles update during navigation. Social preview metadata is shared across routes because this static deployment does not render project-specific metadata on a server.

## Branches and deployment

Make changes on `develop`, verify the release, then merge into `main` to publish.

The **Build and deploy portfolio** workflow:

1. Builds and checks pull requests targeting `main`, without deploying them.
2. Publishes and validates release output on pushes to `main`.
3. Uploads `publish/wwwroot` and deploys it to GitHub Pages.

For setup, select **Settings → Pages → Build and deployment → Source → GitHub Actions** and allow the `github-pages` environment to deploy from `main`. The workflow uses GitHub's automatic token with scoped Pages permissions. It can also be started manually from the Actions tab.

The production base path is `/Portfolio-site/`. If the repository name or hosting location changes, update the base path, route fallback, sitemap, metadata, preview script, and publish checks together.
