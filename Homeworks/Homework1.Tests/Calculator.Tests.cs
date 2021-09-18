using Xunit;

namespace Homework1.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculate_220Plus8_228Returned()
        {
            var res = Calculator.Calculate(220, Operations.Plus, 8);
            Assert.Equal(228,res);
        }
        [Fact]
        public void Calculate_1401Minus64_1337Returned()
        {
            var res = Calculator.Calculate(1401, Operations.Minus, 64);
            Assert.Equal(1337,res);
        }
        
        [Fact]
        public void Calculate_4Multiply372_1488Returned()
        {
            var res = Calculator.Calculate(4, Operations.Multiply, 372);
            Assert.Equal(1488,res);
        }
        
        [Fact]
        public void Calculate_359Divide4_89dot75Returned()
        {
            var res = Calculator.Calculate(359, Operations.Divide, 4);
            Assert.Equal(89.75,res,6);
        }
    }
}