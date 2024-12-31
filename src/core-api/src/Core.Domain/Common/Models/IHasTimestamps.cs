namespace Core.Domain.Common.Models
{
    public interface IHasTimestamps
    {
        DateTime CreatedDateTime { get; }
        DateTime UpdatedDateTime { get; }
    }

}