using EntityExtensions.Exceptions;

namespace EntityExtensions.Shared;

public class GenericResult
{
    public bool HasErrors { get; }
    public List<string> Errors { get; } = new();
    public object? Data { get; }

    public GenericResult()
    {
    }
    
    public GenericResult(object? result)
    {
        Data = result;
    }

    public GenericResult(Exception exception)
    {
        HasErrors = true;
        Errors.Add(exception.Message);
    }

    public GenericResult(MultipleExceptions exceptions)
    {
        HasErrors = true;
        Errors.AddRange(exceptions.Messages);
    }
}