namespace layout.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            CTDonHangs = new HashSet<CTDonHang>();
        }

        [Key]
        [DisplayName("Mã đơn hàng")]
        public int MaDH { get; set; }
        [DisplayName("Ngày đặt hàng")]
        public DateTime NgayDatHang { get; set; }

        [Required]
        [DisplayName("Người nhận")]
        [StringLength(40)]
        public string NguoiNhan { get; set; }
        [DisplayName("Địa chỉ nhận")]
        [StringLength(100)]
        public string DiaChiNhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }
    }
}
