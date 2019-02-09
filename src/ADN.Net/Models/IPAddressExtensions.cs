using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace ADN.Net
{
    /// <summary>
    /// A static class of extension methods for <see cref="IPAddress"/>.
    /// </summary>
    public static class IPAddressExtensions
    {
        /// <summary>
        /// Get broadcast address of the specific IP address.
        /// </summary>
        /// <param name="ipAddress">IP address.</param>
        /// <param name="subnetMask">Subnet mask of the target IP address.</param>
        /// <returns>Broadcast address.</returns>
        /// <example>
        /// <code lang="csharp">
        /// var ipAddress = IPAddress.Parse("192.168.1.101");
        /// var subnetMask = IPAddress.Parse("255.255.255.0");
        /// 
        /// var result = ipAddress
        ///     .GetBroadcastAddress(subnetMask)
        ///     .ToString();
        /// 
        /// /*
        /// result is "192.168.1.255"
        /// */
        /// </code>
        /// </example>
        public static IPAddress GetBroadcastAddress(this IPAddress ipAddress, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = ipAddress.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
            {
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
            }

            byte[] broadcastAddressBytes = new byte[ipAdressBytes.Length];

            for (int i = 0; i < broadcastAddressBytes.Length; i++)
            {
                broadcastAddressBytes[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }

            return new IPAddress(broadcastAddressBytes);
        }

        /// <summary>
        /// Get network address of the specific IP address.
        /// </summary>
        /// <param name="ipAddress">IP address.</param>
        /// <param name="subnetMask">Subnet mask of the target IP address.</param>
        /// <returns>Network address.</returns>
        /// <example>
        /// <code lang="csharp">
        /// var ipAddress = IPAddress.Parse("192.168.1.101");
        /// var subnetMask = IPAddress.Parse("255.255.255.0");
        /// 
        /// var result = ipAddress
        ///     .GetNetworkAddress(subnetMask)
        ///     .ToString();
        /// 
        /// /*
        /// result is "192.168.1.0"
        /// */
        /// </code>
        /// </example>
        public static IPAddress GetNetworkAddress(this IPAddress ipAddress, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = ipAddress.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
            {
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
            }

            byte[] networkAddressBytes = new byte[ipAdressBytes.Length];

            for (int i = 0; i < networkAddressBytes.Length; i++)
            {
                networkAddressBytes[i] = (byte)(ipAdressBytes[i] & (subnetMaskBytes[i]));
            }

            return new IPAddress(networkAddressBytes);
        }

        /// <summary>
        /// Get subnet mask of the specific IP address.
        /// </summary>
        /// <param name="ipAddress">IP address.</param>
        /// <returns>Subnet mask.</returns>
        /// <example>
        /// <code lang="csharp">
        /// var ipAddress = IPAddress.Parse("192.168.1.101");
        /// 
        /// var result = ipAddress.GetSubnetMask();
        /// </code>
        /// </example>
        public static IPAddress GetSubnetMask(this IPAddress ipAddress)
        {
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in networkInterface.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (unicastIPAddressInformation.Address.Equals(ipAddress))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }

            throw new ArgumentException("Unable to find the subnet mask for the IP address.");
        }

        /// <summary>
        /// Check if two IP addresses are in the same subnet.
        /// </summary>
        /// <param name="address2">IP address 2.</param>
        /// <param name="address">IP address.</param>
        /// <param name="subnetMask">Subnet mask of the target IP address.</param>
        /// <returns>True if the two IP addresses are in the same subnet, false otherwise.</returns>
        /// <example>
        /// <code lang="csharp">
        /// var ipAddress = IPAddress.Parse("192.168.1.101");
        /// var ipAddress2 = IPAddress.Parse("192.168.1.102");
        /// var subnetMask = IPAddress.Parse("255.255.255.0");
        /// 
        /// var result = ipAddress
        ///     .IsInSameSubnet(ipAddress2, subnetMask)
        ///     .ToString();
        /// 
        /// /*
        /// result is true.
        /// */
        /// </code>
        /// </example>
        public static bool IsInSameSubnet(this IPAddress address2, IPAddress address, IPAddress subnetMask)
        {
            IPAddress network1 = address.GetNetworkAddress(subnetMask);
            IPAddress network2 = address2.GetNetworkAddress(subnetMask);

            return network1.Equals(network2);
        }
    }
}
