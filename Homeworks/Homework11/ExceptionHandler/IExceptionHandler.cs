using System;

namespace Homework11.ExceptionHandler
{
    public interface IExceptionHandler
    {
        void Handle(Exception exception);
        void HandleDynamic(Exception exception);
    }
}