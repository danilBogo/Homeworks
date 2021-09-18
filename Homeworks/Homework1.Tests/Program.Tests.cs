using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Homework1.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Program_CantParseArguments_1Returned()
        {
            var res = Program.Main(new[] {"10", "+", "z"});
            Assert.Equal(1,res);
        }
        [Fact]
        public void Program_CantParseOperation_2Returned()
        {
            var res = Program.Main(new[] {"10", "?", "12"});
            Assert.Equal(2,res);
        }
        [Fact]
        public void Program_CorrectArgumentsAndOperation_0Returned()
        {
            var res = Program.Main(new[] {"10", "*", "12"});
            Assert.Equal(0,res);
        }
    }
}