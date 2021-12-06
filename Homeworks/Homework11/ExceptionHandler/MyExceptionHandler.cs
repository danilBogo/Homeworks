using System;
using Microsoft.Extensions.Logging;

namespace Homework11.ExceptionHandler
{
    public class MyExceptionHandler : IExceptionHandler
    {
        private readonly ILogger logger;

        public MyExceptionHandler(ILogger logger)
        {
            this.logger = logger;
        }
        public void Handle(Exception exception)
        {
            logger.LogError(exception.Message);
        }
        public void Handle(DivideByZeroException exception)
        {
            logger.LogError($"was divide by zero: {exception.Message}");
        }
        public void Handle(InvalidCastException exception)
        {
            logger.LogError($"failed cast: {exception.Message}");
        }
        public void Handle(InvalidOperationException exception)
        {
            logger.LogError($"the argument received null: {exception.Message}");
        }

        public void Handle(ArgumentException exception)
        {
            logger.LogError($"invalid argument was received: {exception.Message}");
        }
    }
}