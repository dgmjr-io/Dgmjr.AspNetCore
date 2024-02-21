namespace Dgmjr.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using OneOf.Types;

using MsMvcOptions = Microsoft.AspNetCore.Mvc.MvcOptions;

public class MvcOptions(MsMvcOptions mvc)
{
    public MvcOptions()
        : this(
            new MsMvcOptions
            {
                AllowEmptyInputInBodyModelBinding = false,
                RespectBrowserAcceptHeader = true
            }
        )
{ }

/// <summary><see langword="true" /> if you want to add controllers with views, <see langword="false" /> otherwise</summary>
public virtual bool AddControllersWithViews { get; set; } = false;
public virtual bool AddControllersAsServices { get; set; } = false;

/// <summary><see langword="true" /> if you want to add Razor pages, <see langword="false" /> otherwise</summary>
public virtual bool AddRazorPages { get; set; } = false;

/// <summary><see langword="true" /> if you want to add Razor components, <see langword="false" /> otherwise</summary>
public virtual bool AddRazorComponents { get; set; } = false;

/// <summary><see langword="true" /> if you want to add interactive server components, <see langword="false" /> otherwise</summary>
public virtual bool AddInteractiveServerComponents { get; set; } = false;

/// <summary><see langword="true" /> if you want to add controllers with views, <see langword="false" /> otherwise</summary>
/// public virtual bool AddControllersAsServices { get; set; } = false;

/// <summary><see langword="true" /> if you want to add the Microsoft Identity UI, <see langword="false" /> otherwise</summary>
public virtual bool AddMicrosoftIdentityUI { get; set; } = false;

/// <summary><see langword="true" /> if you want to add JSON serializer  <see langword="false" /> otherwise</summary>
public virtual bool AddJsonOptions { get; set; } = false;

/// <summary><see langword="true" /> if you want to add XML serializer formatters, <see langword="false" /> otherwise</summary>
public virtual bool AddXmlSerializerFormatters { get; set; } = false;

/// <summary><see langword="true" /> if you want to add XML data contract serializer formatters, <see langword="false" /> otherwise</summary>
public virtual bool AddXmlDataContractSerializerFormatters { get; set; } = false;

/// <summary><see langword="true" /> if you want to add the DGMJR MVC conventions, <see langword="false" /> otherwise</summary>
public virtual bool AddMvcConventions { get; set; } = false;

/// <summary><see langword="true" /> if you want to add controllers, <see langword="false" /> otherwise</summary>
public virtual bool AddControllers { get; set; } = false;

/// <inheritdoc cref="MsMvcOptions.AllowEmptyInputInBodyModelBinding" />
public virtual bool AllowEmptyInputInBodyModelBinding { get; set; } =
    mvc.AllowEmptyInputInBodyModelBinding;

/// <inheritdoc cref="MsMvcOptions.EnableActionInvokers" />
public virtual bool EnableActionInvokers { get; set; } = mvc.EnableActionInvokers;

/// <inheritdoc cref="MsMvcOptions.EnableEndpointRouting" />
public virtual bool EnableEndpointRouting { get; set; } = mvc.EnableEndpointRouting;

/// <inheritdoc cref="MsMvcOptions.RespectBrowserAcceptHeader" />
public virtual bool RespectBrowserAcceptHeader { get; set; } = mvc.RespectBrowserAcceptHeader;

/// <inheritdoc cref="MsMvcOptions.RequireHttpsPermanent" />
public virtual bool RequireHttpsPermanent { get; set; } = mvc.RequireHttpsPermanent;

/// <inheritdoc cref="MsMvcOptions.SuppressAsyncSuffixInActionNames" />
public virtual bool SuppressAsyncSuffixInActionNames { get; set; } =
    mvc.SuppressAsyncSuffixInActionNames;

/// <inheritdoc cref="MsMvcOptions.SuppressInputFormatterBuffering" />
public virtual bool SuppressInputFormatterBuffering { get; set; } =
    mvc.SuppressInputFormatterBuffering;

/// <inheritdoc cref="MsMvcOptions.SuppressOutputFormatterBuffering" />
public virtual bool SuppressOutputFormatterBuffering { get; set; } =
    mvc.SuppressOutputFormatterBuffering;

/// <inheritdoc cref="MsMvcOptions.ValidateComplexTypesIfChildValidationFails" />
public virtual bool ValidateComplexTypesIfChildValidationFails { get; set; } =
    mvc.ValidateComplexTypesIfChildValidationFails;

/// <inheritdoc cref="MsMvcOptions.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes" />
public virtual bool SuppressImplicitRequiredAttributeForNonNullableReferenceTypes { get; set; } =
    mvc.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes;

/// <inheritdoc cref="MsMvcOptions.ReturnHttpNotAcceptable" />
public virtual bool ReturnHttpNotAcceptable { get; set; } = mvc.ReturnHttpNotAcceptable;

/// <summary><see langword="true" /> if you want to use antiforgery, <see langword="false" /> otherwise</summary>
/// <remarks>!!! Only supported in .NET 8.0+ !!!!  Ignored otherwise.</remarks>
public virtual bool UseAntiforgery { get; set; } = true;

/// <inheritdoc cref="MsMvcOptions.CacheProfiles" />
public virtual IDictionary<string, CacheProfile> CacheProfiles { get; set; } =
    mvc.CacheProfiles;

/// <inheritdoc cref="MsMvcOptions.Conventions" />
public virtual IList<IApplicationModelConvention> Conventions { get; set; } = mvc.Conventions;

/// <inheritdoc cref="MsMvcOptions.Filters" />
public virtual FilterCollection Filters { get; set; } = mvc.Filters;

/// <inheritdoc cref="MsMvcOptions.FormatterMappings" />
public virtual FormatterMappings FormatterMappings { get; set; } = mvc.FormatterMappings;

/// <inheritdoc cref="MsMvcOptions.InputFormatters" />
public virtual FormatterCollection<IInputFormatter> InputFormatters { get; set; } =
    mvc.InputFormatters;

/// <inheritdoc cref="MsMvcOptions.ModelBinderProviders" />
public virtual int MaxModelValidationErrors { get; set; } = mvc.MaxModelValidationErrors;

/// <inheritdoc cref="MsMvcOptions.ModelBinderProviders" />
public virtual IList<IModelBinderProvider> ModelBinderProviders { get; set; } =
    mvc.ModelBinderProviders;

/// <inheritdoc cref="MsMvcOptions.ModelBindingMessageProvider" />
public virtual DefaultModelBindingMessageProvider ModelBindingMessageProvider { get; set; } =
    mvc.ModelBindingMessageProvider;

/// <inheritdoc cref="MsMvcOptions.ModelMetadataDetailsProviders" />
public virtual IList<IMetadataDetailsProvider> ModelMetadataDetailsProviders { get; set; } =
    mvc.ModelMetadataDetailsProviders;

/// <inheritdoc cref="MsMvcOptions.ModelValidatorProviders" />
public virtual IList<IModelValidatorProvider> ModelValidatorProviders { get; set; } =
    mvc.ModelValidatorProviders;

/// <inheritdoc cref="MsMvcOptions.OutputFormatters" />
public virtual FormatterCollection<IOutputFormatter> OutputFormatters { get; set; } =
    mvc.OutputFormatters;

/// <inheritdoc cref="MsMvcOptions.ValueProviderFactories" />
public virtual IList<IValueProviderFactory> ValueProviderFactories { get; set; } =
    mvc.ValueProviderFactories;

/// <inheritdoc cref="MsMvcOptions.SslPort" />
public virtual int? SslPort { get; set; } = mvc.SslPort;

/// <inheritdoc cref="MsMvcOptions.MaxValidationDepth" />
public virtual int? MaxValidationDepth { get; set; } = mvc.MaxValidationDepth;

/// <inheritdoc cref="MsMvcOptions.MaxModelBindingCollectionSize" />
public virtual int MaxModelBindingCollectionSize { get; set; } =
    mvc.MaxModelBindingCollectionSize;

/// <inheritdoc cref="MsMvcOptions.MaxModelBindingRecursionDepth" />
public virtual int MaxModelBindingRecursionDepth { get; set; } =
    mvc.MaxModelBindingRecursionDepth;

/// <inheritdoc cref="MsMvcOptions.MaxIAsyncEnumerableBufferLimit" />
public virtual int MaxIAsyncEnumerableBufferLimit { get; set; } =
    mvc.MaxIAsyncEnumerableBufferLimit;

public static implicit operator MsMvcOptions(MvcOptions options) =>
    options.CopyTo(new MsMvcOptions());

public virtual MsMvcOptions CopyTo(MsMvcOptions mvcOpts)
{
    mvcOpts.AllowEmptyInputInBodyModelBinding = AllowEmptyInputInBodyModelBinding;
    mvcOpts.EnableActionInvokers = EnableActionInvokers;
    mvcOpts.EnableEndpointRouting = EnableEndpointRouting;
    mvcOpts.MaxIAsyncEnumerableBufferLimit = MaxIAsyncEnumerableBufferLimit;
    mvcOpts.MaxModelBindingCollectionSize = MaxModelBindingCollectionSize;
    mvcOpts.MaxModelBindingRecursionDepth = MaxModelBindingRecursionDepth;
    mvcOpts.MaxModelValidationErrors = MaxModelValidationErrors;
    mvcOpts.MaxValidationDepth = MaxValidationDepth;
    mvcOpts.RequireHttpsPermanent = RequireHttpsPermanent;
    mvcOpts.RespectBrowserAcceptHeader = RespectBrowserAcceptHeader;
    mvcOpts.ReturnHttpNotAcceptable = ReturnHttpNotAcceptable;
    mvcOpts.SslPort = SslPort;
    mvcOpts.SuppressAsyncSuffixInActionNames = SuppressAsyncSuffixInActionNames;
    mvcOpts.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes =
        SuppressImplicitRequiredAttributeForNonNullableReferenceTypes;
    mvcOpts.SuppressInputFormatterBuffering = SuppressInputFormatterBuffering;
    mvcOpts.SuppressOutputFormatterBuffering = SuppressOutputFormatterBuffering;
    mvcOpts.ValidateComplexTypesIfChildValidationFails =
        ValidateComplexTypesIfChildValidationFails;

    // mvcOpts.CacheProfiles.Clear();
    foreach (var profile in CacheProfiles)
    {
        mvcOpts.CacheProfiles[profile.Key] = profile.Value;
    }
    // mvcOpts.Filters.Clear();
    foreach (var v in Filters)
    {
        mvcOpts.Filters.Add(v);
    }
    // mvcOpts.InputFormatters.Clear();
    foreach (var v in InputFormatters)
    {
        mvcOpts.InputFormatters.Add(v);
    }
    // mvcOpts.OutputFormatters.Clear();
    foreach (var v in OutputFormatters)
    {
        mvcOpts.OutputFormatters.Add(v);
    }
    // mvcOpts.Conventions.Clear();
    foreach (var v in Conventions)
    {
        mvcOpts.Conventions.Add(v);
    }
    // mvcOpts.ValueProviderFactories.Clear();
    foreach (var v in ValueProviderFactories)
    {
        mvcOpts.ValueProviderFactories.Add(v);
    }
    // mvcOpts.ModelBinderProviders.Clear();
    foreach (var v in ModelBinderProviders)
    {
        mvcOpts.ModelBinderProviders.Add(v);
    }
    // mvcOpts.ModelMetadataDetailsProviders.Clear();
    foreach (var v in ModelMetadataDetailsProviders)
    {
        mvcOpts.ModelMetadataDetailsProviders.Add(v);
    }
    // mvcOpts.ModelValidatorProviders.Clear();
    foreach (var v in ModelValidatorProviders)
    {
        mvcOpts.ModelValidatorProviders.Add(v);
    }
    return mvcOpts;
}
}
