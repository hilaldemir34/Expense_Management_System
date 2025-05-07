using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Persistence.Configurations
{

    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            var adminRole = new ApplicationRole
            {
                Id = "438c4a75-f32b-43b6-8b17-b54348c1fe3a",
                Name = ApplicationRole.Admin,
                NormalizedName = ApplicationRole.Admin.ToUpperInvariant(),
                ConcurrencyStamp = "cca1e8b1-3509-4632-952f-b083a54c0807"
            };
            var personnelRole = new ApplicationRole
            {
                Id = "26c86e33-bd4c-4555-983f-84bcc70dea79",
                Name =ApplicationRole.Personnel,
                NormalizedName = ApplicationRole.Personnel.ToUpperInvariant(),
                ConcurrencyStamp = "cca1e8b1-3509-4632-952f-b083a54c0808"
            };

            builder.HasData(adminRole, personnelRole);
        }
    }
}
