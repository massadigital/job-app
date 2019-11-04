using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class PersonHasClaim
    {
        public long PersonClaimId { get; set; }
        public long ClaimPersonId { get; set; }
        public DateTime PersonHasClaimSince { get; set; }
        public virtual Person Person { get; set; }
        public virtual Claim Claim { get; set; }
    }
}
