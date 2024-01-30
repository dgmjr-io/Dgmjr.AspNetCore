/*
 * PageModel.cs
 *
 *   Created: 2024-27-26T16:27:46-05:00
 *   Modified: 2024-27-26T16:27:46-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2023 - 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Razor;

using Microsoft.AspNetCore.Mvc.RazorPages;
using PageModelBase = Microsoft.AspNetCore.Mvc.RazorPages.PageModel;

public class PageModel(object? model = default) : PageModelBase
{
    public virtual object? ViewModel { get; set; } = model;

    public virtual string? Title
    {
        get => ViewData[nameof(Title)]?.ToString();
        set => ViewData[nameof(Title)] = value;
    }
    public virtual string? Description
    {
        get => ViewData[nameof(Description)]?.ToString();
        set => ViewData[nameof(Description)] = value;
    }
    public virtual string[]? Keywords
    {
        get => ViewData[nameof(Keywords)] as string[];
        set => ViewData[nameof(Keywords)] = value;
    }
    public virtual string? Author
    {
        get => ViewData[nameof(Author)]?.ToString();
        set => ViewData[nameof(Author)] = value;
    }
}

public class PageModel<T>(T? model) : PageModel(model)
{
    public new virtual T? ViewModel
    {
        get => (T?)base.ViewModel;
        set => base.ViewModel = value;
    }
}
