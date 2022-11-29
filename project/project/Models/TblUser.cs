using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public partial class TblUser
    {
        
        public string? Username { get; set; } = null!;
        public int? Pass { get; set; }
    }
}
