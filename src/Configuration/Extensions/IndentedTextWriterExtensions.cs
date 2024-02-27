namespace Dgmjr.Configuration.Extensions;

public static class IndentedTextWriterExtensions
{
    public static void IncreaseIndent(this IndentedTextWriter writer)
    {
        writer.Indent += 2;
    }

    public static void DecreaseIndent(this IndentedTextWriter writer)
    {
        writer.Indent -= 2;
    }
}
