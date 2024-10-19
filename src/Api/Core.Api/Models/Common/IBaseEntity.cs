namespace Core.Api.Models.Common
{
    public interface IBaseEntity : ISoftDelete, IIdentity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
