using System.Linq;
using System.Text.RegularExpressions;

namespace JunkCodeGeneratorApp.src
{
    static public class Placeholders
    {
        public const string RANDOM_STRING_VALUE = "RANDOM_STRING_VALUE";
        public const string RANDOM_INT_VALUE = "RANDOM_INT_VALUE";
        public const string RANDOM_BYTE_VALUE = "RANDOM_BYTE_VALUE";
        public const string RANDOM_DECIMAL_VALUE = "RANDOM_DECIMAL_VALUE";
        public const string RANDOM_STRING_ARRAY_VALUE = "RANDOM_STRING_ARRAY_VALUE";
        public const string RANDOM_INT_ARRAY_VALUE = "RANDOM_INT_ARRAY_VALUE";
        public const string RANDOM_BYTE_ARRAY_VALUE = "RANDOM_BYTE_ARRAY_VALUE";
        public const string RANDOM_DECIMAL_ARRAY_VALUE = "RANDOM_DECIMAL_ARRAY_VALUE";

        public static string[] PlaceholdersArray = new string[]
        {
            RANDOM_STRING_VALUE,
            RANDOM_INT_VALUE,
            RANDOM_BYTE_VALUE,
            RANDOM_DECIMAL_VALUE,
            RANDOM_STRING_ARRAY_VALUE,
            RANDOM_INT_ARRAY_VALUE,
            RANDOM_BYTE_ARRAY_VALUE,
            RANDOM_DECIMAL_ARRAY_VALUE,
        };
    }

    public class Parser
    {
        private const string STRING_BY_PLACEHOLDER_NOT_FOUND_RETURNING_STRING = "/* string not found */";
        public string ReplacePlaceholdersWithData(CodeGenerator CodeGenerator, string input)
        {
            foreach (var placeholder in Placeholders.PlaceholdersArray)
            {
                var regex = $"{placeholder}";
                input = Regex.Replace(input, regex, (match) => GetStringByPlaceholder(CodeGenerator, placeholder));
            }
            return input;
        }

        public string GetStringByPlaceholder(CodeGenerator CodeGenerator, string placeholder)
        {
            switch (placeholder)
            {
                case Placeholders.RANDOM_STRING_VALUE:
                    return CodeGenerator.GetRandStringValue();
                case Placeholders.RANDOM_INT_VALUE:
                    return CodeGenerator.GetRandIntValue();
                case Placeholders.RANDOM_BYTE_VALUE:
                    return CodeGenerator.GetRandIntValue();
                case Placeholders.RANDOM_DECIMAL_VALUE:
                    return CodeGenerator.GetRandDecimalValue();
                case Placeholders.RANDOM_STRING_ARRAY_VALUE:
                    return CodeGenerator.GetRandStringArrayValue();
                case Placeholders.RANDOM_INT_ARRAY_VALUE:
                    return CodeGenerator.GetRandIntArrayValue();
                case Placeholders.RANDOM_BYTE_ARRAY_VALUE:
                    return CodeGenerator.GetRandIntArrayValue();
                case Placeholders.RANDOM_DECIMAL_ARRAY_VALUE:
                    return CodeGenerator.GetRandDecimalArrayValue();
                default:
                    return STRING_BY_PLACEHOLDER_NOT_FOUND_RETURNING_STRING;
            }
        }
    }
}
