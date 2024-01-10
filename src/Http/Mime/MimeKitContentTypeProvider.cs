namespace Dgmjr.AspNetCore.StaticFiles;

public class MimeKitContentTypeProvider : Microsoft.AspNetCore.StaticFiles.IContentTypeProvider
{
    public bool TryGetContentType(string subpath, out string contentType)
    {
        contentType = MimeKit.MimeTypes.GetMimeType(subpath);
        return true;
    }
}
