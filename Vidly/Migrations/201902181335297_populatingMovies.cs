namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatingMovies : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Movies(Name,NumberInStock,ReleaseDate,DateAdded,MovieGenre_Id) 
                VALUES 
                    ('Die Hard',5,'1988-07-20','2000-01-01',1),
                    ('Forrest Gump',6,'1994-07-06','2001-01-01',8),
                    ('Fight Club',7,'1999-10-15','2002-01-01',8),
                    ('The Dark Knight',3,'2008-07-18','2008-10-10',1)
                ");
        }

        public override void Down()
        {
        }
    }
}
