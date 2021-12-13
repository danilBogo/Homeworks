using Homework2.IL;
using Xunit;

namespace Homework2.Tests
{
    public class ParserTests
    {
        [Fact]
        public void TryParseArguments_Parse31Plus112_TrueReturned()
        {
            var res = Parser.TryParseArguments(new[] {"31","+","112"}, out var val1, out var val2);
            Assert.True(res);
            Assert.Equal(31,val1);
            Assert.Equal(112,val2);
        }

        [Fact]
        public void TryParseArguments_IncorrectOperation_CorrectParse_TrueReturned()
        {
            var res = Parser.TryParseArguments(new[] {"11", "x", "300"}, out var val1, out var val2);
            Assert.True(res);
            Assert.Equal(11,val1);
            Assert.Equal(300,val2);
        }

        [Fact]
        public void TryParseArguments_NotCalculateSyntax_FalseReturned()
        {
            var res =  Parser.TryParseArguments(new[] {"x", "+", "123"}, out var val1, out var val2);
            Assert.False(res);
        }
    }
}