using EntityExtensions.Configurations;
using EntityExtensions.Interfaces;
using EntityExtensions.Shared;

namespace EntityExtensions.Operations.Transactions;

public static class TransactionWithResultHandler
{
    public static IResult Transaction(Func<object> operation)
    {
        try
        {
            var repository = DependencyContainer.Resolve<IRepository<Entity>>();
            var result = repository?.HandleTransaction(operation);
            return Results.Ok(new GenericResult(result));
        }
        catch (Exception exception)
        {
            return Results.BadRequest(new GenericResult(exception));
        }
    }
}