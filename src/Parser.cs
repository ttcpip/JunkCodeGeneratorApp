using System.Text.RegularExpressions;

namespace JunkCodeGeneratorApp.src
{
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
                    return CodeGenerator.GetRandByteArrayValue();
                case Placeholders.RANDOM_DECIMAL_ARRAY_VALUE:
                    return CodeGenerator.GetRandDecimalArrayValue();
                case Placeholders.VAR_VARIABLE_RAND_DECLARATION:
                    return CodeGenerator.GetVarVariableRandDeclaration();
                case Placeholders.STRING_VARIABLE_RAND_DECLARATION:
                    return CodeGenerator.GetStringVariableRandDeclaration();
                case Placeholders.INT_VARIABLE_RAND_DECLARATION:
                    return CodeGenerator.GetIntVariableRandDeclaration();
                case Placeholders.BYTE_VARIABLE_RAND_DECLARATION:
                    return CodeGenerator.GetByteVariableRandDeclaration();
                case Placeholders.DECIMAL_VARIABLE_RAND_DECLARATION:
                    return CodeGenerator.GetDecimalVariableRandDeclaration();
                case Placeholders.STRING_ARRAY_VARIABLE_RAND_DECLARATION:
                    return CodeGenerator.GetStringArrayVariableRandDeclaration();
                case Placeholders.INT_ARRAY_VARIABLE_RAND_DECLARATION:
                    return CodeGenerator.GetIntArrayVariableRandDeclaration();
                case Placeholders.BYTE_ARRAY_VARIABLE_RAND_DECLARATION:
                    return CodeGenerator.GetByteArrayVariableRandDeclaration();
                case Placeholders.DECIMAL_ARRAY_VARIABLE_RAND_DECLARATION:
                    return CodeGenerator.GetDecimalArrayVariableRandDeclaration();

                case Placeholders.RANDOM_MATH_EXPRESSION:
                    return CodeGenerator.GetRandMathExpression();
                case Placeholders.RANDOM_VARIABLE_DECLARATION_EXPRESSION:
                    return CodeGenerator.GetRandVariableDeclarationExpression();


                default:
                    return STRING_BY_PLACEHOLDER_NOT_FOUND_RETURNING_STRING;
            }
        }
    }
}
