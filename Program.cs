using JunkCodeGeneratorApp.src;
using System;

namespace JunkCodeGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var opts = new CodeGeneratorOptions()
            {
                IdMinLen = 5,
                IdMaxLen = 32,
                StringValueMinLen = 1,
                StringValueMaxLen = 255,
                IntValueMin = int.MinValue,
                IntValueMax = int.MaxValue,
                DecimalValueMin = decimal.MinValue,
                DecimalValueMax = decimal.MaxValue,
            };
            var generator = new CodeGenerator(opts);
            var str = generator.Generate();
            Console.WriteLine(str);
        }
    }
}
