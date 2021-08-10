using System;
using System.Collections.Generic;

#nullable disable

namespace GissaWeb.Models
{
    public partial class User
    {
        public User()
        {
            TestUserSkills = new HashSet<UserSkill>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public int CardId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int TypeId { get; set; }
        public int Rol { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserSkill> TestUserSkills { get; set; }
    }
}
