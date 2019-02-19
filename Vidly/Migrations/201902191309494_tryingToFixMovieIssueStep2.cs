namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToFixMovieIssueStep2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieGenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "MovieGenre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "MovieGenre_Id");
            AddForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenre_Id" });
            DropColumn("dbo.Movies", "MovieGenre_Id");
            DropColumn("dbo.Movies", "MovieGenreId");
        }
    }
}
