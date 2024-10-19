namespace Api.Models.Common;

public class IBaseEntity : ISoftDelete
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
