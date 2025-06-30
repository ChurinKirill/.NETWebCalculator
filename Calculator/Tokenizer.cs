using Calculator.Token;
using System.Reflection.Metadata.Ecma335;

namespace Calculator
{
    public class Tokenizer
    {
        public static Tokenizer Default { get; } = new Tokenizer();
        public List<IToken> Tokenize(string expression)
        {
            int l = expression.Length;
            char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
            char[] operations = new char[] { '+', '-', '*', '/' };
            char[] brackets = new char[] { '(', ')' };

            List<IToken> result = new List<IToken>();

            int i = 0, j = 0;

            while (i < l)
            {
                if (operations.Contains(expression[i]))
                {
                    result.Add(new OpToken(expression[i]));
                }
                else if (expression[i] >= '0' && expression[i] <= '9')
                {
                    j = i + 1;
                    if (j < l)
                    {
                        while (j < l && digits.Contains(expression[j]) || expression[i] == '.')
                        {
                            j++;
                            if (j == l)
                            {
                                break;
                            }
                        }
                    }
                    string sub = expression.Substring(i, j - i);
                    bool success = float.TryParse(sub, out float num);
                    if (!success)
                    {
                        throw new Exception($"Exception during parsing '{sub}' to float");
                    }
                    i = j - 1;
                    result.Add(new NumToken(num));
                }
                else if (brackets.Contains(expression[i]))
                {
                    result.Add(new BrToken(expression[i]));
                }
                i++;
            }
            return result;
        }
    }
}
