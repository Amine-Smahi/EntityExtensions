using EntityExtensions.Configurations;
using EntityExtensions.Interfaces;
using EntityExtensions.Shared;

namespace EntityExtensions.Operations.Transactions;

public static class TransactionWithoutResultHandler
{
    public static IResult Transaction(Action operation)
    {
        try
        {
            var repository = DependencyContainer.Resolve<IRepository<Entity>>();
            repository?.HandleTransaction(operation);
            return Results.Ok(new GenericResult());
        }
        catch (Exception exception)
        {
            return Results.BadRequest(new GenericResult(exception));
        }
    }
}