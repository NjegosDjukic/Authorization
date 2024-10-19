namespace Core.Api.Models.Common
{
    public interface IBaseEntity : ISoftDelete
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
