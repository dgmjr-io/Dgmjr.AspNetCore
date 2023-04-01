/*
 * AddSwaggerGenExtension.cs
 *
 *   Created: 2022-12-05-07:35:08
 *   Modified: 2022-12-05-07:35:08
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using static System.String;

public record TThisAssemblyStaticProxy(type ThisAssemblyStaticProxy)
{
    public type? Project =>
        ThisAssemblyStaticProxy.GetNestedTypes().FirstOrDefault(t => t.Name == nameof(Project));
    public type? Info =>
        ThisAssemblyStaticProxy.GetNestedTypes().FirstOrDefault(t => t.Name == nameof(Info));
    public Assembly Assembly => ThisAssemblyStaticProxy.Assembly;

    public string? AssemblyVersion =>
        Project?.GetRuntimeField(nameof(AssemblyVersion))?.GetValue(null) as string
        ?? Info?.GetRuntimeField(nameof(AssemblyVersion))?.GetValue(null) as string
        ?? Assembly.GetCustomAttributes<AssemblyVersionAttribute>()?.FirstOrDefault()?.Version;
    public string? Authors => Project?.GetRuntimeField(nameof(Authors))?.GetValue(null) as string;
    public string? Company =>
        Project?.GetRuntimeField(nameof(Company))?.GetValue(null) as string
        ?? Assembly.GetCustomAttributes<AssemblyCompanyAttribute>()?.FirstOrDefault()?.Company;
    public string? ContactEmail =>
        Project?.GetRuntimeField(nameof(ContactEmail))?.GetValue(null) as string;
    public string? Copyright =>
        Project?.GetRuntimeField(nameof(Copyright))?.GetValue(null) as string
        ?? Assembly.GetCustomAttributes<AssemblyCopyrightAttribute>()?.FirstOrDefault()?.Copyright;
    public string? Description =>
        Assembly.GetCustomAttributes<AssemblyDescriptionAttribute>()?.FirstOrDefault()?.Description
        ?? this.ThisAssemblyStaticProxy
            ?.GetRuntimeField(nameof(Description))
            ?.GetValue(null)
            ?.ToString()
        ?? Project?.GetRuntimeField(nameof(Description))?.GetValue(null) as string;
    public string? FileVersion =>
        Project?.GetRuntimeField(nameof(FileVersion))?.GetValue(null) as string
        ?? Assembly.GetCustomAttributes<AssemblyFileVersionAttribute>()?.FirstOrDefault()?.Version;
    public string? InformationalVersion =>
        Project?.GetRuntimeField(nameof(InformationalVersion))?.GetValue(null) as string;
    public string? LicenseExpression =>
        Project?.GetRuntimeField(nameof(LicenseExpression))?.GetValue(null)?.ToString()
        ?? Project?.GetRuntimeField(nameof(LicenseExpression))?.GetValue(null)?.ToString()
        ?? PackageLicenseExpression
        ?? "None";
    public string? Owners => Project?.GetRuntimeField(nameof(Owners))?.GetValue(null) as string;
    public string? PackageLicenseExpression =>
        Project?.GetRuntimeField(nameof(PackageLicenseExpression))?.GetValue(null) as string;
    public string? PackageTags =>
        Project?.GetRuntimeField(nameof(PackageTags))?.GetValue(null) as string;
    public string? PackageVersion =>
        Project?.GetRuntimeField(nameof(PackageVersion))?.GetValue(null) as string;
    public string? Product => Project?.GetRuntimeField(nameof(Product))?.GetValue(null) as string;
    public string? SwaggerTheme =>
        Project?.GetRuntimeField(nameof(SwaggerTheme))?.GetValue(null) as string;
    public string? Title =>
        Project?.GetRuntimeField(nameof(Title))?.GetValue(null) as string
        ?? Assembly.GetCustomAttributes<AssemblyTitleAttribute>()?.FirstOrDefault()?.Title;
    public string? Version => Project?.GetRuntimeField(nameof(Version))?.GetValue(null) as string;
    public uri? LicenseUrl => $"https://opensource.org/licenses/{LicenseExpression}";
    public uri? PackageProjectUrl =>
        Project?.GetRuntimeField(nameof(PackageProjectUrl))?.GetValue(null) as string
        ?? "https://example.com/contact";
    public uri? RepositoryUrl =>
        Project?.GetRuntimeField(nameof(RepositoryUrl))?.GetValue(null) as string ?? "about:blank";
    public uri? TermsOfServiceUrl =>
        Project?.GetRuntimeField(nameof(TermsOfServiceUrl))?.GetValue(null) as string
        ?? "https://example.com/terms";
    public string? ApiVersion =>
        "v"
        + (
            IsNullOrEmpty(PackageVersion)
                ? IsNullOrEmpty(FileVersion)
                    ? IsNullOrEmpty(Version)
                        ? IsNullOrEmpty(AssemblyVersion)
                            ? "0.0.1-Preview"
                            : AssemblyVersion
                        : Version
                    : FileVersion
                : PackageVersion
        );
}
