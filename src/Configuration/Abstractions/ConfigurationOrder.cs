namespace Dgmjr.Configuration.Extensions;

public enum ConfigurationOrder
{
    First = -1000,
    VeryEarly = 0,
    Early = 100,
    Middle = 200,
    Late = 300,
    VeryLate = 400,
    AnyTime = 500
}
