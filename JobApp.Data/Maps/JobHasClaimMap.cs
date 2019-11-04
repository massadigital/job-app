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
    public class JobHasClaimMap : EntityTypeConfiguration<JobHasClaim>
    {
        public JobHasClaimMap()
        {
            ToTable("JOB_HAS_CLAIM");

            HasKey(e => new { e.JobClaimId, e.ClaimJobId });


            Property(e => e.JobClaimId)
                        .HasColumnName("JOB_CLAIM_ID")
                        .IsRequired();

            Property(e => e.ClaimJobId)
                        .HasColumnName("CLAIM_JOB_ID")
                        .IsRequired();


            HasRequired(e => e.Claim)
                        .WithMany(e => e.JobHasClaims)
                        .HasForeignKey(e => e.JobClaimId)
                        .WillCascadeOnDelete(false);

            HasRequired(e => e.Job)
                        .WithMany(e => e.JobHasClaims)
                        .HasForeignKey(e => e.ClaimJobId)
                        .WillCascadeOnDelete(false);

        }
    }
}
