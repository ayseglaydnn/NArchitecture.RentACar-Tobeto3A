namespace Core.Persistence.Repositories;

public class BaseEntity<TId>
{
    public TId Id { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }

    public BaseEntity()
    {

    }

    public BaseEntity(TId id, DateTime createdDate, DateTime updatedDate, DateTime deletedDate, bool isDeleted = false)
    {
        Id = id;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        DeletedDate = deletedDate;
        IsDeleted = isDeleted;
    }
}
