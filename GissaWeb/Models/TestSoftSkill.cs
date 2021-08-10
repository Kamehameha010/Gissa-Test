using System;
using System.Collections.Generic;

#nullable disable

namespace GissaWeb.Models
{
    public partial class TestSoftSkill
    {
        public TestSoftSkill()
        {
            TestUserSkills = new HashSet<TestUserSkill>();
        }

        public int SoftSkillId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TestUserSkill> TestUserSkills { get; set; }
    }
}
