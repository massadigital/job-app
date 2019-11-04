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
    public class SkillMap : EntityTypeConfiguration<Skill>
    {
        public SkillMap()
        {
            ToTable("SKILL");

            HasKey(e => e.SkillId);

            Property(e => e.SkillId)
                        .HasColumnName("SKILL_ID")
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.SkillName)
                        .HasColumnName("SKILL_NAME")
                        .IsRequired()
                        .HasMaxLength(256);
        }
    }
}
