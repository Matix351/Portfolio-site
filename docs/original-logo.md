# Original m.c logo

The original wordmark is preserved in `Components/OriginalBrandMark.razor`, with its existing `.brand-mark` styles in `wwwroot/css/portfolio.css`.

To restore it, replace the profile image inside the header or footer home link in `Layout/MainLayout.razor` with `<OriginalBrandMark />`. Keep the home link's accessible label.

The original browser icon is also retained at `wwwroot/favicon.svg`. Restore its link in `wwwroot/index.html` if desired.

The photo logo remains active; these files are a reusable backup.
