namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMovieGenreAndMoreColumnsInMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "MovieGenre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "MovieGenre_Id");
            AddForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenre_Id" });
            DropColumn("dbo.Movies", "MovieGenre_Id");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "NumberInStock");
            DropTable("dbo.MovieGenres");
        }
    }
}
