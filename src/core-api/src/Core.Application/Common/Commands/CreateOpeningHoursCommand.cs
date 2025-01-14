namespace Core.Application.Common.Commands
{
    public record CreateOpeningHoursCommand(
        DateTime OpenTime,
        DateTime CloseTime);
}