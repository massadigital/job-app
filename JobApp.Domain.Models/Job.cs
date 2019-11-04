using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class Job : Tracked
    {
        public Job()
        {
            JobHasClaims = new HashSet<JobHasClaim>();
            Calls = new HashSet<Call>();
        }
        public long JobId { get; set; }
        public string JobTitle { get; set; }
        public virtual ICollection<JobHasClaim> JobHasClaims { get; set; }
        public virtual ICollection<Call> Calls { get; set; }
    }
}
