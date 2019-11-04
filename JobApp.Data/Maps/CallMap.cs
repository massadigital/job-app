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
    public class CallMap : EntityTypeConfiguration<Call>
    {
        public CallMap()
        {
            ToTable("CALL");

            HasKey(e => e.CallId);

            Property(e => e.CallId)
                        .HasColumnName("CALL_ID")
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.CallTitle)
                        .HasColumnName("CALL_TITLE")
                        .IsRequired()
                        .HasMaxLength(256);

            Property(e => e.CallJobId)
                        .HasColumnName("CALL_JOB_ID")
                        .IsRequired();

            Property(e => e.CallAt)
                        .HasColumnName("CALL_AT")
                        .IsRequired();

            HasRequired(e => e.Job)
                        .WithMany(e => e.Calls)
                        .HasForeignKey(e => e.CallJobId)
                        .WillCascadeOnDelete(false);
        }
    }
}
