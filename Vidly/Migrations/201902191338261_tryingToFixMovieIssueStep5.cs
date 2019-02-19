namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToFixMovieIssueStep5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieGenreId", c => c.Byte(nullable: true));
            CreateIndex("dbo.Movies", "MovieGenreId");
            AddForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenreId" });
            DropColumn("dbo.Movies", "MovieGenreId");
        }
    }
}
