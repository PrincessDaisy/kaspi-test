using FluentMigrator;

namespace DapperRepository.Migrations
{
    [Migration(202310250001)]
    public class InitialTables_202310250001 : Migration
    {
        public override void Down()
        {
            Delete.Table("News");
        }
        public override void Up()
        {
            Create.Table("News")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString(200).NotNullable()
                .WithColumn("Content").AsString(1000).NotNullable()
                .WithColumn("NewsDate").AsDateTime().NotNullable();
        }
    }
}
