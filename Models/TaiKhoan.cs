namespace layout.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [DisplayName("Mã tài khoản")]
        public int MaTK { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Tên đăng nhập")]
        public string tenDangNhap { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(40)]
        [DisplayName("Tên khách hàng")]
        public string tenKH { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Tỉnh")]
        public string Tinh { get; set; }

        [StringLength(20)]
        [DisplayName("Huyện")]
        public string Huyen { get; set; }

        [StringLength(50)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [StringLength(20)]
        [DisplayName("Trạng thái")]
        public string TrangThai { get; set; }
    }
}
