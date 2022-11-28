namespace B3.API.Config
{
    public class EnumException : Exception
    {
        public int Value { get; set; }
        public EnumException(string message, int value) : base(message)
        {
            Value = value;
        }

    }
}
