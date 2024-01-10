namespace Dgmjr.AspNetCore.Swagger.UI;

public enum SwaggerUI
{
    [Uri("https://raw.githubusercontent.com/swagger-api/swagger-ui/master/dist/")]
    Classic,
    [Uri("https://raw.githubusercontent.com/afgarcia86/bootstrap-swagger-ui/master/dist/")]
    Bootstrap,
    Custom
}
