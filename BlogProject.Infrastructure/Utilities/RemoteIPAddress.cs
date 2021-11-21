using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BlogProject.Infrastructure.Utilities
{
    public static class RemoteIPAddress
    {
        public static string GetIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var item in host.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    return item.ToString();
                }
            }
            return "IP Adress not found!";
        }

        public static string IPAdress => GetIPAddress();
    }
}
