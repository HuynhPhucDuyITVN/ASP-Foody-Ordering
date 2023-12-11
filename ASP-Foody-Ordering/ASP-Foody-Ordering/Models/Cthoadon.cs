using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASP_Foody_Ordering.Models
{
    [Table("CTHOADON")]
    public partial class Cthoadon
    {
        [Key]
        [Column("MaCTHD")]
        public int MaCthd { get; set; }
        [Column("MaHD")]
        public int MaHd { get; set; }
        [Column("MaMA")]
        public int MaMa { get; set; }
        [Display(Name = "Đơn giá")]
        public int DonGia { get; set; }
        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }
        [Display(Name = "Thành tiền")]
        public int ThanhTien { get; set; }

        [ForeignKey(nameof(MaHd))]
        [InverseProperty(nameof(Hoadon.Cthoadons))]
        [Display(Name = "Hóa đơn số")]
        public virtual Hoadon MaHdNavigation { get; set; }
        [ForeignKey(nameof(MaMa))]
        [InverseProperty(nameof(Monan.Cthoadons))]
        [Display(Name = "Món ăn")]
        public virtual Monan MaMaNavigation { get; set; }
    }
}
