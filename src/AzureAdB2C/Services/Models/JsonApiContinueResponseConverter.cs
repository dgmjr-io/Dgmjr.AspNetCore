namespace Dgmjr.AzureAdB2C.Json;
using System;
using System.Text.Json;

using Dgmjr.AzureAdB2C.Models;

using Microsoft.AspNetCore.Http;
public class JsonApiContinueResponseConverter : JsonConverter<ApiContinueResponse>
{
    public override ApiContinueResponse? Read(ref Utf8JsonReader reader, type typeToConvert, Jso options)
    {
        throw new NotImplementedException("This converter is only for writing");
    }

    public override void Write(Utf8JsonWriter writer, ApiContinueResponse value, Jso options)
    {
        writer.WriteStartObject();
        writer.WriteString("version", value.Version.ToString());
        writer.WriteString("action", value.Action.ToString());
        writer.WriteNumber("status", value.StatusCode ?? StatusCodes.Status200OK);
        foreach(var (claimType, claimValue) in value.Claims)
        {
            writer.WriteString(claimType, claimValue);
        }
        writer.WriteEndObject();
    }
}
