using System;
using System.Collections.Generic;

#nullable disable

namespace GissaWeb.Models
{
    public partial class UserView
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int CardId { get; set; }
        public string Username { get; set; }
        public int Rol { get; set; }
        public int TypeId { get; set; }
        public int PhoneId { get; set; }
        public int PhoneNumber { get; set; }
        public int SoftSkillId { get; set; }
        public string Name { get; set; }
    }
}
