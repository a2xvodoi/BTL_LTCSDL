namespace layout.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class anTuongFsDB : DbContext
    {
        public anTuongFsDB()
            : base("name=anTuongFsDB")
        {
        }

        public virtual DbSet<CTDonHang> CTDonHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TaiKhoanAd> TaiKhoanAds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.Hangs)
                .WithRequired(e => e.DanhMuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.CTDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hang>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hang>()
                .Property(e => e.KichCo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hang>()
                .HasMany(e => e.CTDonHangs)
                .WithRequired(e => e.Hang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tenDangNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);
            modelBuilder.Entity<TaiKhoanAd>()
                .Property(e => e.tenDangNhapAd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanAd>()
                .Property(e => e.MatKhauAd)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
