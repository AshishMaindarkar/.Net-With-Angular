namespace ClientSearchWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client_Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.client_ClientId)
                .Index(t => t.client_ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Dob = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client_Details", "client_ClientId", "dbo.Clients");
            DropIndex("dbo.Client_Details", new[] { "client_ClientId" });
            DropTable("dbo.Clients");
            DropTable("dbo.Client_Details");
        }
    }
}
