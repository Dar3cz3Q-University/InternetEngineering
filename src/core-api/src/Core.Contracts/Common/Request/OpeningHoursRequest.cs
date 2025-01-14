namespace Core.Contracts.Common.Request
{
    public record OpeningHoursRequest(
        DateTime OpenTime,
        DateTime CloseTime);
}