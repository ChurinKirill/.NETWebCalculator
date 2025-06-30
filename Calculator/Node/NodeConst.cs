namespace Calculator.Node
{
    public class NodeConst : INode
    {
        public float constVal;
        public NodeType Type => NodeType.nConst;

        public NodeConst(float constVal)
        {
            this.constVal = constVal;
        }

        public float Calculate()
        {
            return constVal;
        }
    }
}
