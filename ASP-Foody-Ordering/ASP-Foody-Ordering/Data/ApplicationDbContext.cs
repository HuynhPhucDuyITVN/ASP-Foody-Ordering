using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ASP_Foody_Ordering.Models;

#nullable disable

namespace ASP_Foody_Ordering.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Cthoadon> Cthoadons { get; set; }
        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Diachi> Diachis { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Monan> Monans { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-173GO3D\\SQLEXPRESS;Initial Catalog=FoodyDiDi; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Cthoadon>(entity =>
            {
                entity.HasKey(e => e.MaCthd)
                    .HasName("PK__CTHOADON__1E4FA771483DF748");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.Cthoadons)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHOADON__MaHD__21B6055D");

                entity.HasOne(d => d.MaMaNavigation)
                    .WithMany(p => p.Cthoadons)
                    .HasForeignKey(d => d.MaMa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHOADON__MaMA__22AA2996");
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DANHMUC__2725866E6EFCC20B");

                entity.Property(e => e.HinhAnh).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Diachi>(entity =>
            {
                entity.HasKey(e => e.MaDc)
                    .HasName("PK__DIACHI__2725866450FF208F");

                entity.Property(e => e.PhuongXa).IsUnicode(false);

                entity.Property(e => e.QuanHuyen).IsUnicode(false);

                entity.Property(e => e.TinhThanh).IsUnicode(false);

                entity.HasOne(d => d.MaTkNavigation)
                    .WithMany(p => p.Diachis)
                    .HasForeignKey(d => d.MaTk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIACHI__MaTK__1A14E395");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HOADON__2725A6E053AA25DE");

                entity.Property(e => e.Ngay).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaTkNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MaTk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HOADON__MaTK__1DE57479");
            });

            modelBuilder.Entity<Monan>(entity =>
            {
                entity.HasKey(e => e.MaMa)
                    .HasName("PK__MONAN__2725DFC011826767");

                entity.Property(e => e.HinhAnh).IsUnicode(false);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.Monans)
                    .HasForeignKey(d => d.MaDm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MONAN__MaDM__1367E606");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.MaTk)
                    .HasName("PK__TAIKHOAN__27250070C0C9C434");

                entity.Property(e => e.DienThoai).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
