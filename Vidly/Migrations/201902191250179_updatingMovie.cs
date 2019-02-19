namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieGenreId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieGenreId");
        }
    }
}
