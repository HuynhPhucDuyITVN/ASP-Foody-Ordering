using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASP_Foody_Ordering.Models
{
    [Table("MONAN")]
    public partial class Monan
    {
        public Monan()
        {
            Cthoadons = new HashSet<Cthoadon>();
        }

        [Key]
        [Column("MaMA")]
        public int MaMa { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        public int GiaGoc { get; set; }
        public int GiaBan { get; set; }
        [StringLength(1000)]
        public string MoTa { get; set; }
        [StringLength(255)]
        public string HinhAnh { get; set; }
        [Column("MaDM")]
        public int MaDm { get; set; }
        public int? LuotXem { get; set; }
        public int? LuotMua { get; set; }

        [ForeignKey(nameof(MaDm))]
        [InverseProperty(nameof(Danhmuc.Monans))]
        public virtual Danhmuc MaDmNavigation { get; set; }
        [InverseProperty(nameof(Cthoadon.MaMaNavigation))]
        public virtual ICollection<Cthoadon> Cthoadons { get; set; }
    }
}
