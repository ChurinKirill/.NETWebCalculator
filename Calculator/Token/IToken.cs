namespace Calculator.Token
{
    public interface IToken
    {
        TokenType Type { get; }
        FloatOrChar Value { get; }
    }

    public enum TokenType
    {
        numT = 0,
        opT = 1,
        brT = 2
    }

    public readonly struct FloatOrChar
    {
        public readonly float FloatValue = 0;
        public readonly char CharValue = '0';
        public bool IsFloat { get; }

        public FloatOrChar(float value) { FloatValue = value; IsFloat = true; }
        public FloatOrChar(char value) { CharValue = value; IsFloat = false; }
    }

}
