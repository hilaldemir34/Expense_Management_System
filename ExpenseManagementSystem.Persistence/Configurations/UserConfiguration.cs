using ExpenseManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManagementSystem.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var adminUser = new ApplicationUser
            {
                Id = "3507e505-5dc0-43c3-b114-bb301110e471",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@app.com",
                NormalizedEmail = "ADMIN@APP.COM",
                EmailConfirmed = true,
                SecurityStamp = "3507e505-5dc0-43c3-b114-bb301110e472",
                ConcurrencyStamp = "3507e505-5dc0-43c3-b114-bb301110e473",
                AccessFailedCount = 0,
                LockoutEnabled = false,
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                Iban = "",
                NameSurname = "",
                PasswordHash= "AQAAAAIAAYagAAAAECYJ02SHSzJZGRfX4x7D2V/KYfSLfsO04xmto95symSJZx2QoIRmKMTPFsHPqLPCTQ=="

            };

            var personnelUser = new ApplicationUser
            {
                Id = "cca1e8b1-3509-4632-952f-b083a54c080d",
                UserName = "personnel",
                NormalizedUserName = "PERSONNEL",
                Email = "personnel@app.com",
                NormalizedEmail = "PERSONNEL@APP.COM",
                EmailConfirmed = true,
                SecurityStamp = "cca1e8b1-3509-4632-952f-b083a54c0801",
                ConcurrencyStamp = "cca1e8b1-3509-4632-952f-b083a54c0802",
                AccessFailedCount = 0,
                LockoutEnabled = false,
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                Iban = "",
                NameSurname= "",
                PasswordHash = "AQAAAAIAAYagAAAAEGlUgzflaKX6S3BD7Hn2Pa+YdfDD3OD67fTew6C2P/NMlt8H40uKOw2BdaVUNfikWg=="



            };


            builder.HasData(adminUser, personnelUser);
        }
    }
}
