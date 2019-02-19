namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToFixMovieIssueStep4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenre_Id" });
            DropPrimaryKey("dbo.MovieGenres");
            AlterColumn("dbo.MovieGenres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.MovieGenres", "Id");
            DropColumn("dbo.Movies", "MovieGenreId");
            DropColumn("dbo.Movies", "MovieGenre_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MovieGenre_Id", c => c.Int());
            AddColumn("dbo.Movies", "MovieGenreId", c => c.Byte(nullable: false));
            DropPrimaryKey("dbo.MovieGenres");
            AlterColumn("dbo.MovieGenres", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MovieGenres", "Id");
            CreateIndex("dbo.Movies", "MovieGenre_Id");
            AddForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres", "Id");
        }
    }
}
