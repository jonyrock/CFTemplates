import http.client
conn = http.client.HTTPConnection("127.0.0.1:8999")
conn.request("GET", "/")