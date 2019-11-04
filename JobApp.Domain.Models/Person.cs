using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Domain.Models
{
    public class Person : Tracked
    {
        public Person()
        {
            Applies = new HashSet<Apply>();
            PersonHasClaims = new HashSet<PersonHasClaim>();
        }
        public long PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
        public virtual ICollection<PersonHasClaim> PersonHasClaims { get; set; }
        public virtual ICollection<Apply> Applies { get; set; }
    }
}
