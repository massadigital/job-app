using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class Tracked
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool Deleted { get; set; }
    }
}
