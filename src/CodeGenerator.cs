using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkCodeGeneratorApp.src
{
    public class CodeGenerator
    {
        private CodeGeneratorOptions Opts;
        private RandomGenarator Rand;
        public CodeGenerator(CodeGeneratorOptions opts)
        {
            Opts = opts;
            Rand = new RandomGenarator();
        }

        #region Public methods
        public string Generate()
        {
            return GetString();
        }
        #endregion

        #region Private methods
        private string GetString()
        {
            return Rand.String(10); // TODO
        }
        #endregion

    }
}
