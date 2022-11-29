using System;
using System.Collections.Generic;

namespace project.Models
{
    public partial class TblMatHang
    {
        public string MaHang { get; set; } = null!;
        public string? TenHang { get; set; }
        public string? Dvt { get; set; }
        public float? Gia { get; set; }
    }
}
