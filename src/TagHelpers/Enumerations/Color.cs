namespace Dgmjr.AspNetCore.TagHelpers.Enumerations;

public enum Color
{
    None = 0,
    none = None,
    Unspecified = None,
    unspecified = None,

    [ColorInfo(
        "primary",
        TextCssClass = "text-primary",
        BackgroundCssClass = "bg-primary",
        BorderCssClass = "border-primary"
    )]
    Primary,
    primary = Primary,

    [ColorInfo(
        "secondary",
        TextCssClass = "text-secondary",
        BackgroundCssClass = "bg-secondary",
        BorderCssClass = "border-secondary"
    )]
    Secondary,
    secondary = Secondary,

    [ColorInfo(
        "success",
        TextCssClass = "text-success",
        BackgroundCssClass = "bg-success",
        BorderCssClass = "border-success"
    )]
    Success,
    success = Success,

    [ColorInfo(
        "danger",
        TextCssClass = "text-danger",
        BackgroundCssClass = "bg-danger",
        BorderCssClass = "border-danger"
    )]
    Danger,
    danger = Danger,

    [ColorInfo(
        "warning",
        TextCssClass = "text-warning",
        BackgroundCssClass = "bg-warning",
        BorderCssClass = "border-warning"
    )]
    Warning,
    warning = Warning,

    [ColorInfo(
        "info",
        TextCssClass = "text-info",
        BackgroundCssClass = "bg-info",
        BorderCssClass = "border-info"
    )]
    Info,
    info = Info,

    [ColorInfo(
        "light",
        TextCssClass = "text-light",
        BackgroundCssClass = "bg-light",
        BorderCssClass = "border-light"
    )]
    Light,
    light = Light,

    [ColorInfo(
        "dark",
        TextCssClass = "text-dark",
        BackgroundCssClass = "bg-dark",
        BorderCssClass = "border-dark"
    )]
    Dark,
    dark = Dark,

    [ColorInfo(
        "white",
        TextCssClass = "text-white",
        BackgroundCssClass = "bg-white",
        BorderCssClass = "border-white"
    )]
    White,
    Link,
    link = Link
}
