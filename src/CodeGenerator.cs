using System.Linq;

namespace JunkCodeGeneratorApp.src
{
    public class CodeGenerator
    {
        private CodeGeneratorOptions Opts;
        private RandomGenarator Rand;
        private Parser Parser;
        public CodeGenerator(CodeGeneratorOptions opts)
        {
            Opts = opts;
            Rand = new RandomGenarator();
            Parser = new Parser();
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

        private string GetRandIdString()
        {
            var len = Rand.Int(Opts.IdMinLen, Opts.IdMaxLen);
            var chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@_";
            var varName = Rand.String(len, chars);
            if (char.IsNumber(varName[0]))
                varName = Rand.String(1, "abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@_")[0] + varName.Substring(1);
            return varName;
        }
        #region Getting values
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
        public string GetRandByteValue()
        {
            var byteVal = Rand.Byte(Opts.ByteValueMin, Opts.ByteValueMax);
            return byteVal.ToString();
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
        public string GetRandByteArrayValue()
        {
            var len = Rand.Int(Opts.ByteArrayMinLen, Opts.ByteArrayMaxLen);
            var values = string.Join(", ", Enumerable.Range(0, len).Select((_) => GetRandByteValue()).ToArray());
            return "new byte[] { %s }".Replace("%s", values);
        }
        public string GetRandDecimalArrayValue()
        {
            var len = Rand.Int(Opts.StringArrayMinLen, Opts.StringArrayMaxLen);
            var values = string.Join(", ", Enumerable.Range(0, len).Select((_) => GetRandDecimalValue()).ToArray());
            return "new decimal[] { %s }".Replace("%s", values);
        }
        #endregion

        #region Variable left-side declarations
        public string GetVarVariableRandDeclaration()
        {
            var varName = GetRandIdString();
            return $"var {varName}";
        }
        public string GetStringVariableRandDeclaration()
        {
            var varName = GetRandIdString();
            return $"string {varName}";
        }
        public string GetIntVariableRandDeclaration()
        {
            var varName = GetRandIdString();
            return $"int {varName}";
        }
        public string GetDecimalVariableRandDeclaration()
        {
            var varName = GetRandIdString();
            return $"decimal {varName}";
        }
        public string GetStringArrayVariableRandDeclaration()
        {
            var varName = GetRandIdString();
            return $"string[] {varName}";
        }
        public string GetIntArrayVariableRandDeclaration()
        {
            var varName = GetRandIdString();
            return $"int[] {varName}";
        }
        public string GetDecimalArrayVariableRandDeclaration()
        {
            var varName = GetRandIdString();
            return $"decimal[] {varName}";
        }
        #endregion

        public string GetRandMathExpression()
        {
            var mathLibPath = "System.Math";
            var mathEConst = $"{mathLibPath}.E";
            var mathPIConst = $"{mathLibPath}.PI";
            var functions = new string[]
            {
                $"{mathLibPath}.Abs({Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Abs((float){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Abs((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Abs({mathEConst})",
                $"{mathLibPath}.Abs({mathPIConst})",
                $"{mathLibPath}.Abs({Placeholders.RANDOM_INT_VALUE})",
                $"{mathLibPath}.Abs({Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Abs({Placeholders.RANDOM_INT_ARRAY_VALUE}[0])",

                $"{mathLibPath}.BigMul({Placeholders.RANDOM_INT_VALUE}, {Placeholders.RANDOM_INT_VALUE})",
                $"{mathLibPath}.BigMul({Placeholders.RANDOM_INT_ARRAY_VALUE}[0], {Placeholders.RANDOM_INT_ARRAY_VALUE}[0])",

                $"{mathLibPath}.Ceiling({Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Ceiling({Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Ceiling((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Ceiling((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Ceiling({mathEConst})",
                $"{mathLibPath}.Ceiling({mathPIConst})",

                $"{mathLibPath}.Cos((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Cos((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Cos({mathEConst})",
                $"{mathLibPath}.Cos({mathPIConst})",
                $"{mathLibPath}.Cosh((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Cosh({mathEConst})",
                $"{mathLibPath}.Cosh({mathPIConst})",
                $"{mathLibPath}.Cosh((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",

                $"{mathLibPath}.Exp((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Exp((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Exp({mathEConst})",
                $"{mathLibPath}.Exp({mathPIConst})",

                $"{mathLibPath}.Floor((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Floor((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Floor({Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Floor({Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Floor((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Floor((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Floor({mathEConst})",
                $"{mathLibPath}.Floor({mathPIConst})",

                $"{mathLibPath}.IEEERemainder((double){Placeholders.RANDOM_DECIMAL_VALUE}, (double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.IEEERemainder((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0], (double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.IEEERemainder({mathEConst}, (double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.IEEERemainder((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0], {mathPIConst})",

                $"{mathLibPath}.Log((double){Placeholders.RANDOM_DECIMAL_VALUE}, (double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Log((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Log({mathEConst}, (double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Log((double){Placeholders.RANDOM_DECIMAL_VALUE}, {mathPIConst})",
                $"{mathLibPath}.Log({mathEConst})",
                $"{mathLibPath}.Log({mathPIConst})",
                $"{mathLibPath}.Log((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Log((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0], (double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Log10((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Log10((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",

                $"{mathLibPath}.Max({Placeholders.RANDOM_DECIMAL_VALUE}, {Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Max({Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0], {Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Max((float){Placeholders.RANDOM_DECIMAL_VALUE}, (float){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Max((float){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0], (float){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Max({Placeholders.RANDOM_INT_VALUE}, {Placeholders.RANDOM_INT_VALUE})",
                $"{mathLibPath}.Max({Placeholders.RANDOM_INT_ARRAY_VALUE}[0], {Placeholders.RANDOM_INT_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Max({Placeholders.RANDOM_BYTE_VALUE}, {Placeholders.RANDOM_BYTE_VALUE})",
                $"{mathLibPath}.Max({Placeholders.RANDOM_BYTE_ARRAY_VALUE}[0], {Placeholders.RANDOM_BYTE_ARRAY_VALUE}[0])",

                $"{mathLibPath}.Min({Placeholders.RANDOM_DECIMAL_VALUE}, {Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Min({Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0], {Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Min((float){Placeholders.RANDOM_DECIMAL_VALUE}, (float){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Min((float){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0], (float){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Min({Placeholders.RANDOM_INT_VALUE}, {Placeholders.RANDOM_INT_VALUE})",
                $"{mathLibPath}.Min({Placeholders.RANDOM_INT_ARRAY_VALUE}[0], {Placeholders.RANDOM_INT_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Min({Placeholders.RANDOM_BYTE_VALUE}, {Placeholders.RANDOM_BYTE_VALUE})",
                $"{mathLibPath}.Min({Placeholders.RANDOM_BYTE_ARRAY_VALUE}[0], {Placeholders.RANDOM_BYTE_ARRAY_VALUE}[0])",

                $"{mathLibPath}.Pow((double){Placeholders.RANDOM_DECIMAL_VALUE}, (double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Pow((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0], (double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",

                $"{mathLibPath}.Round({Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Round((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Round({mathEConst})",
                $"{mathLibPath}.Round({mathPIConst})",
                $"{mathLibPath}.Round({Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Round((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",

                $"{mathLibPath}.Sign({Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Sign({Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Sign({mathEConst})",
                $"{mathLibPath}.Sign({mathPIConst})",
                $"{mathLibPath}.Sign((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Sign((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Sign((float){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Sign((float){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Sign({Placeholders.RANDOM_INT_VALUE})",
                $"{mathLibPath}.Sign({Placeholders.RANDOM_INT_ARRAY_VALUE}[0])",

                $"{mathLibPath}.Sin((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Sin((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Sinh((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Sinh((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Sin({mathEConst})",
                $"{mathLibPath}.Sin({mathPIConst})",
                $"{mathLibPath}.Sinh({mathEConst})",
                $"{mathLibPath}.Sinh({mathPIConst})",

                $"{mathLibPath}.Sqrt((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Sqrt({mathEConst})",
                $"{mathLibPath}.Sqrt({mathPIConst})",
                $"{mathLibPath}.Sqrt((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",

                $"{mathLibPath}.Tan((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Tan((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Tan({mathEConst})",
                $"{mathLibPath}.Tan({mathPIConst})",
                $"{mathLibPath}.Tanh((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Tanh((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Tanh({mathEConst})",
                $"{mathLibPath}.Tanh({mathPIConst})",

                $"{mathLibPath}.Truncate((double){Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Truncate((double){Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Truncate({Placeholders.RANDOM_DECIMAL_VALUE})",
                $"{mathLibPath}.Truncate({Placeholders.RANDOM_DECIMAL_ARRAY_VALUE}[0])",
                $"{mathLibPath}.Truncate({mathEConst})",
                $"{mathLibPath}.Truncate({mathPIConst})",
            };

            var fnStr = Rand.GetRandElementFromArray(functions);
            var randMathExpression = Parser.ReplacePlaceholdersWithData(this, fnStr);
            return $"{randMathExpression};";
        }
        #endregion

    }
}
