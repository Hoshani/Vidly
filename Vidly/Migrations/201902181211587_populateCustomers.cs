namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name,IsSubscribedToMonthlyNewsLetter,MembershipTypeId) Values ('John Smith', 1, 2)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToMonthlyNewsLetter,MembershipTypeId) Values ('John Doe', 0, 1)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToMonthlyNewsLetter,MembershipTypeId) Values ('Jane Doe', 1, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
