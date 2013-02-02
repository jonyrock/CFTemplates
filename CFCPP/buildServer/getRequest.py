import http.server
import socketserver
import sys

class SilentRequestHandler(http.server.SimpleHTTPRequestHandler): 
	def log_message(self, *args):
		"""Don't log anything"""

    

PORT = int(sys.argv[1])
print (PORT)
Handler = SilentRequestHandler
httpd = socketserver.TCPServer(("", PORT), Handler)
httpd.handle_request()