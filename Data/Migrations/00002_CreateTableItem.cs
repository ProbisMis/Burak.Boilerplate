using FluentMigrator;
using Burak.Boilerplate.Data.EntityModels;

namespace Burak.Boilerplate.Data.Migrations
{
    [Migration(2)]
    public partial class _00002_CreateTableItem: Migration
    {
        public override void Up()
        {
            Create.Table(nameof(Item))
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString().Nullable()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("AndroidGameId").AsString().Nullable()
                .WithColumn("AppleGameId").AsString().Nullable()
                .WithColumn("IsConsumable").AsBoolean().WithDefaultValue(0)
                .WithColumn("IsUpgradable").AsBoolean().WithDefaultValue(0)
                .WithColumn("IsActive").AsBoolean().WithDefaultValue(1)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(0)
                .WithColumn("PictureUrl1").AsString().Nullable()
                .WithColumn("PictureUrl2").AsString().Nullable()
                .WithColumn("PictureUrl3").AsString().Nullable()
                .WithColumn("CreatedOnUtc").AsDateTime2().Nullable()
                .WithColumn("UpdatedOnUtc").AsDateTime2().Nullable();
          

            Create.Table(nameof(UserItem))
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("UserId").AsInt32().ForeignKey(nameof(User), "Id")
               .WithColumn("ItemId").AsInt32().ForeignKey(nameof(Item), "Id")
               .WithColumn("IsEquipped").AsBoolean().WithDefaultValue(0)
               .WithColumn("IsConsumed").AsBoolean().WithDefaultValue(0)
               .WithColumn("ItemLevel").AsInt32().WithDefaultValue(0)
               .WithColumn("Quantity").AsInt32().WithDefaultValue(0);

            //Seed 
            Insert.IntoTable(nameof(Item)).Row(new 
            {
                Name = "Home 1",
                Description ="Test Data 1" ,
                Title = "Test Title 1"
            });
            Insert.IntoTable(nameof(Item)).Row(new
            {
                Name = "Home 2",
                Description = "Test Data 2",
                Title = "Test Title 2"
            });

        }

        public override void Down()
        {
            Delete.Table(nameof(Item));
            Delete.Table(nameof(UserItem));
        }
    }
}
