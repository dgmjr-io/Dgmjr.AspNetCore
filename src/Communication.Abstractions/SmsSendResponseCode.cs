namespace Dgmjr.AspNetCore.Communication.Sms;

public partial record struct SmsSendResponseCode
{
    public static Abstractions.ISmsSendResponseCode FromId(int id) => FromValue((Enums.SmsSendResponseCode)id);
}
