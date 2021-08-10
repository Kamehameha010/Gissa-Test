using System;
using System.Collections.Generic;

#nullable disable

namespace GissaWeb.Models
{
    public partial class UserSkill
    {
        public int UserSkillId { get; set; }
        public int UserId { get; set; }
        public int SofSkillId { get; set; }

        public virtual SoftSkill SofSkill { get; set; }
        public virtual User User { get; set; }
    }
}
