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
    public class ClaimMap : EntityTypeConfiguration<Claim>
    {
        public ClaimMap()
        {
            ToTable("CLAIM");

            HasKey(e => e.ClaimId);

            Property(e => e.ClaimId)
                        .HasColumnName("CLAIM_ID")
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.ClaimLevelId)
                        .HasColumnName("CLAIM_LEVEL_ID")
                        .IsRequired();

            Property(e => e.ClaimSkillId)
                        .HasColumnName("CLAIM_SKILL_ID")
                        .IsRequired();

            HasRequired(e => e.Skill)
                        .WithMany(e => e.Claims)
                        .HasForeignKey(e => e.ClaimSkillId)
                        .WillCascadeOnDelete(false);

            HasRequired(e => e.Level)
                        .WithMany(e => e.Claims)
                        .HasForeignKey(e => e.ClaimLevelId)
                        .WillCascadeOnDelete(false);
        }
    }
}
