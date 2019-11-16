using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace IDGeneration
{
    public class IdGenerator
    {
        private readonly DateTime _epoch = new DateTime(1970, 1, 1);
        Random random;
        byte[] id = new byte[9];                //9 bytes Id buffer
        byte[] timestamp = new byte[4];         //4 bytes timestamp
        byte[] macAddress = new byte[3];        //3 bytes mac address
        byte[] randomNumber = new byte[2];      //2 bytes random number

        public IdGenerator()
        {
            random = new Random();
        }

        public byte[] GetID()
        {
            timestamp = BitConverter.GetBytes((Int64)DateTime.UtcNow.Subtract(_epoch).TotalSeconds);

            int macAddressHashcode = NetworkInterface
                        .GetAllNetworkInterfaces()
                        .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                        .Select(nic => nic.GetHashCode())
                        .FirstOrDefault();

            macAddress = BitConverter.GetBytes(macAddressHashcode);

            random.NextBytes(randomNumber);

            id[0] = timestamp[0];
            id[1] = timestamp[1];
            id[2] = timestamp[2];
            id[3] = timestamp[3];
            id[4] = macAddress[1];
            id[5] = macAddress[2];
            id[6] = macAddress[3];
            id[7] = randomNumber[0];
            id[8] = randomNumber[1];

            return id;
        }
    }
}