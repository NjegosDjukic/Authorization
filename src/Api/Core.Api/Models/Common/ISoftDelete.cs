namespace Core.Api.Models.Common
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
