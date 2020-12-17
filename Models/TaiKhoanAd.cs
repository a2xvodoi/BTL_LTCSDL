namespace layout.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoanAd")]
    public partial class TaiKhoanAd
    {
        [Key]
        [DisplayName("Mã ")]
        public int MaAd { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Tên đăng nhập")]
        public string tenDangNhapAd { get; set; }

        [Required]
        [DisplayName("Mật khẩu")]
        [StringLength(20)]
        public string MatKhauAd { get; set; }

        
    }
}
