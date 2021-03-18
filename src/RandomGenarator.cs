using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkCodeGeneratorApp.src
{
    public class RandomGenarator
    {
        private readonly Random random = new Random();

        public int Int(int min, int max)
        {
            return random.Next(min, max);
        }

        public string String(int length, string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            string k = new string(
                Enumerable.Range(0, length).Select((_) => chars[Int(0, chars.Length)]).ToArray()
            );

            return k;
        }
    }
}
