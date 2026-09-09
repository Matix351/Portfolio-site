"""Serve published assets with GitHub Pages-style 404 responses for route testing."""
from http.server import SimpleHTTPRequestHandler, ThreadingHTTPServer
from pathlib import Path
from urllib.parse import unquote, urlsplit

root = (Path(__file__).resolve().parent.parent / 'publish/wwwroot').resolve()
class Handler(SimpleHTTPRequestHandler):
    def translate_path(self, path):
        path = unquote(urlsplit(path).path)
        relative = path.removeprefix('/Portfolio-site/') if path.startswith('/Portfolio-site/') else '__outside_base__'
        target = (root / relative).resolve()
        return str(target if target.is_relative_to(root) else root / '__invalid__')
    def send_error(self, code, message=None, explain=None):
        if code == 404:
            body = (root / '404.html').read_bytes()
            self.send_response(404)
            self.send_header('Content-Type', 'text/html; charset=utf-8')
            self.send_header('Content-Length', str(len(body)))
            self.end_headers()
            self.wfile.write(body)
        else: super().send_error(code, message, explain)
print('Preview: http://localhost:5081/Portfolio-site/', flush=True)
ThreadingHTTPServer(('127.0.0.1', 5081), Handler).serve_forever()
