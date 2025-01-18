namespace Core.Domain.Common.Models
{
    public interface IHasTimestamps
    {
        DateTime CreatedDateTime { get; set; } // TODO: Make setter private
        DateTime UpdatedDateTime { get; set; } // TODO: Make setter private
    }

}