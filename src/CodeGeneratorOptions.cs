namespace JunkCodeGeneratorApp.src
{
    public class CodeGeneratorOptions
    {
        public int IdMaxLen { get; set; }
        public int IdMinLen { get; set; }
        public int StringValueMaxLen { get; set; }
        public int StringValueMinLen { get; set; }
        public int IntValueMax { get; set; }
        public int IntValueMin { get; set; }
        public byte ByteValueMax { get; set; }
        public byte ByteValueMin { get; set; }
        public decimal DecimalValueMax { get; set; }
        public decimal DecimalValueMin { get; set; }
        public int StringArrayMaxLen { get; set; }
        public int StringArrayMinLen { get; set; }
        public int IntArrayMaxLen { get; set; }
        public int IntArrayMinLen { get; set; }
        public int ByteArrayMaxLen { get; set; }
        public int ByteArrayMinLen { get; set; }
        public int DecimalArrayMaxLen { get; set; }
        public int DecimalArrayMinLen { get; set; }
        public int MaxInLoopExpressions { get; set; }
        public int MinInLoopExpressions { get; set; }
    }
}
