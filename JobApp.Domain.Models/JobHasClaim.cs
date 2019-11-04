using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class JobHasClaim
    {
        public long JobClaimId { get; set; }
        public long ClaimJobId { get; set; }
        public virtual Job Job { get; set; }
        public virtual Claim Claim { get; set; }
    }
}
