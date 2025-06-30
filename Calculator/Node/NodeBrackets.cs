namespace Calculator.Node
{
    public class NodeBrackets : INode
    {
        public INode innerExpr;
        public NodeType Type => NodeType.nBrackets;

        public NodeBrackets(INode innerExpr)
        {
            this.innerExpr = innerExpr;
        }

        public float Calculate()
        {
            return innerExpr.Calculate();
        }
    }
}
