using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASP_Foody_Ordering.Models
{
    [Table("DANHMUC")]
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Monans = new HashSet<Monan>();
        }

        [Key]
        [Column("MaDM")]
        public int MaDm { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(255)]
        public string HinhAnh { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(Monan.MaDmNavigation))]
        public virtual ICollection<Monan> Monans { get; set; }
    }
}
