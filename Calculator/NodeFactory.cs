using Calculator.Node;
using Calculator.Token;

namespace Calculator
{
    public class NodeFactory
    {
        public static INode CreateNode(List<IToken> tokens)
        {
            if (tokens.Count == 0 || (tokens.Count == 1 && tokens[0].Type != TokenType.numT))
                throw new Exception("Incorrect input");
            if (tokens.Count == 1 && tokens[0].Type == TokenType.numT) // single number
                return new NodeConst(tokens[0].Value.FloatValue);
            if ((tokens[0].Type == TokenType.brT && tokens[0].Value.CharValue == '(') && (tokens[tokens.Count - 1].Type == TokenType.brT && tokens[tokens.Count - 1].Value.CharValue == ')'))
            { // value in brackets, e.g. (a+b)
                INode inner = CreateNode(tokens.GetRange(1, tokens.Count - 2));
                return new NodeBrackets(inner);
            }

            int i = tokens.Count - 1;
            while (i >= 0) // low priority operations first (will be calculated last)
            {
                if (tokens[i].Type == TokenType.brT && tokens[i].Value.CharValue == ')')
                { // multi-value that has brackets (ignoring all in brackets - this will calculate first)
                    i--;
                    int countBr = 0;
                    bool ok = false;

                    while (i >= 0)
                    {
                        if (tokens[i].Value.CharValue == ')')
                            countBr++;
                        else if (tokens[i].Value.CharValue == '(' && countBr != 0)
                            countBr--;
                        else if (tokens[i].Value.CharValue == '(' && countBr == 0)
                        {
                            if (i > 0)
                                i--;
                            ok = true;
                            break;
                        }
                        i--;
                    }
                    if (!ok)
                        throw new Exception("Incorrect input format");
                    else if (i == 0)
                        continue;
                }
                if (tokens[i].Type == TokenType.opT && (tokens[i].Value.CharValue == '+' || tokens[i].Value.CharValue == '-'))
                {
                    INode lefnN = CreateNode(tokens.GetRange(0, i));
                    INode rightN = CreateNode(tokens.GetRange(i + 1, tokens.Count - i - 1));
                    return new CommonNode(lefnN, rightN, tokens[i].Value.CharValue);
                }
                i--;
            }

            // if low priority operations does not exist
            i = tokens.Count - 1;
            while (i >= 0) // high priority operations (will be calculated first)
            {
                if (tokens[i].Type == TokenType.brT && tokens[i].Value.CharValue == ')')
                { // multi-value that has brackets (ignoring all in brackets - this will calculate first)
                    i--;
                    int countBr = 0;
                    bool ok = false;

                    while (i >= 0)
                    {
                        if (tokens[i].Value.CharValue == ')')
                            countBr++;
                        else if (tokens[i].Value.CharValue == '(' && countBr != 0)
                            countBr--;
                        else if (tokens[i].Value.CharValue == '(' && countBr == 0)
                        {
                            if (i > 0)
                                i--;
                            ok = true;
                            break;
                        }
                        i--;
                    }
                    if (!ok)
                        throw new Exception("Incorrect input format");
                    else if (i == 0)
                        continue;
                }
                if (tokens[i].Type == TokenType.opT && (tokens[i].Value.CharValue == '*' || tokens[i].Value.CharValue == '/'))
                {
                    INode lefnN = CreateNode(tokens.GetRange(0, i));
                    INode rightN = CreateNode(tokens.GetRange(i + 1, tokens.Count - i - 1));
                    return new CommonNode(lefnN, rightN, tokens[i].Value.CharValue);
                }
                i--;
            }
            return new NodeConst(0); // dummy return
        }
    }
}
