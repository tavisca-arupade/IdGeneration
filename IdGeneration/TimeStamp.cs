using System;

namespace IDGeneration
{
    public static class TimeStamp
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1);

        public static byte[] GetCurrentTime()
        {
            return BitConverter.GetBytes((Int64)DateTime.UtcNow.Subtract(_epoch).TotalSeconds);
        }
    }
}