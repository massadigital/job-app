using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class Apply : Tracked
    {
        public long ApplyId { get; set; }
        public long ApplyCallId { get; set; }
        public long ApplyPersonId { get; set; }
        public DateTime ApplyAt { get; set; }
        public virtual Call Call { get; set; }
        public virtual Person Person { get; set; }
    }
}
