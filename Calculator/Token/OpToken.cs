namespace Calculator.Token
{
    public class OpToken : IToken
    {
        public TokenType Type => TokenType.opT;
        private char _value;
        public OpToken(char value)
        {
            _value = value;
        }

        public FloatOrChar Value => new FloatOrChar(_value);
    }
}
