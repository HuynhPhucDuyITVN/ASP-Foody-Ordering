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
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [StringLength(20)]
        [Display(Name = "Phường xã")]
        public string PhuongXa { get; set; }
        [StringLength(50)]
        [Display(Name = "Quận Huyện")]
        public string QuanHuyen { get; set; }
        [StringLength(50)]
        [Display(Name = "Tỉnh thành")]
        public string TinhThanh { get; set; }

        [ForeignKey(nameof(MaTk))]
        [InverseProperty(nameof(Taikhoan.Diachis))]
        [Display(Name = "Tài khoản")]
        public virtual Taikhoan MaTkNavigation { get; set; }
    }
}
