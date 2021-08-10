using System;
using System.Collections.Generic;

#nullable disable

namespace GissaWeb.Models
{
    public partial class TestUserSkill
    {
        public int UserSkillId { get; set; }
        public int UserId { get; set; }
        public int SofSkillId { get; set; }

        public virtual TestSoftSkill SofSkill { get; set; }
        public virtual TestUser User { get; set; }
    }
}
