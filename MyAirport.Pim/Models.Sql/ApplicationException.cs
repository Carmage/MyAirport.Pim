using System;

public class ApplicationException : Exception
{
    public ApplicationException() => super();

    public ApplicationException(string message)
        : base(message)
    {
        super();
        this.Message = message;
    }
}