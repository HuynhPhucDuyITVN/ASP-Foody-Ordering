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
        public int? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public int? ThanhTien { get; set; }

        [ForeignKey(nameof(MaHd))]
        [InverseProperty(nameof(Hoadon.Cthoadons))]
        public virtual Hoadon MaHdNavigation { get; set; }
        [ForeignKey(nameof(MaMa))]
        [InverseProperty(nameof(Monan.Cthoadons))]
        public virtual Monan MaMaNavigation { get; set; }
    }
}
