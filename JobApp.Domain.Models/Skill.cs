using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class Skill : Tracked
    {
        public Skill()
        {
            Claims = new HashSet<Claim>();
        }
        public long SkillId { get; set; }
        public string SkillName { get; set; }
        public ICollection<Claim> Claims { get; set; }
    }
}
