using Xunit;

namespace Homework8.Tests
{
    public class CalculatorTests
    {
        private readonly DefaultCalculator calculator = new();
        [Fact]
        public void Calculate_220Plus8_228Returned()
        {
            var res = calculator.Calculate(220, Operation.Plus, 8);
            Assert.Equal(228,res);
        }
        [Fact]
        public void Calculate_1401Minus64_1337Returned()
        {
            var res = calculator.Calculate(1401, Operation.Minus, 64);
            Assert.Equal(1337,res);
        }
        
        [Fact]
        public void Calculate_4Multiply372_1488Returned()
        {
            var res = calculator.Calculate(4, Operation.Multiply, 372);
            Assert.Equal(1488,res);
        }
        
        [Fact]
        public void Calculate_359Divide4_89dot75Returned()
        {
            var res = calculator.Calculate(359, Operation.Divide, 4);
            Assert.Equal(89.75,res,6);
        }
    }
}