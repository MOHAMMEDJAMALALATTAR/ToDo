using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ToDoList.Data.Models
{
    public partial class tododbContext : DbContext
    {
        public tododbContext()
        {
        }

        public tododbContext(DbContextOptions<tododbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseMySQL("Server=localhost;port=3306;user=root;password=1475963;database=tododb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.ToTable("todo");

                entity.HasIndex(e => e.CreaterId, "Creater_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IsSigned, "Signed_UserId_idx");

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreaterId).HasColumnType("int unsigned");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IsRead).HasColumnType("tinyint");

                entity.Property(e => e.IsSigned).HasColumnType("int unsigned");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");
                entity.Property(e => e.CreatedDate)
                      .HasColumnType("timestamp")
                     .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpatedDate)
                       .HasColumnType("timestamp")
                      .ValueGeneratedOnAddOrUpdate()
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Creater)
                    .WithOne(p => p.TodoCreater)
                    .HasForeignKey<Todo>(d => d.CreaterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CreaterId_UserId");

                entity.HasOne(d => d.IsSignedNavigation)
                    .WithMany(p => p.TodoIsSignedNavigations)
                    .HasForeignKey(d => d.IsSigned)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IsSigned_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("  ConfirmPassword");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IsAdmin)
                    .HasColumnType("tinyint")
                    .HasColumnName(" IsAdmin");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
