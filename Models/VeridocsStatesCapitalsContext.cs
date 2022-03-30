using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuizMachine.Models
{
    public partial class VeridocsStatesCapitalsContext : IdentityDbContext
    {
        public VeridocsStatesCapitalsContext()
        {
        }

        public VeridocsStatesCapitalsContext(DbContextOptions<VeridocsStatesCapitalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<TestResult> TestResults { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-RHKU1LJ0;Database=VeridocsStatesCapitals;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("aaaaaState_PK")
                    .IsClustered(false);

                entity.ToTable("State");

                entity.Property(e => e.Capital).HasMaxLength(255);

                entity.Property(e => e.State1)
                    .HasMaxLength(255)
                    .HasColumnName("State");
            });

            modelBuilder.Entity<TestResult>(entity =>
            {
                entity.HasKey(e => e.TestResultId)
                    .HasName("aaaaaTestResult_PK")
                    .IsClustered(false);

                entity.ToTable("TestResult");

                entity.HasIndex(e => e.NumberCorrect, "NumberCorrect");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.TestDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("aaaaaUser_PK")
                    .IsClustered(false);

                entity.ToTable("User");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
