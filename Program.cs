using JunkCodeGeneratorApp.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            };
            var generator = new CodeGenerator(opts);
            var str = generator.Generate();
            Console.WriteLine(str);
        }
    }
}
