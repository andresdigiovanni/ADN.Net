using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace ADN.Net.Tests
{
    public class IPAddressExtensionsTest
    {
        [Theory]
        [InlineData("192.168.1.101", "255.255.255.0", "192.168.1.255")]
        [InlineData("192.168.1.101", "255.255.0.0", "192.168.255.255")]
        [InlineData("192.168.1.101", "255.0.0.0", "192.255.255.255")]
        [InlineData("192.168.2.101", "255.255.254.0", "192.168.3.255")]
        [InlineData("192.168.2.101", "255.254.0.0", "192.169.255.255")]
        [InlineData("192.168.2.101", "254.0.0.0", "193.255.255.255")]
        public void GetBroadcastAddress(string ipAddress, string subnetMask, string expected)
        {
            var result = IPAddress.Parse(ipAddress)
                .GetBroadcastAddress(IPAddress.Parse(subnetMask))
                .ToString();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetBroadcastAddress_Exception()
        {
            var ipAddress = IPAddress.Parse("192.168.1.101");
            var subnetMask = IPAddress.Parse("0:0:0:0:0:0:0:1");

            Assert.Throws<ArgumentException>(() => ipAddress.GetBroadcastAddress(subnetMask));
        }

        [Theory]
        [InlineData("192.168.1.101", "255.255.255.0", "192.168.1.0")]
        [InlineData("192.168.1.101", "255.255.0.0", "192.168.0.0")]
        [InlineData("192.168.1.101", "255.0.0.0", "192.0.0.0")]
        [InlineData("192.168.3.101", "255.255.254.0", "192.168.2.0")]
        [InlineData("192.169.3.101", "255.254.0.0", "192.168.0.0")]
        [InlineData("193.169.3.101", "254.0.0.0", "192.0.0.0")]
        public void GetNetworkAddress(string ipAddress, string subnetMask, string expected)
        {
            var result = IPAddress.Parse(ipAddress)
                .GetNetworkAddress(IPAddress.Parse(subnetMask))
                .ToString();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetNetworkAddress_Exception()
        {
            var ipAddress = IPAddress.Parse("192.168.1.101");
            var subnetMask = IPAddress.Parse("0:0:0:0:0:0:0:1");

            Assert.Throws<ArgumentException>(() => ipAddress.GetNetworkAddress(subnetMask));
        }

        [Theory]
        [InlineData("192.168.1.101", "192.168.1.102", "255.255.255.0", true)]
        [InlineData("192.168.2.101", "192.168.1.102", "255.255.255.0", false)]
        [InlineData("192.168.1.101", "192.169.1.102", "255.0.0.0", true)]
        [InlineData("192.168.1.101", "193.169.1.102", "255.0.0.0", false)]
        public void IsInSameSubnet(string ipAddress, string ipAddress2, string subnetMask, bool expected)
        {
            var result = IPAddress.Parse(ipAddress)
                .IsInSameSubnet(IPAddress.Parse(ipAddress2), IPAddress.Parse(subnetMask));

            Assert.Equal(expected, result);
        }
    }
}
