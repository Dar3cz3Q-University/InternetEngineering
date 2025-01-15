namespace Core.Contracts.Common.Request
{
    public record OpeningHoursRequest(
        TimeOnly OpenTime,
        TimeOnly CloseTime);
}