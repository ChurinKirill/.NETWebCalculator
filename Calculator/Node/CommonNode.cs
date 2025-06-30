namespace Calculator.Node
{
    public class CommonNode : INode
    {
        public INode left;
        public INode right;
        char operation;
        public NodeType Type => NodeType.nCommon;

        public CommonNode(INode left, INode right, char operation)        {
            this.left = left;
            this.right = right;
            this.operation = operation;
        }

        public float Calculate()
        {
            switch (operation)
            {
                case '+':
                    return left.Calculate() + right.Calculate();
                case '-':
                    return left.Calculate() - right.Calculate();
                case '*':
                    return left.Calculate() * right.Calculate();
                default:
                    return left.Calculate() / right.Calculate();
            }
        }
    }
}
