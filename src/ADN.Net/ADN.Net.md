# ADN.Net

# Content

- [IPAddressExtensions](#T:ADN.Net.IPAddressExtensions)

  - [GetBroadcastAddress(ipAddress, subnetMask)](#IPAddressExtensions.GetBroadcastAddress(ipAddress,subnetMask))

  - [GetNetworkAddress(ipAddress, subnetMask)](#IPAddressExtensions.GetNetworkAddress(ipAddress,subnetMask))

  - [GetSubnetMask(ipAddress)](#IPAddressExtensions.GetSubnetMask(ipAddress))

  - [IsInSameSubnet(address2, address, subnetMask)](#IPAddressExtensions.IsInSameSubnet(address2,address,subnetMask))

- [IPAddressHelper](#T:ADN.Net.IPAddressHelper)

  - [GetLocalIPAddresses](#IPAddressHelper.GetLocalIPAddresses)

<a name='T:ADN.Net.IPAddressExtensions'></a>


## IPAddressExtensions

A static class of extension methods for .

<a name='IPAddressExtensions.GetBroadcastAddress(ipAddress,subnetMask)'></a>


### GetBroadcastAddress(ipAddress, subnetMask)

Get broadcast address of the specific IP address.


#### Parameters

| Name | Description |
| ---- | ----------- |
| ipAddress | *System.Net.IPAddress*<br>IP address. |

#### Parameters

| subnetMask | *System.Net.IPAddress*<br>Subnet mask of the target IP address. |


#### Returns

Broadcast address.


#### Example

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

<a name='IPAddressExtensions.GetNetworkAddress(ipAddress,subnetMask)'></a>


### GetNetworkAddress(ipAddress, subnetMask)

Get network address of the specific IP address.


#### Parameters

| Name | Description |
| ---- | ----------- |
| ipAddress | *System.Net.IPAddress*<br>IP address. |

#### Parameters

| subnetMask | *System.Net.IPAddress*<br>Subnet mask of the target IP address. |


#### Returns

Network address.


#### Example

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

<a name='IPAddressExtensions.GetSubnetMask(ipAddress)'></a>


### GetSubnetMask(ipAddress)

Get subnet mask of the specific IP address.


#### Parameters

| Name | Description |
| ---- | ----------- |
| ipAddress | *System.Net.IPAddress*<br>IP address. |


#### Returns

Subnet mask.


#### Example

```csharp
var ipAddress = IPAddress.Parse("192.168.1.101");

var result = ipAddress.GetSubnetMask();
```

<a name='IPAddressExtensions.IsInSameSubnet(address2,address,subnetMask)'></a>


### IsInSameSubnet(address2, address, subnetMask)

Check if two IP addresses are in the same subnet.


#### Parameters

| Name | Description |
| ---- | ----------- |
| address2 | *System.Net.IPAddress*<br>IP address 2. |

#### Parameters

| address | *System.Net.IPAddress*<br>IP address. |

#### Parameters

| subnetMask | *System.Net.IPAddress*<br>Subnet mask of the target IP address. |


#### Returns

True if the two IP addresses are in the same subnet, false otherwise.


#### Example

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

<a name='T:ADN.Net.IPAddressHelper'></a>


## IPAddressHelper

Class to calculate filtered values.

<a name='IPAddressHelper.GetLocalIPAddresses'></a>


### GetLocalIPAddresses

Get all local IP addresses.


#### Returns

All local IP addresses.


#### Example

```csharp
IPAddress[] result = IPAddressHelper.GetLocalIPAddresses();
```

