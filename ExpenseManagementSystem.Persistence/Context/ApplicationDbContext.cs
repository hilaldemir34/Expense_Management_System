using ExpenseManagementSystem.Domain.BaseEntity;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Entities.Identity;
using ExpenseManagementSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExpenseManagementSystem.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseRequest> ExpenseRequests { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ExpenseDocument> ExpenseDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Expense>()
                .HasQueryFilter(f => f.DeletedAtUtc == null);
            modelBuilder.Entity<ExpenseCategory>()
                .HasQueryFilter(f => f.DeletedAtUtc == null);
            modelBuilder.Entity<ExpenseDocument>()
                .HasQueryFilter(f => f.DeletedAtUtc == null);
            modelBuilder.Entity<ExpenseRequest>()
                .HasQueryFilter(f => f.DeletedAtUtc == null);
            modelBuilder.Entity<Payment>()
                .HasQueryFilter(f => f.DeletedAtUtc == null);
            modelBuilder.Entity<ApplicationUser>()
                .HasQueryFilter(f => f.DeletedAtUtc == null);
            modelBuilder.Entity<ApplicationRole>()
                .HasQueryFilter(f => f.DeletedAtUtc == null);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.SenderUser)
                .WithMany(u => u.SentPayments)
                .HasForeignKey(p => p.SenderUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.ReceiverUser)
                .WithMany(u => u.ReceivedPayments)
                .HasForeignKey(p => p.ReceiverUserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

        }
    }
}
