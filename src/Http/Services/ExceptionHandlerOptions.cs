namespace Dgmjr.AspNetCore.Http;

public class ExceptionHandlerOptions : Microsoft.AspNetCore.Builder.ExceptionHandlerOptions
{
    public bool UseDeveloperExceptionPage { get; set; } = false;
}
