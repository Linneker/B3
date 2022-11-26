namespace B3.API.Config
{
    public class EnumExcaption : Exception
    {
        public int Value { get; set; }
        public EnumExcaption(string message) : base(message) { }
        public EnumExcaption(string message, int value) : base(message)
        {
            Value = value;
        }

    }
}
