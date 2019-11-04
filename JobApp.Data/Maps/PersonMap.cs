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
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            ToTable("PERSON");

            HasKey(e => e.PersonId);

            Property(e => e.PersonId)
                        .HasColumnName("PERSON_ID")
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.PersonName)
                        .HasColumnName("PERSON_NAME")
                        .IsRequired()
                        .HasMaxLength(256);

            Property(e => e.PersonEmail)
                        .HasColumnName("PERSON_EMAIL")
                        .IsRequired()
                        .HasMaxLength(256);
        }
    }
}
