using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GissaWeb.Models
{
    public partial class TestGissaContext : DbContext
    {
        public TestGissaContext()
        {
        }

        public TestGissaContext(DbContextOptions<TestGissaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestPhone> TestPhones { get; set; }
        public virtual DbSet<TestSoftSkill> TestSoftSkills { get; set; }
        public virtual DbSet<TestUser> TestUsers { get; set; }
        public virtual DbSet<TestUserSkill> TestUserSkills { get; set; }
        public virtual DbSet<TestUserView> TestUserViews { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TestPhone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test_phone");

                entity.HasIndex(e => e.PhoneId, "IX_test_phone")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__test_pho__4849DA01F5527337")
                    .IsUnique();

                entity.Property(e => e.PhoneId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("phoneId");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_phone_test_user");
            });

            modelBuilder.Entity<TestSoftSkill>(entity =>
            {
                entity.HasKey(e => e.SoftSkillId);

                entity.ToTable("test_soft_skill");

                entity.Property(e => e.SoftSkillId).HasColumnName("softSkillId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TestUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("test_user");

                entity.HasIndex(e => new { e.Username, e.CardId }, "UC_TestUser")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.CardId).HasColumnName("cardId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fullName")
                    .IsFixedLength(true);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("username")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TestUserSkill>(entity =>
            {
                entity.HasKey(e => e.UserSkillId);

                entity.ToTable("test_user_skill");

                entity.Property(e => e.UserSkillId).HasColumnName("userSkillId");

                entity.Property(e => e.SofSkillId).HasColumnName("sofSkillId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.SofSkill)
                    .WithMany(p => p.TestUserSkills)
                    .HasForeignKey(d => d.SofSkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_user_skill_test_soft_skill");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TestUserSkills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_user_skill_test_user");
            });

            modelBuilder.Entity<TestUserView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("test_user_view");

                entity.Property(e => e.CardId).HasColumnName("cardId");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fullName")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneId).HasColumnName("phoneId");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.Property(e => e.SoftSkillId).HasColumnName("softSkillId");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("username")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
