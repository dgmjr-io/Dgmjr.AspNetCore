namespace Dgmjr.AspNetCore.Communication;

public interface IMessageSendResult
{
    bool IsSuccess { get; }
    int StatusCode { get; set; }
}
