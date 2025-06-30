using Calculator;
using Calculator.Node;
using Calculator.Token;

namespace TestCalculator
{
    public class NodeCreationTest
    {
        public static IEnumerable<object[]> TestData()
        {
            var tokenizer = new Tokenizer();

            yield return new object[]
            {
                tokenizer.Tokenize("2+3"),
                new CommonNode(new NodeConst(2), new NodeConst(3), '+')
            };
            yield return new object[]
            {
                tokenizer.Tokenize("3*4+(2*4)/2"),
                new CommonNode(
                    new CommonNode(new NodeConst(3), new NodeConst(4), '*'),
                    new CommonNode(
                        new NodeBrackets(
                            new CommonNode(new NodeConst(2), new NodeConst(4), '*')
                            ),
                        new NodeConst(2),
                        '/'
                        ),
                    '+'
                    )
            };

        }

        private bool CompareNodes(INode node1, INode node2)
        {
            if (node1.Type != node2.Type)
                return false;

            switch (node1.Type)
            {
                case NodeType.nCommon:
                    var commonNode1 = (CommonNode)node1;
                    var commonNode2 = (CommonNode)node2;
                    return CompareNodes(commonNode1.left, commonNode2.left) && CompareNodes(commonNode1.right, commonNode2.right);
                case NodeType.nBrackets:
                    var brNode1 = (NodeBrackets)node1;
                    var brNode2 = (NodeBrackets)node2;
                    return CompareNodes(brNode1.innerExpr, brNode2.innerExpr);
                default: // NodeType.nConst
                    var constNode1 = (NodeConst)node1;
                    var constNode2 = (NodeConst)node2;
                    return constNode1.constVal == constNode2.constVal;

            }
        }

         
        [Theory]
        [MemberData(nameof(TestData))]
        public void TestNodeCreation(List<IToken> tokens, INode expected)
        {
            var nodeCreator = new NodeFactory();

            INode result = nodeCreator.CreateNode(tokens);

            Assert.True(CompareNodes(expected, result));
        }
    }
}
