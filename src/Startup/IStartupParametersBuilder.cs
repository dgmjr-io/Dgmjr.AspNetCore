namespace Microsoft.Extensions.DependencyInjection;

public partial interface IStartupParametersBuilder : IServiceCollection
{
    IServiceCollection Services { get; }

    abstract Action<IHealthChecksBuilder> HealthChecksConfigurator { get; internal set; }

    IStartupParameters Build();

    IStartupParametersBuilder AddDbContext<TContext>(
        Action<DbContextOptionsBuilder>? optionsAction = null,
        ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped
    )
        where TContext : Microsoft.EntityFrameworkCore.DbContext
    {
        Services.AddDbContext<TContext>(optionsAction, contextLifetime, optionsLifetime);
        return this;
    }
}
