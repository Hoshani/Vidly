namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToFixMovieIssue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenre_Id" });
            DropColumn("dbo.Movies", "MovieGenreId");
            DropColumn("dbo.Movies", "MovieGenre_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MovieGenre_Id", c => c.Int());
            AddColumn("dbo.Movies", "MovieGenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenre_Id");
            AddForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres", "Id");
        }
    }
}
