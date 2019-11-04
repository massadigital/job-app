using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Models
{
    public class ClaimApp
    {
        public long Id { get; set; }
        public LevelCodeApp LevelId { get; set; }
        public long SkillId { get; set; }
        public LevelApp Level { get; set; }
        public SkillApp Skill { get; set; }
    }
}
