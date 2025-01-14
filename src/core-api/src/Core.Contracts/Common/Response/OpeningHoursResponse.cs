namespace Core.Contracts.Common.Response
{
    public record OpeningHours(
        DateTime OpenTime,
        DateTime CloseTime);
}