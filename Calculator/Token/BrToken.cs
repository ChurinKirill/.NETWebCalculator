namespace Calculator.Token
{
    public class BrToken : IToken
    {
        public TokenType Type => TokenType.brT;
        private char _value;

        public BrToken(char value)
        {
            _value = value;
        }
        public FloatOrChar Value => new FloatOrChar(_value);
    }
}
