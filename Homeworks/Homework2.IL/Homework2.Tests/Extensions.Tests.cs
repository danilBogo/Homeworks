using Xunit;
using Homework2.IL;

namespace Homework2.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void TryParseToOperation_OperationPlus_TrueReturned()
        {
            var res = "+".TryParseToOperation(out var operation);
            Assert.True(res);
            Assert.Equal(Operations.Plus,operation);
        }
        [Fact]
        public void TryParseToOperation_OperationMinus_TrueReturned()
        {
            var res = "-".TryParseToOperation(out var operation);
            Assert.True(res);
            Assert.Equal(Operations.Minus,operation);
        }
        [Fact]
        public void TryParseToOperation_OperationMultiply_TrueReturned()
        {
            var res = "*".TryParseToOperation(out var operation);
            Assert.True(res);
            Assert.Equal(Operations.Multiply,operation);
        }
        [Fact]
        public void TryParseToOperation_OperationDivide_TrueReturned()
        {
            var res = "/".TryParseToOperation(out var operation);
            Assert.True(res);
            Assert.Equal(Operations.Divide,operation);
        }
        
        [Fact]
        public void TryParseToOperation_UnknownOperation_FalseReturned()
        {
            var res = "x".TryParseToOperation(out var operation);
            Assert.False(res);
            Assert.Equal(Operations.Unknown,operation);
        }
    }
}