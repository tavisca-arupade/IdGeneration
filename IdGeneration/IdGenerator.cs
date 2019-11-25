namespace IDGeneration
{
    public class IdGenerator
    {
        byte[] id = new byte[9];                //9 bytes Id buffer
        byte[] timestamp = new byte[4];         //4 bytes timestamp
        byte[] macAddress = new byte[3];        //3 bytes mac address
        byte[] randomNumber = new byte[2];      //2 bytes random number
        
        public byte[] GetID()
        {
            timestamp = TimeStamp.GetCurrentTime();
            macAddress = MachineAddress.GetMacAddress();
            randomNumber = RandomNumber.GetRandomNumber();
            return CreateId();
        }

        private byte[] CreateId()
        {

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