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

using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.AspNetCore.Http.StatusCodes;

public class ProducesOKResponseAttribute : SwaggerResponseAttribute
{
    /// <param name="modelType">The type of the model to be returned.</param>
    /// <param name="description" example="Yay! You didn't fuck up!">
    /// A short description of the response indicating success.
    /// </param>
    public ProducesOKResponseAttribute(
        type modelType,
        string description = "Yay! You didn't fuck up!"
    )
        : base(
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
}

public class ProducesNoContentResponseAttribute : SwaggerResponseAttribute
{
    public ProducesNoContentResponseAttribute(
        string description = "You didn't fuck up and the request produced no content."
    )
        : base(
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
}

public class ProducesCreatedResponseAttribute : SwaggerResponseAttribute
{
    public ProducesCreatedResponseAttribute(
        type modelType,
        string description = "The shit you were try'n'a create was created successfully."
    )
        : base(
            Status201Created,
            description ?? "The shit you were try'n'a create was created successfully.",
            modelType,
            ApplicationMediaTypeNames.Json,
            ApplicationMediaTypeNames.Xml,
            ApplicationMediaTypeNames.MessagePack,
            ApplicationMediaTypeNames.Bson,
            TextMediaTypeNames.Plain
        )
    { }
}

public class ProducesPartialContentResponseAttribute : SwaggerResponseAttribute
{
    public ProducesPartialContentResponseAttribute(
        type modelType,
        string description = "Here's some of the shit you requested."
    )
        : base(
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
}

public class CreateOperationAttribute : JwcOperationAttribute
{
    public CreateOperationAttribute(
        string? operationId,
        string? summary = "Create a new resource",
        string? description = "Create a new resource",
        string[]? tags = null
    ) : base(operationId, summary, description, tags)
    {
        OperationId = operationId;
        Summary = summary ?? operationId;
        Description = description ?? summary;
        Tags = tags ?? new[] { operationId, "Create/Insert" };
    }
}

public class UpdateOperationAttribute : JwcOperationAttribute
{
    public UpdateOperationAttribute(
        string? operationId,
        string? summary = "Update an existing resource from a complete model object",
        string? description = "Update an existing resource from a complete model object",
        string[]? tags = null
    ) : base(operationId, summary, description, tags)
    {
        OperationId = operationId;
        Summary = summary ?? operationId;
        Description = description ?? summary;
        Tags = tags ?? new[] { operationId, "Update" };
    }
}

public class DeleteOperationAttribute : JwcOperationAttribute
{
    public DeleteOperationAttribute(
        string? operationId,
        string? summary = "Delete an existing resource",
        string? description = "Delete an existing resource",
        string[]? tags = null
    ) : base(operationId, summary, description, tags)
    {
        OperationId = operationId;
        Summary = summary ?? operationId;
        Description = description ?? summary;
        Tags = tags ?? new[] { operationId, "Delete" };
    }
}

public class PatchOperationAttribute : JwcOperationAttribute
{
    public PatchOperationAttribute(
        string? operationId,
        string? summary = "Update an existing resource from a partial model object",
        string? description = "Update an existing resource from a partial model object",
        string[]? tags = null
    ) : base(operationId, summary, description, tags)
    {
        OperationId = operationId;
        Summary = summary ?? operationId;
        Description = description ?? summary;
        Tags = tags ?? new[] { operationId, "Update" };
    }
}

public class JwcOperationAttribute : SwaggerOperationAttribute
{
    public JwcOperationAttribute(
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

    public new virtual string OperationId { get => base.OperationId; set => base.OperationId = value; }
}
