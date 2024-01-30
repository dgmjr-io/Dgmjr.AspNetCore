using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Dgmjr.AspNetCore.Mvc;

public class MvcOptions : Microsoft.AspNetCore.Mvc.MvcOptions
{
    /// <summary><see langword="true" /> if you want to add controllers with views, <see langword="false" /> otherwise</summary>
    public bool AddControllersWithViews { get; set; } = false;

    /// <summary><see langword="true" /> if you want to add controllers with views, <see langword="false" /> otherwise</summary>
    public bool AddRazorPages { get; set; } = false;

    /// <summary><see langword="true" /> if you want to add controllers with views, <see langword="false" /> otherwise</summary>
    public bool AddControllersAsServices { get; set; } = false;

    /// <summary><see langword="true" /> if you want to add the Microsoft Identity UI, <see langword="false" /> otherwise</summary>
    public bool AddMicrosoftIdentityUI { get; set; } = false;

    /// <summary><see langword="true" /> if you want to add JSON serializer options, <see langword="false" /> otherwise</summary>
    public bool AddJsonOptions { get; set; } = false;

    /// <summary><see langword="true" /> if you want to add XML serializer formatters, <see langword="false" /> otherwise</summary>
    public bool AddXmlSerializerFormatters { get; set; } = false;

    /// <summary><see langword="true" /> if you want to add XML data contract serializer formatters, <see langword="false" /> otherwise</summary>
    public bool AddXmlDataContractSerializerFormatters { get; set; } = false;

    /// <summary><see langword="true" /> if you want to add the DGMJR MVC conventions, <see langword="false" /> otherwise</summary>
    public bool AddMvcConventions { get; set; } = false;

    /// <summary><see langword="true" /> if you want to add controllers, <see langword="false" /> otherwise</summary>
    public bool AddControllers { get; set; } = false;

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.AllowEmptyInputInBodyModelBinding" />
    public new bool AllowEmptyInputInBodyModelBinding
    {
        get => base.AllowEmptyInputInBodyModelBinding;
        set => base.AllowEmptyInputInBodyModelBinding = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.EnableActionInvokers" />
    public new bool EnableActionInvokers
    {
        get => base.EnableActionInvokers;
        set => base.EnableActionInvokers = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.EnableEndpointRouting" />
    public new bool EnableEndpointRouting
    {
        get => base.EnableEndpointRouting;
        set => base.EnableEndpointRouting = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.RespectBrowserAcceptHeader" />
    public new bool RespectBrowserAcceptHeader
    {
        get => base.RespectBrowserAcceptHeader;
        set => base.RespectBrowserAcceptHeader = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.RequireHttpsPermanent" />
    public new bool RequireHttpsPermanent
    {
        get => base.RequireHttpsPermanent;
        set => base.RequireHttpsPermanent = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.SuppressAsyncSuffixInActionNames" />
    public new bool SuppressAsyncSuffixInActionNames
    {
        get => base.SuppressAsyncSuffixInActionNames;
        set => base.SuppressAsyncSuffixInActionNames = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.SuppressInputFormatterBuffering" />
    public new bool SuppressInputFormatterBuffering
    {
        get => base.SuppressInputFormatterBuffering;
        set => base.SuppressInputFormatterBuffering = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.SuppressOutputFormatterBuffering" />
    public new bool SuppressOutputFormatterBuffering
    {
        get => base.SuppressOutputFormatterBuffering;
        set => base.SuppressOutputFormatterBuffering = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.ValidateComplexTypesIfChildValidationFails" />
    public new bool ValidateComplexTypesIfChildValidationFails
    {
        get => base.ValidateComplexTypesIfChildValidationFails;
        set => base.ValidateComplexTypesIfChildValidationFails = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes" />
    public new bool SuppressImplicitRequiredAttributeForNonNullableReferenceTypes
    {
        get => base.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes;
        set => base.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.ReturnHttpNotAcceptable" />
    public new bool ReturnHttpNotAcceptable
    {
        get => base.ReturnHttpNotAcceptable;
        set => base.ReturnHttpNotAcceptable = value;
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.CacheProfiles" />
    public new IDictionary<string, CacheProfile> CacheProfiles
    {
        get => base.CacheProfiles;
        set
        {
            base.CacheProfiles.Clear();
            ForEach(value.ToArray(), cp => base.CacheProfiles.Add(cp));
        }
    }

    /// <inheritdoc cref="Microsoft.AspNetCore.Mvc.MvcOptions.Conventions" />
    public new IList<IApplicationModelConvention> Conventions
    {
        get => base.Conventions;
        set
        {
            base.Conventions.Clear();
            ForEach(value.ToArray(), c => base.Conventions.Add(c));
        }
    }
}
