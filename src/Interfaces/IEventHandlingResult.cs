namespace EntityExtensions.Interfaces
{
    public interface IEventHandlingResult<in T, TResult> where T : IDomainEvent
    {
        Task<TResult> Handler(T args);
    }
}