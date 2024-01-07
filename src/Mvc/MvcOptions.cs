namespace Dgmjr.AspNetCore.Mvc;

public class MvcOptions : Microsoft.AspNetCore.Mvc.MvcOptions
{
    public bool AddControllersWithViews { get; set; } = false;
    public bool AddRazorPages { get; set; } = false;
    public bool AddControllersAsServices { get; set; } = false;
    public bool AddMicrosoftIdentityUI { get; set; } = false;
    public bool AddJsonOptions { get; set; } = false;
    public bool AddXmlSerializerFormatters { get; set; } = false;
    public bool AddXmlDataContractSerializerFormatters { get; set; } = false;
    public bool AddMvcConventions { get; set; } = false;
    public bool AddControllers { get; set; } = false;
}
