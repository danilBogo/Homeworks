using Xunit;

namespace Homework1.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void TryParseToOperation_OperationPlus_TrueReturned()
        {
            var res = "+".TryParseToOperation(out var operation);
            Assert.Equal(true,res);
            Assert.Equal(Operations.Plus,operation);
        }
        [Fact]
        public void TryParseToOperation_OperationMinus_TrueReturned()
        {
            var res = "-".TryParseToOperation(out var operation);
            Assert.Equal(true,res);
            Assert.Equal(Operations.Minus,operation);
        }
        [Fact]
        public void TryParseToOperation_OperationMultiply_TrueReturned()
        {
            var res = "*".TryParseToOperation(out var operation);
            Assert.Equal(true,res);
            Assert.Equal(Operations.Multiply,operation);
        }
        [Fact]
        public void TryParseToOperation_OperationDivide_TrueReturned()
        {
            var res = "/".TryParseToOperation(out var operation);
            Assert.Equal(true,res);
            Assert.Equal(Operations.Divide,operation);
        }
        
        [Fact]
        public void TryParseToOperation_UnknownOperation_FalseReturned()
        {
            var res = "x".TryParseToOperation(out var operation);
            Assert.Equal(false,res);
            Assert.Equal(Operations.Unknown,operation);
        }
    }
}