namespace Homework10.Services
{
    public enum TokenType
    {
        Number = 0,
        LeftParenthesis = 1,
        RightParenthesis = 2,
        Operation = 3
    }
    public class Token
    {
        public string Value { get; }
        public TokenType TokenType { get; }

        public Token(string value, TokenType type)
        {
            Value = value;
            TokenType = type;
        }
    }
}