using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class Call : Tracked
    {
        public Call()
        {
            Applies = new HashSet<Apply>();
        }
        public long CallId { get; set; }
        public string CallTitle { get; set; }
        public long CallJobId { get; set; }
        public DateTime CallAt { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<Apply> Applies { get; set; }
    }
}
