namespace Microsoft.Extensions.DependencyInjection;

public static class MicrosoftGraphServiceCollectionExtensions
{
    public static IServiceCollection AddMicrosoftGraph(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var configSection = config.GetSection(DownstreamApis_MicrosoftGraph);
        var options = configSection.Get<MicrosoftB2CGraphOptions>();
        services
            .AddMicrosoftGraph(options => config.Bind(options))
            .AddMicrosoftIdentityConsentHandler()
            .ConfigureDownstreamApi(MicrosoftGraph, configSection);
        services.AddScoped<IUsersService, UsersService>();
        services.Configure<MicrosoftB2CGraphOptions>(configSection);
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddPassphraseGenerator(config);
        return services;
    }

    public static IServiceCollection AddPassphraseGenerator(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.Configure<PassphraseGeneratorOptions>(
            config.GetSection(PassphraseGeneratorOptions.AppSettingsKey)
        );
        services.AddSingleton<IPassphraseGenerator, PassphraseGenerator>();
        return services;
    }
}
