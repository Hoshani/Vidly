namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateBirthDateValue : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers Set BirthDate = '1990-01-01' WHERE NAME LIKE '%JOHN%'");
        }
        
        public override void Down()
        {
        }
    }
}
