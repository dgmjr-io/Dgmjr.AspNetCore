#pragma warning disable
using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using Vogen;
using static System.Net.Http.Headers.HttpRequestHeaderNames;
using static System.Net.HttpStatusCode;

namespace Dgmjr.Payloads.ModelBinders
{
    public class RangeRequestAttribute : ModelBinderAttribute
    {
        public RangeRequestAttribute()
            : base(typeof(RangeRequestModelBinder))
        {
            this.BindingSource = BindingSource.Header;
            this.BinderType = typeof(RangeRequestModelBinder);
            this.Name = HttpRequestHeaderNames.Range.DisplayName;
        }
    }

    [ModelBinderAttribute(BinderType = typeof(RangeRequestModelBinder))]
    public class RangeRequestModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var rangeRequest = new Payloads.Range();
            var start = 0;
            var end = int.MaxValue;
            int pageNumber = 1;
            int pageSize = int.MaxValue;
            var rangeHeader = bindingContext.HttpContext.Request
                .GetTypedHeaders()
                ?.Range?.Ranges?.FirstOrDefault();
            try
            {
                if (rangeHeader != null)
                {
                    rangeRequest = Range.From(rangeHeader);
                    bindingContext.BindingSource = BindingSource.Header;
                    // rangeRequest.PageNumber = (int)rangeHeader.Ranges.First().From.Value;
                    // rangeRequest.PageSize = (int)rangeHeader.Ranges.First().To.Value - (int)rangeHeader.Ranges.First().From.Value;
                }
                else if (
                    bindingContext.HttpContext.Request.Headers[
                        HttpRequestHeaderNames.Range.DisplayName
                    ] != default(StringValues)
                    && Range.TryParse(
                        bindingContext.HttpContext.Request.Headers[
                            HttpRequestHeaderNames.Range.DisplayName
                        ].First(),
                        out rangeRequest
                    )
                )
                {
                    bindingContext.BindingSource = BindingSource.Header;
                }
                else if (
                    bindingContext.HttpContext.Request.TryGetHeaderParam<int>(
                        XPageSize.DisplayName,
                        out pageSize
                    )
                    && bindingContext.HttpContext.Request.TryGetHeaderParam<int>(
                        XPageNumber.DisplayName,
                        out pageNumber
                    )
                )
                {
                    rangeRequest = Range.From(pageNumber, pageSize);
                    bindingContext.BindingSource = BindingSource.Header;
                    // rangeRequest.PageSize = pageSize;
                    // rangeRequest.PageNumber = pageNumber;
                }
                else if (
                    bindingContext.HttpContext.Request.TryGetQueryStringParam<int>(
                        "page-size",
                        out pageSize
                    )
                    && bindingContext.HttpContext.Request.TryGetQueryStringParam<int>(
                        "page",
                        out pageNumber
                    )
                )
                {
                    rangeRequest = Range.From(pageNumber, pageSize);
                    bindingContext.BindingSource = BindingSource.Query;
                    // rangeRequest.PageSize = qpageSize;
                    // rangeRequest.PageNumber = qpageNumber;
                }
                else if (
                    bindingContext.HttpContext.Request.TryGetQueryStringParam<int>(
                        "pageSize",
                        out pageSize
                    )
                    && bindingContext.HttpContext.Request.TryGetQueryStringParam<int>(
                        "page",
                        out pageNumber
                    )
                )
                {
                    rangeRequest = Range.From(pageNumber, pageSize);
                    bindingContext.BindingSource = BindingSource.Query;
                    // rangeRequest.PageSize = q2pageSize;
                    // rangeRequest.PageNumber = q2pageNumber;
                }
                else
                {
                    rangeRequest = default;
                    bindingContext.Result = ModelBindingResult.Failed();
                }
            }
            catch (ValueObjectValidationException vove)
            {
                bindingContext.HttpContext.Response.StatusCode = (int)RequestedRangeNotSatisfiable;
                bindingContext.ModelState.AddModelError("RangeRequest", vove.Message);
            }

            bindingContext.Result = ModelBindingResult.Success(rangeRequest);

            /*
                        bindingContext.Model = new RangeRequest
                        {
                            PageNumber =
                            bindingContext
                                .HttpContext
                                .Request
                                .TryGetHeaderParam<int>(XPageNumber, out var pageNumber) ? pageNumber :
                            bindingContext
                                .HttpContext
                                .Request
                                .TryGetQueryStringParam<int>("page", out var qpageNumber) ? qpageNumber :
                            throw new ArgumentNullException(nameof(pageNumber)),

                            PageSize =
                            bindingContext
                                .HttpContext
                                .Request
                                .TryGetHeaderParam<int>(XPageSize, out var pageSize) ? pageSize :
                            bindingContext
                                .HttpContext
                                .Request
                                .TryGetQueryStringParam<int>("page-size", out var qpageSize) ? qpageSize :
                            bindingContext
                                .HttpContext
                                .Request
                                .TryGetQueryStringParam<int>("pageSize", out var q2pageSize) ? q2pageSize :
                            throw new ArgumentNullException(nameof(pageSize))
                        };*/
        }
    }
}
