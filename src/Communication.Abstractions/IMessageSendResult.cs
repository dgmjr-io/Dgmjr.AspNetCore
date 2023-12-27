namespace Dgmjr.AspNetCore.Communication;

public interface IMessageSendResult
{
    bool IsSuccess { get; }
    int StatusCode { get; init; }
}

public interface IMessageSendResult<TStatus> : IMessageSendResult
    where TStatus : IIdentifiable<int>
{
    TStatus Status { get; init; }
}
