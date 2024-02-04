namespace Portfolio.API.Data.Contracts
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
