using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Domain.BaseEntity
{
    public class EntityBase : EntityBase<int>
    {
    }

    public class EntityBase<T> : IAuditableEntity, ISoftDeletable
    {
        public T Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
