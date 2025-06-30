namespace Calculator.Token
{
    public class NumToken : IToken
    {
        public TokenType Type => TokenType.numT;
        private float _value;

        public NumToken(float value)
        {
            _value = value;
        }

        public FloatOrChar Value => new FloatOrChar(_value);
    }
}
