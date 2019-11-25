using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace IDGeneration
{
    public static class MachineAddress
    {
        private static int macAddressHashcode = NetworkInterface
                        .GetAllNetworkInterfaces()
                        .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                        .Select(nic => nic.GetHashCode())
                        .FirstOrDefault();

        public static byte[] GetMacAddress()
        {
            return BitConverter.GetBytes(macAddressHashcode);
        }
    }
}