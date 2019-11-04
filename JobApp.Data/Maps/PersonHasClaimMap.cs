using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using JobApp.Domain.Models;

namespace JobApp.Data.Maps
{
    public class PersonHasClaimMap : EntityTypeConfiguration<PersonHasClaim>
    {
        public PersonHasClaimMap()
        {
            ToTable("PERSON_HAS_CLAIM");

            HasKey(e => new { e.PersonClaimId, e.ClaimPersonId, e.PersonHasClaimSince }) ;


            Property(e => e.PersonClaimId)
                        .HasColumnName("PERSON_CLAIM_ID")
                        .IsRequired();


            Property(e => e.ClaimPersonId)
                        .HasColumnName("CLAIM_PERSON_ID")
                        .IsRequired();

            Property(e => e.PersonHasClaimSince)
                        .HasColumnName("PERSON_HAS_CLAIM_SINCE")
                        .IsRequired();

            HasRequired(e => e.Claim)
                        .WithMany(e => e.PersonHasClaims)
                        .HasForeignKey(e => e.PersonClaimId)
                        .WillCascadeOnDelete(false);
        }
    }
}
