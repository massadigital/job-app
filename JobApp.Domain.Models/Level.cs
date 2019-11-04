using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class Level : Tracked
    {
        public Level()
        {
            Claims = new HashSet<Claim>();
        }
        public LevelCode LevelId { get; set; }
        public string LevelName { get; set; }
        public ICollection<Claim> Claims { get; set; }
    }
}
