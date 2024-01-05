namespace Dgmjr.MicrosoftGraph.Models;

public class ExtensionPropertyCreateDto
{
    /// <summary>The name of the extension property</summary>
    [Required, JProp("name")]
    public string Name { get; set; }

    /// <summary>The data type of the extension property</summary>
    [Required, JProp("dataType")]
    public ExtensionPropertyDataType DataType { get; set; }

    /// <summary>The description of the extension property</summary>
    [JProp("description")]
    public string Description { get; set; }

    /// <summary>The target object type of the extension property</summary>
    [Required]
    public TargetObjectType[] TargetObjects { get; set; }

    /// <summary>The name of the owner of the extension property</summary>
    public string Owner { get; set; }

    /// <summary>The name of the owner of the extension property</summary>
    public guid AppId { get; set; }

    /// <summary>The name of the owner of the extension property</summary>
    public string Id { get; set; }
}
