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
        [Display(Name = "Tên tài khoản")]
        public string Ten { get; set; }
        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string DienThoai { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(255)]
        public string MatKhau { get; set; }
        [Display(Name = "Quyền hạn")]
        public int QuyenHan { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }

        [InverseProperty(nameof(Diachi.MaTkNavigation))]
        public virtual ICollection<Diachi> Diachis { get; set; }
        [InverseProperty(nameof(Hoadon.MaTkNavigation))]
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
