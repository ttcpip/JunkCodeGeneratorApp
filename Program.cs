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
                StringArrayMinLen = 5,
                StringArrayMaxLen = 15,
                IntArrayMinLen = 5,
                IntArrayMaxLen = 15,
                DecimalArrayMinLen = 5,
                DecimalArrayMaxLen = 15,
                ByteValueMin = byte.MinValue,
                ByteValueMax = byte.MaxValue,
                ByteArrayMinLen = 5,
                ByteArrayMaxLen = 15,
                MinInLoopExpressions = 2,
                MaxInLoopExpressions = 5,
                MinElements = 10,
                MaxElements = 100,
                MaxIndexToGetValueFromArray = 4,
            };
            var generator = new CodeGenerator(opts);
            var str = generator.Generate();
            System.IO.File.WriteAllText("output.txt", str);
            Console.WriteLine(str);
        }
    }
}
