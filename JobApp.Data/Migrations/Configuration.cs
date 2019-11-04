namespace JobApp.Data.Migrations
{
    using JobApp.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JobApp.Data.Contexts.JobAppMsSqlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JobApp.Data.Contexts.JobAppMsSqlContext context)
        {

            var levels = new Level[] {
                new Level(){ LevelId = LevelCode.Rookie, LevelName="Rookie" },
                new Level(){ LevelId = LevelCode.Junior, LevelName="Junior" },
                new Level(){ LevelId = LevelCode.Full, LevelName="Pleno" },
                new Level(){ LevelId = LevelCode.Senior, LevelName="Sênior" },
                new Level(){ LevelId = LevelCode.Architect, LevelName="Arquiteto" },
            };
            context.Levels.AddOrUpdate(levels);

        }
    }
}
