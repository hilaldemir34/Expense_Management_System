
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManagementSystem.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var adminUserRole = new IdentityUserRole<string>
            {
                RoleId = "438c4a75-f32b-43b6-8b17-b54348c1fe3a",
                UserId = "3507e505-5dc0-43c3-b114-bb301110e471"
            };
            var personnelUserRole = new IdentityUserRole<string>
            {
                RoleId = "26c86e33-bd4c-4555-983f-84bcc70dea79",
                UserId = "cca1e8b1-3509-4632-952f-b083a54c080d"
            };

            builder.HasData(adminUserRole, personnelUserRole);
        }
    }
}
