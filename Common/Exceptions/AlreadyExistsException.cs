namespace CodeWright.Common.Exceptions;

/// <summary>
/// An item already exists (HTTP 409 error?)
/// </summary>
public class AlreadyExistsException : Exception
{
    public AlreadyExistsException() : base("Item Exists") { }

    public AlreadyExistsException(string message) : base(message) { }

    public AlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
}

