using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASP_Foody_Ordering.Models
{
    [Table("TAIKHOAN")]
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Diachis = new HashSet<Diachi>();
            Hoadons = new HashSet<Hoadon>();
        }

        [Key]
        [Column("MaTK")]
        public int MaTk { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(20)]
        public string DienThoai { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }
        public int QuyenHan { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(Diachi.MaTkNavigation))]
        public virtual ICollection<Diachi> Diachis { get; set; }
        [InverseProperty(nameof(Hoadon.MaTkNavigation))]
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
