using EntityExtensions.Interfaces;

namespace EntityExtensions.Configurations;

public static class DomainEvents
{
    public static async Task<TResult> Raise<T,TResult>(T args) where T : IDomainEvent
    {
        return await DependencyContainer.Resolve<IEventHandlingResult<T, TResult>>()!.Handler(args);
    }
    
    public static void Raise<T>(T args) where T : IDomainEvent
    {
        DependencyContainer.Resolve<IEventHandling<T>>()!.Handler(args);
    }
}