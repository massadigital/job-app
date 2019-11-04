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
    public class LevelMap : EntityTypeConfiguration<Level>
    {
        public LevelMap()
        {
            ToTable("LEVEL");

            HasKey(e => e.LevelId);

            Property(e => e.LevelId)
                        .HasColumnName("LEVEL_ID")
                        .IsRequired()
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(e => e.LevelName)
                        .HasColumnName("LEVEL_NAME")
                        .IsRequired()
                        .HasMaxLength(256);
        }
    }
}
