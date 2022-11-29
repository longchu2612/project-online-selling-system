using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public partial class TblKhachHang
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "String is not empty")]
        public string MaKh { get; set; } = null!;
        [Required(AllowEmptyStrings = false, ErrorMessage = "String is not empty")]
        public string? TenKh { get; set; }
        public bool? Gt { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "String is not empty")]
        public string? Diachi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "String is not empty")]
        public DateTime? NgaySinh { get; set; }
    }
}
