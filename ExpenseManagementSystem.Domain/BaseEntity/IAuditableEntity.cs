namespace ExpenseManagementSystem.Domain.BaseEntity
{
    public interface IAuditableEntity
    {
        DateTime CreatedAtUtc { get; set; }
        DateTime? UpdatedAtUtc { get; set; }
    }
}
