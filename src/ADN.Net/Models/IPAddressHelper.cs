using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace ADN.Net
{
    /// <summary>
    /// Class to calculate filtered values.
    /// </summary>
    public static class IPAddressHelper
    {
        /// <summary>
        /// Get all local IP addresses.
        /// </summary>
        /// <returns>All local IP addresses.</returns>
        /// <example>
        /// <code lang="csharp">
        /// IPAddress[] result = IPAddressHelper.GetLocalIPAddresses();
        /// </code>
        /// </example>
        public static IPAddress[] GetLocalIPAddresses()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                throw new Exception("No network adapters with an IPv4 address in the system.");
            }

            var host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                .ToArray();
        }
    }
}
