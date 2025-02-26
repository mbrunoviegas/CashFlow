using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infra.DataAccess;
internal class ApplicationDbContext(DbContextOptions options): DbContext(options)
{
    public required DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.ToTable("expenses");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.PaymentType).HasColumnName("payment_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);

            entity.HasIndex(entity => entity.Id);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.UserIdentifier).HasColumnName("user_identifier");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.UtcNow);
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValue(DateTime.UtcNow);
        });
    }
}
