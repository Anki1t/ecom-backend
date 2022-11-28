using System;
using System.Collections.Generic;

namespace Majorproject.Models
{
    public partial class TblProduct
    {
        public int Pid { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; }
        public int? Rating { get; set; }
    }
}
