using System;

namespace IDGeneration
{
    public static class RandomNumber
    {
        static Random random = new Random();

        public static byte[] GetRandomNumber()
        {
            byte[] randomNumber = new byte[2];
            random.NextBytes(randomNumber);
            return randomNumber;
        }
    }
}