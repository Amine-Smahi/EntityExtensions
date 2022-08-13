namespace EntityExtensions.Exceptions;

public class MultipleExceptions : Exception
{
    public List<string> Messages { get; set; } = new();
}