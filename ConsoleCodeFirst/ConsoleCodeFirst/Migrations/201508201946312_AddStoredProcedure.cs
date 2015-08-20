namespace ConsoleCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class AddStoredProcedure : DbMigration
    {
        public override void Up()
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Custom.sql");
            Sql(File.ReadAllText(sqlFile));
        }

        public override void Down()
        {
        }
    }
}
