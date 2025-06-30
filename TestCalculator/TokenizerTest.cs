using Calculator;
using Calculator.Token;

namespace TestCalculator
{
    public class TokenizerTest
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                "2+3",
                new List<IToken>() { new NumToken(2), new OpToken('+'), new NumToken(3) }
            };
            yield return new object[]
            {
                "3*4+(2*4)/2",
                new List<IToken>()
                {
                    new NumToken(3), new OpToken('*'),
                    new NumToken(4), new OpToken('+'),
                    new BrToken('('), new NumToken(2),
                    new OpToken('*'), new NumToken(4),
                    new BrToken(')'), new OpToken('/'),
                    new NumToken(2)
                }
            };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void TestTokenization(string expression, List<IToken> expected)
        {
            var tokenizer = new Tokenizer();

            List<IToken> result = tokenizer.Tokenize(expression);


            Assert.True(expected.Count == result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.True(expected[i].Type == result[i].Type);
                Assert.True(expected[i].Value.IsFloat == result[i].Value.IsFloat);
                if (result[i].Value.IsFloat)
                    Assert.True(expected[i].Value.FloatValue == result[i].Value.FloatValue);
                else
                    Assert.True(expected[i].Value.CharValue == result[i].Value.CharValue);
            }


        }
    }
}