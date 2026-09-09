# Mateusz Ciszek · Portfolio

Standalone Blazor WebAssembly (.NET 10) portfolio for **https://matix351.github.io/Portfolio-site/**. Original repository purpose: My Portfolio web page.

## Run locally

Install the .NET 10 SDK, then run from this directory:

```sh
dotnet restore
dotnet run -- --pathbase=/Portfolio-site
```

Open the printed localhost address with `/Portfolio-site/` appended. The base path is intentionally identical to production. No database, server application, or API keys are needed.

## Publish and verify

```sh
dotnet publish Portfolio.csproj -c Release -o publish
python scripts/check_publish.py publish/wwwroot
python scripts/serve_preview.py
```

Open `http://localhost:5081/Portfolio-site/`. This local static server reproduces GitHub Pages 404 behavior, including redirecting deep links through `404.html`. Verify direct navigation and refresh at `/Portfolio-site/games/3d` and `/Portfolio-site/projects/a-game-about-clicking-a-rock`. Query strings and fragments survive the redirect. Unknown routes show an in-app 404. Stop the server with Ctrl+C.

## GitHub Pages

1. Push this project to the `main` branch of `Matix351/Portfolio-site`.
2. In the repository, select **Settings → Pages → Build and deployment → Source → GitHub Actions**.
3. Ensure Actions is enabled and the `github-pages` environment permits deployment from `main`.
4. Run **Actions → Build and deploy portfolio → Run workflow**, or push a commit to `main`.
5. Open the deployment URL displayed by the workflow.

The workflow builds pull requests without deploying them. Main-branch pushes publish the release `wwwroot` artifact. It uses the automatic GitHub token with scoped Pages permissions; no personal token is required. The `.nojekyll` file is included. Generated framework files are uploaded directly, avoiding Git line-ending changes to their integrity hashes.

GitHub Free requires a public repository for Pages. A private repository requires an eligible paid plan. If Pages settings are unavailable, check the repository's plan/visibility before deployment; this project does not change visibility automatically.

## Edit your content

Project records, skills, experience, bio, and optional contact links live in `wwwroot/data/portfolio.json`. No résumé or personal contact details are included. Set `profile.contactEmail` or `profile.contactUrl` only when you want that information public; null values hide the buttons.

To add a project, copy an existing object and set a unique lowercase hyphenated `slug`. Available categories are `games/2d`, `games/3d`, `games/tools`, `android`, and `other`. Setting `featured` to true includes it on the home page. Its detail route is automatically `projects/{slug}`. Add that URL to `wwwroot/sitemap.xml`.

Optional fields:

- `image`, `imageAlt`: card and detail cover. Use a path such as `images/my-game/cover.webp` (without a leading slash) for files under `wwwroot`.
- `screenshots`: objects containing `url` and descriptive `alt` text.
- `videoUrl`: an HTTPS YouTube/gameplay link; shown only when provided.
- `links`: objects containing `label` and `url`, for source, demo, download, or store links. Use trusted HTTPS URLs.
- `challenge`, `solution`, `lessons`: technical case-study sections, hidden until supplied.
- `overview`: an array of paragraphs. `role`, `status`, `tags`, and `summary` describe the project.
- `art`: `framework`, `mobile`, or `path` for an explicitly labelled concept illustration while screenshots are unavailable.

The 2D category includes the 100 in 1 Game Collection showcase, using the supplied cover, descriptions, and 14 YouTube clips. Edit its `miniGames` array to change individual game descriptions, `technicalNotes`, and `videos` (each with a `title` and `youtubeId`). Videos use click-to-load YouTube embeds and offer direct watch links. Other project descriptions come from the supplied professional résumé; the Steam listing supplies rock-game artwork and its coming-soon status. Update that status when the release changes.

The home featured game panel is in `Pages/Home.razor`; update it if you change the featured game. Site branding and footer are in `Layout/MainLayout.razor`. Visual tokens and responsive styling are in `wwwroot/css/portfolio.css`. UI uses native HTML/CSS, without a UI library dependency.

## Accessibility and external assets

Includes a skip link, keyboard focus indicators, heading focus on navigation, mobile menu with expanded state, descriptive media text, and reduced-motion support. Steam artwork is loaded from Steam's CDN, and Google Fonts supplies optional typography with system fallbacks. Other project visuals are CSS concept illustrations, not screenshots. Replace external image URLs with owned local assets if desired.

Standalone WebAssembly has an initial runtime download. Page titles update in the browser; social preview metadata is shared across routes because GitHub Pages cannot render project-specific metadata on a server. Contacts and links are public client-side data: never add credentials to this site.

## Branch workflow

`main` publishes the website. Make future content changes on `develop`, then merge them into `main` when ready to publish. This repository starts from a clean snapshot; no history from the earlier private repository is included.
