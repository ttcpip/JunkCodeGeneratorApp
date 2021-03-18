using System.Linq;

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
            return GetRandIdString();
        }

        #region base things
        private string GetRandIdString()
        {
            var len = Rand.Int(Opts.IdMinLen, Opts.IdMaxLen);
            var chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@_";
            var varName = Rand.String(len, chars);
            if (char.IsNumber(varName[0]))
                varName = Rand.String(1, "abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@_")[0] + varName.Substring(1);
            return varName;
        }
        public string GetRandStringValue()
        {
            var len = Rand.Int(Opts.StringValueMinLen, Opts.StringValueMaxLen);
            var chars = "abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@_!#$%^&*()-+/?.<>,АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
            var stringValue = $"\"{Rand.String(len, chars)}\"";
            return stringValue;
        }
        public string GetRandIntValue()
        {
            var intVal = Rand.Int(Opts.IntValueMin, Opts.IntValueMax);
            return intVal.ToString();
        }
        public string GetRandDecimalValue()
        {
            var decimalVal = Rand.Decimal(Opts.DecimalValueMin, Opts.DecimalValueMax);
            return $"{decimalVal}m";
        }
        public string GetRandStringArrayValue()
        {
            var len = Rand.Int(Opts.StringArrayMinLen, Opts.StringArrayMaxLen);
            var values = string.Join(", ", Enumerable.Range(0, len).Select((_) => GetRandStringValue()).ToArray());
            return "new string[] { %s }".Replace("%s", values);
        }
        public string GetRandIntArrayValue()
        {
            var len = Rand.Int(Opts.StringArrayMinLen, Opts.StringArrayMaxLen);
            var values = string.Join(", ", Enumerable.Range(0, len).Select((_) => GetRandIntValue()).ToArray());
            return "new int[] { %s }".Replace("%s", values);
        }
        public string GetRandDecimalArrayValue()
        {
            var len = Rand.Int(Opts.StringArrayMinLen, Opts.StringArrayMaxLen);
            var values = string.Join(", ", Enumerable.Range(0, len).Select((_) => GetRandDecimalValue()).ToArray());
            return "new decimal[] { %s }".Replace("%s", values);
        }
        #endregion
        #endregion

    }
}
