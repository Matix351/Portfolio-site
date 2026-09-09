"""Check deployment invariants and editable project data with Python's standard library."""
import json
import re
import sys
from pathlib import Path
from urllib.parse import urlparse

root = Path(sys.argv[1] if len(sys.argv) > 1 else 'publish/wwwroot')
index = (root / 'index.html').read_text(encoding='utf-8')
assert '<base href="/Portfolio-site/"' in index, 'Incorrect project base path'
for name in ['404.html', 'route-restore.js', '.nojekyll', 'css/portfolio.css', 'favicon.svg']:
    assert (root / name).is_file(), f'Missing asset: {name}'
scripts = re.findall(r'<script[^>]+src="([^"]+)"', index)
for src in scripts:
    assert (root / urlparse(src).path).is_file(), f'Missing entry script: {src}'
assert any((root / '_framework').glob('*.wasm')), 'Missing WebAssembly assets'
data = json.loads((root / 'data/portfolio.json').read_text(encoding='utf-8'))
slugs = [p['slug'] for p in data['projects']]
def check_media(value):
    if isinstance(value, dict):
        for child in value.values():
            check_media(child)
    elif isinstance(value, list):
        for child in value:
            check_media(child)
    elif isinstance(value, str) and value.startswith('images/'):
        assert (root / value).is_file(), f'Missing project image: {value}'

check_media(data)
assert len(slugs) == len(set(slugs)), 'Project slugs must be unique'
categories = {'games/2d', 'games/3d', 'games/tools', 'android', 'other'}
for project in data['projects']:
    assert project['category'] in categories
    assert re.fullmatch(r'[a-z0-9]+(?:-[a-z0-9]+)*', project['slug'])
    for link in project.get('links', []):
        assert urlparse(link['url']).scheme == 'https', 'Use HTTPS project links'
print(f'Passed: base path, entry scripts, static assets, WebAssembly, and {len(slugs)} project records.')
