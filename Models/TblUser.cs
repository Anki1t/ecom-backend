using System;
using System.Collections.Generic;

namespace Majorproject.Models
{
    public partial class TblUser
    {
        public int Uid { get; set; }
        public string? Uname { get; set; }
        public string? Pwd { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public string? ItemPurchased { get; set; }
    }
}
