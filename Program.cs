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
                StringArrayMinLen = 1,
                StringArrayMaxLen = 15,
                IntArrayMinLen = 1,
                IntArrayMaxLen = 15,
                DecimalArrayMinLen = 1,
                DecimalArrayMaxLen = 15,
                ByteValueMin = byte.MinValue,
                ByteValueMax = byte.MaxValue,
                ByteArrayMinLen = 1,
                ByteArrayMaxLen = 15,
                MinInLoopExpressions = 1,
                MaxInLoopExpressions = 100,
            };
            var generator = new CodeGenerator(opts);
            var str = generator.Generate();
            Console.WriteLine(str);
        }
    }
}
