namespace JobApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APPLY",
                c => new
                    {
                        APPLY_ID = c.Long(nullable: false, identity: true),
                        APPLY_CALL_ID = c.Long(nullable: false),
                        APPLY_PERSON_ID = c.Long(nullable: false),
                        APPLY_AT = c.DateTime(nullable: false),
                        CREATED_AT = c.DateTime(nullable: false),
                        MODIFIED_AT = c.DateTime(nullable: false),
                        DELETED_AT = c.DateTime(nullable: false),
                        WAS_DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.APPLY_ID)
                .ForeignKey("dbo.CALL", t => t.APPLY_CALL_ID)
                .ForeignKey("dbo.PERSON", t => t.APPLY_PERSON_ID)
                .Index(t => t.APPLY_CALL_ID)
                .Index(t => t.APPLY_PERSON_ID);
            
            CreateTable(
                "dbo.CALL",
                c => new
                    {
                        CALL_ID = c.Long(nullable: false, identity: true),
                        CALL_TITLE = c.String(nullable: false, maxLength: 256),
                        CALL_JOB_ID = c.Long(nullable: false),
                        CALL_AT = c.DateTime(nullable: false),
                        CREATED_AT = c.DateTime(nullable: false),
                        MODIFIED_AT = c.DateTime(nullable: false),
                        DELETED_AT = c.DateTime(nullable: false),
                        WAS_DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CALL_ID)
                .ForeignKey("dbo.JOB", t => t.CALL_JOB_ID)
                .Index(t => t.CALL_JOB_ID);
            
            CreateTable(
                "dbo.JOB",
                c => new
                    {
                        JOB_ID = c.Long(nullable: false, identity: true),
                        JOB_TITLE = c.String(nullable: false, maxLength: 256),
                        CREATED_AT = c.DateTime(nullable: false),
                        MODIFIED_AT = c.DateTime(nullable: false),
                        DELETED_AT = c.DateTime(nullable: false),
                        WAS_DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JOB_ID);
            
            CreateTable(
                "dbo.JOB_HAS_CLAIM",
                c => new
                    {
                        JOB_CLAIM_ID = c.Long(nullable: false),
                        CLAIM_JOB_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.JOB_CLAIM_ID, t.CLAIM_JOB_ID })
                .ForeignKey("dbo.CLAIM", t => t.JOB_CLAIM_ID)
                .ForeignKey("dbo.JOB", t => t.CLAIM_JOB_ID)
                .Index(t => t.JOB_CLAIM_ID)
                .Index(t => t.CLAIM_JOB_ID);
            
            CreateTable(
                "dbo.CLAIM",
                c => new
                    {
                        CLAIM_ID = c.Long(nullable: false, identity: true),
                        CLAIM_SKILL_ID = c.Long(nullable: false),
                        CLAIM_LEVEL_ID = c.Long(nullable: false),
                        CREATED_AT = c.DateTime(nullable: false),
                        MODIFIED_AT = c.DateTime(nullable: false),
                        DELETED_AT = c.DateTime(nullable: false),
                        WAS_DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CLAIM_ID)
                .ForeignKey("dbo.LEVEL", t => t.CLAIM_LEVEL_ID)
                .ForeignKey("dbo.SKILL", t => t.CLAIM_SKILL_ID)
                .Index(t => t.CLAIM_SKILL_ID)
                .Index(t => t.CLAIM_LEVEL_ID);
            
            CreateTable(
                "dbo.LEVEL",
                c => new
                    {
                        LEVEL_ID = c.Long(nullable: false),
                        LEVEL_NAME = c.String(nullable: false, maxLength: 256),
                        CREATED_AT = c.DateTime(nullable: false),
                        MODIFIED_AT = c.DateTime(nullable: false),
                        DELETED_AT = c.DateTime(nullable: false),
                        WAS_DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LEVEL_ID);
            
            CreateTable(
                "dbo.PERSON_HAS_CLAIM",
                c => new
                    {
                        PERSON_CLAIM_ID = c.Long(nullable: false),
                        CLAIM_PERSON_ID = c.Long(nullable: false),
                        PERSON_HAS_CLAIM_SINCE = c.DateTime(nullable: false),
                        Person_PersonId = c.Long(),
                    })
                .PrimaryKey(t => new { t.PERSON_CLAIM_ID, t.CLAIM_PERSON_ID, t.PERSON_HAS_CLAIM_SINCE })
                .ForeignKey("dbo.CLAIM", t => t.PERSON_CLAIM_ID)
                .ForeignKey("dbo.PERSON", t => t.Person_PersonId)
                .Index(t => t.PERSON_CLAIM_ID)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.PERSON",
                c => new
                    {
                        PERSON_ID = c.Long(nullable: false, identity: true),
                        PERSON_NAME = c.String(nullable: false, maxLength: 256),
                        PERSON_EMAIL = c.String(nullable: false, maxLength: 256),
                        CREATED_AT = c.DateTime(nullable: false),
                        MODIFIED_AT = c.DateTime(nullable: false),
                        DELETED_AT = c.DateTime(nullable: false),
                        WAS_DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PERSON_ID);
            
            CreateTable(
                "dbo.SKILL",
                c => new
                    {
                        SKILL_ID = c.Long(nullable: false, identity: true),
                        SKILL_NAME = c.String(nullable: false, maxLength: 256),
                        CREATED_AT = c.DateTime(nullable: false),
                        MODIFIED_AT = c.DateTime(nullable: false),
                        DELETED_AT = c.DateTime(nullable: false),
                        WAS_DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SKILL_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.APPLY", "APPLY_PERSON_ID", "dbo.PERSON");
            DropForeignKey("dbo.APPLY", "APPLY_CALL_ID", "dbo.CALL");
            DropForeignKey("dbo.CALL", "CALL_JOB_ID", "dbo.JOB");
            DropForeignKey("dbo.JOB_HAS_CLAIM", "CLAIM_JOB_ID", "dbo.JOB");
            DropForeignKey("dbo.JOB_HAS_CLAIM", "JOB_CLAIM_ID", "dbo.CLAIM");
            DropForeignKey("dbo.CLAIM", "CLAIM_SKILL_ID", "dbo.SKILL");
            DropForeignKey("dbo.PERSON_HAS_CLAIM", "Person_PersonId", "dbo.PERSON");
            DropForeignKey("dbo.PERSON_HAS_CLAIM", "PERSON_CLAIM_ID", "dbo.CLAIM");
            DropForeignKey("dbo.CLAIM", "CLAIM_LEVEL_ID", "dbo.LEVEL");
            DropIndex("dbo.PERSON_HAS_CLAIM", new[] { "Person_PersonId" });
            DropIndex("dbo.PERSON_HAS_CLAIM", new[] { "PERSON_CLAIM_ID" });
            DropIndex("dbo.CLAIM", new[] { "CLAIM_LEVEL_ID" });
            DropIndex("dbo.CLAIM", new[] { "CLAIM_SKILL_ID" });
            DropIndex("dbo.JOB_HAS_CLAIM", new[] { "CLAIM_JOB_ID" });
            DropIndex("dbo.JOB_HAS_CLAIM", new[] { "JOB_CLAIM_ID" });
            DropIndex("dbo.CALL", new[] { "CALL_JOB_ID" });
            DropIndex("dbo.APPLY", new[] { "APPLY_PERSON_ID" });
            DropIndex("dbo.APPLY", new[] { "APPLY_CALL_ID" });
            DropTable("dbo.SKILL");
            DropTable("dbo.PERSON");
            DropTable("dbo.PERSON_HAS_CLAIM");
            DropTable("dbo.LEVEL");
            DropTable("dbo.CLAIM");
            DropTable("dbo.JOB_HAS_CLAIM");
            DropTable("dbo.JOB");
            DropTable("dbo.CALL");
            DropTable("dbo.APPLY");
        }
    }
}
