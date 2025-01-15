namespace Core.Application.Common.Commands
{
    public record CreateOpeningHoursCommand(
        TimeOnly OpenTime,
        TimeOnly CloseTime);
}