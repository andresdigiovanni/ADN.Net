<a name='assembly'></a>
# ADN.Net

## Contents

- [IPAddressExtensions](#T-ADN-Net-IPAddressExtensions 'ADN.Net.IPAddressExtensions')
  - [GetBroadcastAddress(ipAddress,subnetMask)](#M-ADN-Net-IPAddressExtensions-GetBroadcastAddress-System-Net-IPAddress,System-Net-IPAddress- 'ADN.Net.IPAddressExtensions.GetBroadcastAddress(System.Net.IPAddress,System.Net.IPAddress)')
  - [GetNetworkAddress(ipAddress,subnetMask)](#M-ADN-Net-IPAddressExtensions-GetNetworkAddress-System-Net-IPAddress,System-Net-IPAddress- 'ADN.Net.IPAddressExtensions.GetNetworkAddress(System.Net.IPAddress,System.Net.IPAddress)')
  - [GetSubnetMask(ipAddress)](#M-ADN-Net-IPAddressExtensions-GetSubnetMask-System-Net-IPAddress- 'ADN.Net.IPAddressExtensions.GetSubnetMask(System.Net.IPAddress)')
  - [IsInSameSubnet(address2,address,subnetMask)](#M-ADN-Net-IPAddressExtensions-IsInSameSubnet-System-Net-IPAddress,System-Net-IPAddress,System-Net-IPAddress- 'ADN.Net.IPAddressExtensions.IsInSameSubnet(System.Net.IPAddress,System.Net.IPAddress,System.Net.IPAddress)')
- [IPAddressHelper](#T-ADN-Net-IPAddressHelper 'ADN.Net.IPAddressHelper')
  - [GetLocalIPAddresses()](#M-ADN-Net-IPAddressHelper-GetLocalIPAddresses 'ADN.Net.IPAddressHelper.GetLocalIPAddresses')

<a name='T-ADN-Net-IPAddressExtensions'></a>
## IPAddressExtensions `type`

##### Namespace

ADN.Net

##### Summary

A static class of extension methods for [IPAddress](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.IPAddress 'System.Net.IPAddress').

<a name='M-ADN-Net-IPAddressExtensions-GetBroadcastAddress-System-Net-IPAddress,System-Net-IPAddress-'></a>
### GetBroadcastAddress(ipAddress,subnetMask) `method`

##### Summary

Get broadcast address of the specific IP address.

##### Returns

Broadcast address.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ipAddress | [System.Net.IPAddress](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.IPAddress 'System.Net.IPAddress') | IP address. |
| subnetMask | [System.Net.IPAddress](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.IPAddress 'System.Net.IPAddress') | Subnet mask of the target IP address. |

##### Example

```csharp
var ipAddress = IPAddress.Parse("192.168.1.101");
var subnetMask = IPAddress.Parse("255.255.255.0");
var result = ipAddress
    .GetBroadcastAddress(subnetMask)
    .ToString();
/*
result is "192.168.1.255"
*/ 
```

<a name='M-ADN-Net-IPAddressExtensions-GetNetworkAddress-System-Net-IPAddress,System-Net-IPAddress-'></a>
### GetNetworkAddress(ipAddress,subnetMask) `method`

##### Summary

Get network address of the specific IP address.

##### Returns

Network address.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ipAddress | [System.Net.IPAddress](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.IPAddress 'System.Net.IPAddress') | IP address. |
| subnetMask | [System.Net.IPAddress](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.IPAddress 'System.Net.IPAddress') | Subnet mask of the target IP address. |

##### Example

```csharp
var ipAddress = IPAddress.Parse("192.168.1.101");
var subnetMask = IPAddress.Parse("255.255.255.0");
var result = ipAddress
    .GetNetworkAddress(subnetMask)
    .ToString();
/*
result is "192.168.1.0"
*/ 
```

<a name='M-ADN-Net-IPAddressExtensions-GetSubnetMask-System-Net-IPAddress-'></a>
### GetSubnetMask(ipAddress) `method`

##### Summary

Get subnet mask of the specific IP address.

##### Returns

Subnet mask.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ipAddress | [System.Net.IPAddress](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.IPAddress 'System.Net.IPAddress') | IP address. |

##### Example

```csharp
var ipAddress = IPAddress.Parse("192.168.1.101");
var result = ipAddress.GetSubnetMask(); 
```

<a name='M-ADN-Net-IPAddressExtensions-IsInSameSubnet-System-Net-IPAddress,System-Net-IPAddress,System-Net-IPAddress-'></a>
### IsInSameSubnet(address2,address,subnetMask) `method`

##### Summary

Check if two IP addresses are in the same subnet.

##### Returns

True if the two IP addresses are in the same subnet, false otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| address2 | [System.Net.IPAddress](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.IPAddress 'System.Net.IPAddress') | IP address 2. |
| address | [System.Net.IPAddress](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.IPAddress 'System.Net.IPAddress') | IP address. |
| subnetMask | [System.Net.IPAddress](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.IPAddress 'System.Net.IPAddress') | Subnet mask of the target IP address. |

##### Example

```csharp
var ipAddress = IPAddress.Parse("192.168.1.101");
var ipAddress2 = IPAddress.Parse("192.168.1.102");
var subnetMask = IPAddress.Parse("255.255.255.0");
var result = ipAddress
    .IsInSameSubnet(ipAddress2, subnetMask)
    .ToString();
/*
result is true.
*/ 
```

<a name='T-ADN-Net-IPAddressHelper'></a>
## IPAddressHelper `type`

##### Namespace

ADN.Net

##### Summary

Class to calculate filtered values.

<a name='M-ADN-Net-IPAddressHelper-GetLocalIPAddresses'></a>
### GetLocalIPAddresses() `method`

##### Summary

Get all local IP addresses.

##### Returns

All local IP addresses.

##### Parameters

This method has no parameters.

##### Example

```csharp
IPAddress[] result = IPAddressHelper.GetLocalIPAddresses(); 
```
