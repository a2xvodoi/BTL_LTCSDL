namespace layout.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hang")]
    public partial class Hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hang()
        {
            CTDonHangs = new HashSet<CTDonHang>();
        }

        [Key]
        [DisplayName("Mã hàng")]
        public int MaH { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Ảnh chụp")]
        public string AnhChup { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên hàng")]
        public string TenH { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá bán")]
        [DisplayFormat(DataFormatString ="{0: #,###,###}")]
        public decimal GiaBan { get; set; }

        [Required]
        [DisplayName("Kích cỡ")]
        [StringLength(30)]
        public string KichCo { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Màu sắc")]
        public string MauSac { get; set; }
        [DisplayName("Số lượng bán")]
        public int? SLBan { get; set; }
        [DisplayName("Mã danh mục")]
        public int MaDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
