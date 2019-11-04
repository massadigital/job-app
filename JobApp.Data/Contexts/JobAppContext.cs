using JobApp.Common.Helpers;
using JobApp.Data.Maps;
using JobApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Data.Contexts
{
    public abstract class JobAppContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<Apply> Applies { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<PersonHasClaim> PersonHasClaims { get; set; }
        public virtual DbSet<JobHasClaim> JobHasClaims { get; set; }

        public JobAppContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        public JobAppContext()
            : base()
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new CallMap());
            modelBuilder.Configurations.Add(new ClaimMap());
            modelBuilder.Configurations.Add(new ApplyMap());
            modelBuilder.Configurations.Add(new SkillMap());
            modelBuilder.Configurations.Add(new LevelMap());
            modelBuilder.Configurations.Add(new PersonHasClaimMap());
            modelBuilder.Configurations.Add(new JobHasClaimMap());

            modelBuilder.Types<Tracked>().Configure(e => e.Property(x => x.CreatedAt).HasColumnName("CREATED_AT").IsRequired());
            modelBuilder.Types<Tracked>().Configure(e => e.Property(x => x.ModifiedAt).HasColumnName("MODIFIED_AT").IsRequired());
            modelBuilder.Types<Tracked>().Configure(e => e.Property(x => x.DeletedAt).HasColumnName("DELETED_AT").IsRequired());
            modelBuilder.Types<Tracked>().Configure(e => e.Property(x => x.Deleted).HasColumnName("WAS_DELETED").IsRequired());
        }

        protected void UpdateTracks()
        {
            var changes = from item in ChangeTracker.Entries()
                          where item.State != EntityState.Unchanged
                          && typeof(Tracked).IsInstanceOfType(item.Entity)
                          select item;

            foreach (var change in changes)
            {
                var itemChanged = (Tracked)change.Entity;
                if (change.State == EntityState.Added)
                {
                    itemChanged.CreatedAt = DateTime.Now;
                    itemChanged.ModifiedAt = DateTime.Now;
                    itemChanged.DeletedAt = new DateTime(1900, 1, 1);
                    itemChanged.Deleted = false;
                }
                else if (change.State == EntityState.Modified)
                {
                    var currentEntity = change.GetDatabaseValues();
                    itemChanged.CreatedAt = (DateTime)currentEntity["CreatedAt"];
                    itemChanged.ModifiedAt = DateTime.Now;
                    itemChanged.DeletedAt = new DateTime(1900, 1, 1);
                    itemChanged.Deleted = false;
                }
                else if (change.State == EntityState.Deleted)
                {
                    if (itemChanged.Deleted)
                    {
                        continue;
                    }
                    Entry(change.Entity).State = EntityState.Modified;
                    var currentEntity = change.GetDatabaseValues();
                    itemChanged.CreatedAt = (DateTime)currentEntity["CreatedAt"];
                    itemChanged.ModifiedAt = (DateTime)currentEntity["ModifiedAt"];
                    itemChanged.DeletedAt = DateTime.Now;
                    itemChanged.Deleted = true;
                }
            }
        }
        public override Task<int> SaveChangesAsync()
        {
            UpdateTracks();
            return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            UpdateTracks();
            return base.SaveChanges();
        }

    }
}
