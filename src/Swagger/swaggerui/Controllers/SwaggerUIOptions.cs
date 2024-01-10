namespace Dgmjr.AspNetCore.Swagger.UI;

public class SwaggerUIOptions : Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIOptions
{
    public SwaggerUI SwaggerUI { get; set; } = SwaggerUI.Classic;

    public bool UseReverseProxy { get; set; } = true;
    public bool UseCache { get; set; } = true;
    public bool UseReverseProxyForIndexHtml { get; set; } = true;

    private string _reverseProxyEndpoint;
    public string ReverseProxyEndpoint
    {
        get
        {
            return _reverseProxyEndpoint = SwaggerUI switch
            {
                SwaggerUI.Classic => "https://raw.githubusercontent.com/swagger-api/swagger-ui/master/dist/",
                SwaggerUI.Bootstrap => "https://raw.githubusercontent.com/afgarcia86/bootstrap-swagger-ui/master/dist/",
                _ => _reverseProxyEndpoint,
            };
        }
        set
        {
            _reverseProxyEndpoint = value;
            if (!value.EndsWith('/'))
            {
                _reverseProxyEndpoint += "/";
            }
        }
    }
}
