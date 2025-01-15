namespace Core.Contracts.Common.Response
{
    public record OpeningHours(
        TimeOnly OpenTime,
        TimeOnly CloseTime);
}