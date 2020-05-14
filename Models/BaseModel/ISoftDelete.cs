namespace Burak.Boilerplate.Models.BaseModel
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
