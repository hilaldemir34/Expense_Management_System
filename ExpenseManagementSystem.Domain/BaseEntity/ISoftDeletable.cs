namespace ExpenseManagementSystem.Domain.BaseEntity
{
    public interface ISoftDeletable
    {
        DateTime? DeletedAtUtc { get; set; }
    }
}
