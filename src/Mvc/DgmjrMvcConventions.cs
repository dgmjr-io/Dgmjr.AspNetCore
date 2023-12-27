namespace Dgmjr.AspNetCore.Mvc;

public static class DgmjrMvcConventions
{
    public static IServiceCollection AddDgmjrMvcConventions(this IServiceCollection services)
    {
        return services;
    }

    [ProducesOKResponse<object>]
    public static void Create() { }
}
