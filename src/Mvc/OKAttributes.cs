/*
 * OKAttributes.cs
 *
 *   Created: 2023-01-05-04:48:16
 *   Modified: 2023-01-05-04:48:16
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;

using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.AspNetCore.Http.StatusCodes;
using ApplicationMediaTypeNames = Dgmjr.Mime.ApplicationMediaTypeNames;

/// <summary>Notes that the method can produce a 200 OK response</summary>
/// <param name="modelType">The type of the model to be returned.</param>
/// <param name="description" example="Yay! You didn't fuck up!">A short description of the response indicating success.</param>
public class ProducesOKResponseAttribute(
    type modelType,
    string description = "Yay! You didn't fuck up!"
)
    : SwaggerResponseAttribute(
        Status200OK,
        description ?? "Yay! You didn't fuck up!",
        modelType,
        ApplicationMediaTypeNames.Json,
        ApplicationMediaTypeNames.Xml,
        ApplicationMediaTypeNames.MessagePack,
        ApplicationMediaTypeNames.Bson,
        TextMediaTypeNames.Plain
    )
{ }

/// <summary>Notes that the method can produce a 200 OK response</summary>
/// <typeparam name="TModel">The type of the model to be returned.</param>
/// <param name="description" example="Yay! You didn't fuck up!">A short description of the response indicating success.</param>
public sealed class ProducesOKResponseAttribute<TModel>(
    string description = "Yay! You didn't fuck up!"
)
    : ProducesCreatedResponseAttribute(typeof(TModel), description) { }

public sealed class ProducesNoContentResponseAttribute(
    string description = "You didn't fuck up and the request produced no content."
)
    : SwaggerResponseAttribute(
        Status204NoContent,
        description ?? "You didn't fuck up and the request produced no content.",
        null,
        ApplicationMediaTypeNames.Json,
        ApplicationMediaTypeNames.Xml,
        ApplicationMediaTypeNames.MessagePack,
        ApplicationMediaTypeNames.Bson,
        TextMediaTypeNames.Plain
    )
{ }

public class ProducesCreatedResponseAttribute(
    type modelType,
    string description = "The shit you were try'n'a create was created successfully."
)
    : SwaggerResponseAttribute(
        Status201Created,
        description ?? "The shit you were try'n'a create was created successfully.",
        modelType,
        ApplicationMediaTypeNames.Json,
        ApplicationMediaTypeNames.Xml,
        ApplicationMediaTypeNames.MessagePack,
        ApplicationMediaTypeNames.Bson,
        TextMediaTypeNames.Plain,
        ApplicationMediaTypeNames.ProblemJson,
        ApplicationMediaTypeNames.ProblemXml
    )
{ }

public class ProducesCreatedResponseAttribute<TModel>(
    string description = "The shit you were try'n'a create was created successfully."
)
    : ProducesCreatedResponseAttribute(typeof(TModel), description) { }

public class ProducesPartialContentResponseAttribute(
    type modelType,
    string description = "Here's some of the shit you requested."
)
    : SwaggerResponseAttribute(
        Status206PartialContent,
        description ?? "Here's some of the shit you requested.",
        modelType,
        ApplicationMediaTypeNames.Json,
        ApplicationMediaTypeNames.Xml,
        ApplicationMediaTypeNames.MessagePack,
        ApplicationMediaTypeNames.Bson,
        TextMediaTypeNames.Plain
    )
{ }
public sealed class ProducesPartialContentResponseAttribute<TModel>(
    string description = "Here's some of the shit you requested."
)
    : ProducesPartialContentResponseAttribute(typeof(TModel), description) { }

public sealed class CreateOperationAttribute(
    string? operationId,
    string? summary = "Create a new resource",
    string? description = "Create a new resource",
    string[]? tags = null
)
    : DgmjrOperationAttribute(
        operationId,
        summary ?? operationId,
        description ?? summary ?? operationId,
        tags ?? new string[] { operationId, "Create/Insert" }
    ) { }

public sealed class UpdateOperationAttribute(
    string? operationId,
    string ? summary = "Update an existing resource from a complete model object",
    string ? description = "Update an existing resource from a complete model object",
    string[] ? tags = null
)
    : DgmjrOperationAttribute(
        operationId,
        summary ?? operationId,
        description ?? summary ?? operationId,
        tags ?? new string[] { operationId, "Update" }
    ) { }

public sealed class DeleteOperationAttribute(
    string? operationId,
    string ? summary = "Delete an existing resource",
    string ? description = "Delete an existing resource",
    string[] ? tags = null
)
    : DgmjrOperationAttribute(
        operationId,
        summary ?? operationId,
        description ?? summary ?? operationId,
        tags ?? new string[] { operationId, "Delete" }
    ) { }

public sealed class PatchOperationAttribute(
    string? operationId,
    string ? summary = "Update an existing resource from a partial model object",
    string ? description = "Update an existing resource from a partial model object",
    string[] ? tags = null
)
    : DgmjrOperationAttribute(
        operationId,
        summary ?? operationId,
        description ?? summary ?? operationId,
        tags ?? new string[] { operationId, "Update", "Patch" }
    ) { }

public class DgmjrOperationAttribute : SwaggerOperationAttribute
{
    public DgmjrOperationAttribute(
        string? operationId,
        string? summary = null,
        string? description = null,
        string[]? tags = null
    )
    {
        OperationId = operationId;
        Summary = summary ?? operationId;
        Description = description ?? summary;
        Tags = tags ?? new[] { operationId };
    }

    public new virtual string OperationId
    {
        get => base.OperationId;
        set => base.OperationId = value;
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class ProducesStandardResponsesAttribute : Attribute, IApiResponseMetadataProvider
{
    public type Type { get; set; }

    public int StatusCode => throw new NotImplementedException();
    public string[] ContentTypes
    {
        get => Constants.StandardResponseMediaTypes;
        set { }
    }

    public void SetContentTypes(MediaTypeCollection contentTypes)
    {
        throw new NotImplementedException();
    }
}
