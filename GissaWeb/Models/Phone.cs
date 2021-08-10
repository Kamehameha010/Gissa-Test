using System;
using System.Collections.Generic;

#nullable disable

namespace GissaWeb.Models
{
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public int PhoneNumber { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
