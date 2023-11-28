using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASP_Foody_Ordering.Models
{
    [Table("DIACHI")]
    public partial class Diachi
    {
        [Key]
        [Column("MaDC")]
        public int MaDc { get; set; }
        [Column("MaTK")]
        public int MaTk { get; set; }
        [Required]
        [Column("DiaChi")]
        [StringLength(100)]
        public string DiaChi1 { get; set; }
        [StringLength(20)]
        public string PhuongXa { get; set; }
        [StringLength(50)]
        public string QuanHuyen { get; set; }
        [StringLength(50)]
        public string TinhThanh { get; set; }

        [ForeignKey(nameof(MaTk))]
        [InverseProperty(nameof(Taikhoan.Diachis))]
        public virtual Taikhoan MaTkNavigation { get; set; }
    }
}
