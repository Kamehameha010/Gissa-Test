using System;
using System.Collections.Generic;

#nullable disable

namespace GissaWeb.Models
{
    public partial class TestPhone
    {
        public int PhoneId { get; set; }
        public int PhoneNumber { get; set; }
        public int UserId { get; set; }

        public virtual TestUser User { get; set; }
    }
}
