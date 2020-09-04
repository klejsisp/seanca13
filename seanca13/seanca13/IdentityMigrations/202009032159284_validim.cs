namespace seanca13.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validim : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "emri", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "emri", c => c.String());
        }
    }
}
