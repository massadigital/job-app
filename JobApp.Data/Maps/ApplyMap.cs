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
    public class ApplyMap : EntityTypeConfiguration<Apply>
    {
        public ApplyMap()
        {
            ToTable("APPLY");

            HasKey(e => e.ApplyId);

            Property(e => e.ApplyId)
                        .HasColumnName("APPLY_ID")
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.ApplyCallId)
                        .HasColumnName("APPLY_CALL_ID")
                        .IsRequired();

            Property(e => e.ApplyPersonId)
                        .HasColumnName("APPLY_PERSON_ID")
                        .IsRequired();

            Property(e => e.ApplyAt)
                        .HasColumnName("APPLY_AT")
                        .IsRequired();

            HasRequired(e => e.Call)
                        .WithMany(e => e.Applies)
                        .HasForeignKey(e => e.ApplyCallId)
                        .WillCascadeOnDelete(false);

            HasRequired(e => e.Person)
                        .WithMany(e => e.Applies)
                        .HasForeignKey(e => e.ApplyPersonId)
                        .WillCascadeOnDelete(false);
        }
    }
}
