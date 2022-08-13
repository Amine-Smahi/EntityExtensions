namespace EntityExtensions.Configurations;

public static class DependencyContainer
{
    private static IServiceProvider? CurrentProvider { get; set; }

    public static void AddSuperEntity(this IServiceCollection services)
    {
        CurrentProvider = services.BuildServiceProvider();
    }

    public static T? Resolve<T>()
    {
        return CurrentProvider!.GetService<T>();
    }
}