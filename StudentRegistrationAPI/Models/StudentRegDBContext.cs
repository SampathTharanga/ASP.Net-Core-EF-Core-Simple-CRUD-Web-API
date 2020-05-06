using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentRegistrationAPI.Models
{
    public partial class StudentRegDBContext : DbContext
    {
        public StudentRegDBContext()
        {
        }

        public StudentRegDBContext(DbContextOptions<StudentRegDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TableStudent> TableStudent { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See Z for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StudentRegDB;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK_Table_Students");

                entity.ToTable("Table_Student");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.School).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
