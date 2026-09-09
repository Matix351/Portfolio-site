// Restore a nested GitHub Pages URL before Blazor starts, retaining query and fragment.
(() => {
  const params = new URLSearchParams(location.search);
  const route = params.get('__route');
  if (route && route.startsWith('/Portfolio-site/') && !route.startsWith('//')) {
    history.replaceState(null, '', route);
  }
})();
