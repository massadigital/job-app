using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class Claim : Tracked
    {
        public long ClaimId { get; set; }
        public long ClaimSkillId { get; set; }
        public LevelCode ClaimLevelId { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual Level Level { get; set; }
        public ICollection<JobHasClaim> JobHasClaims { get; set; }
        public ICollection<PersonHasClaim> PersonHasClaims { get; set; }
    }
}
