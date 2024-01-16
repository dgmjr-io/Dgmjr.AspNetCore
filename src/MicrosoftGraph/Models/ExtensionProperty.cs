namespace Dgmjr.Graph.Models;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public partial record struct ExtensionProperty
{
    /// <summary>The name of the extension property</summary>
    [JProp("@odata.context")]
    public Uri OdataContext { get; init; }

    /// <summary>The name of the extension property</summary>
    [JProp("id")]
    public guid Id { get; init; }

    /// <summary>The data type of the extension property</summary>
    [JProp("dataType")]
    public ExtensionPropertyDataType DataType { get; init; }

    /// <summary>The description of the extension property</summary>
    [JProp("description")]
    public string Description { get; init; }

    /// <summary>The target object type of the extension property</summary>
    [JProp("targetObjects")]
    public TargetObjectType[] TargetObjects { get; init; }

    [JProp("isSyncedFromOnPremises")]
    public bool IsSyncedFromOnPremises { get; init; }
}
