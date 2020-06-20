namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET NAME ='Pay as You Go'  WHERE Id = 1 ");
            Sql("UPDATE MembershipTypes SET NAME ='Monthly'  WHERE Id = 2 ");
            Sql("UPDATE MembershipTypes SET NAME ='Quarterly'  WHERE Id = 3 ");
            Sql("UPDATE MembershipTypes SET NAME ='Yearly'  WHERE Id = 4 ");

        }
        
        public override void Down()
        {
        }
    }
}
