using System;
using System.Linq;

namespace JunkCodeGeneratorApp.src
{
    public class RandomGenarator
    {
        private readonly Random random = new Random();

        public int Int(int min, int max)
        {
            Console.WriteLine();
            return random.Next(min, max);
        }

        public string String(int length, string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            string k = new string(
                Enumerable.Range(0, length).Select((_) => chars[Int(0, chars.Length)]).ToArray()
            );

            return k;
        }

        private int NextInt32()
        {
            int firstBits = random.Next(0, 1 << 4) << 28;
            int lastBits = random.Next(0, 1 << 28);
            return firstBits | lastBits;
        }
        private decimal NextDecimalSample()
        {
            var sample = 1m;
            while (sample >= 1)
            {
                var a = NextInt32();
                var b = NextInt32();
                //The high bits of 0.9999999999999999999999999999m are 542101086.
                var c = random.Next(542101087);
                sample = new Decimal(a, b, c, false, 28);
            }
            return sample;
        }
        public decimal Decimal(decimal minValue, decimal maxValue)
        {
            var nextDecimalSample = NextDecimalSample();
            return maxValue * nextDecimalSample + minValue * (1 - nextDecimalSample);
        }

        public T GetRandElementFromArray<T>(T[] arr)
        {
            if (arr.Length <= 0)
                return default(T);
            var randIndex = Int(0, arr.Length);
            return arr[randIndex];
        }
    }
}
