using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASP_Foody_Ordering.Models
{
    [Table("HOADON")]
    public partial class Hoadon
    {
        public Hoadon()
        {
            Cthoadons = new HashSet<Cthoadon>();
        }

        [Key]
        [Column("MaHD")]
        public int MaHd { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Ngày tạo")]
        public DateTime? Ngay { get; set; }
        [Display(Name = "Tổng tiền")]
        public int TongTien { get; set; }
        [Column("MaTK")]
        public int MaTk { get; set; }
        [Display(Name = "Trạng thái")]
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(MaTk))]
        [InverseProperty(nameof(Taikhoan.Hoadons))]
        [Display(Name = "Khách hàng")]
        public virtual Taikhoan MaTkNavigation { get; set; }
        [InverseProperty(nameof(Cthoadon.MaHdNavigation))]
        public virtual ICollection<Cthoadon> Cthoadons { get; set; }
    }
}
