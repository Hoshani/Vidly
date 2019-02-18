namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatingGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres(Name) Values ('Action'),('Comedy'),('Romance'),('Adventure'),('Mystery'),('Horror'),('Documentry'),('Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
