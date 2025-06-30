namespace Calculator.Node
{
    public interface INode
    {
        NodeType Type { get; }
        float Calculate();
    }

    public enum NodeType
    {
        nCommon = 0,
        nBrackets = 1,
        nConst = 2
    }
}
