namespace TODOList.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseTaskId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseTasks", t => t.BaseTaskId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.BaseTaskId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.BaseTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        PersonId = c.Int(),
                        Status = c.Int(nullable: false),
                        Module = c.String(),
                        Version = c.String(),
                        BugType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        To = c.String(),
                        Subject = c.String(),
                        IsSent = c.Boolean(nullable: false),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaseTasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.People", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.BaseTasks", "PersonId", "dbo.People");
            DropForeignKey("dbo.Assigns", "PersonId", "dbo.People");
            DropForeignKey("dbo.Assigns", "BaseTaskId", "dbo.BaseTasks");
            DropIndex("dbo.People", new[] { "RoleId" });
            DropIndex("dbo.BaseTasks", new[] { "PersonId" });
            DropIndex("dbo.BaseTasks", new[] { "ProjectId" });
            DropIndex("dbo.Assigns", new[] { "PersonId" });
            DropIndex("dbo.Assigns", new[] { "BaseTaskId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Projects");
            DropTable("dbo.Roles");
            DropTable("dbo.People");
            DropTable("dbo.BaseTasks");
            DropTable("dbo.Assigns");
        }
    }
}
