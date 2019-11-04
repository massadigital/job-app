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
    public class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            ToTable("JOB");

            HasKey(e => e.JobId);

            Property(e => e.JobId)
                        .HasColumnName("JOB_ID")
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.JobTitle)
                        .HasColumnName("JOB_TITLE")
                        .IsRequired()
                        .HasMaxLength(256);
        }
    }
}
