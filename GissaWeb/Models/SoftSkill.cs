using System;
using System.Collections.Generic;

#nullable disable

namespace GissaWeb.Models
{
    public partial class SoftSkill
    {
        public SoftSkill()
        {
            TestUserSkills = new HashSet<UserSkill>();
        }

        public int SoftSkillId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserSkill> TestUserSkills { get; set; }
    }
}
