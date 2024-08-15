using FluentMigrator;

namespace News.Migrations
{
    [Migration(202408151230)]
    public class _202408151230_CreateNewsTable : Migration
    {
        public override void Up()
        {
            // ایجاد جدول Categories
            Create.Table("Categories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable();

            // ایجاد جدول News
            Create.Table("News")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255).NotNullable()
                .WithColumn("Content").AsString().NotNullable()
                .WithColumn("Image").AsString(255).Nullable()
                .WithColumn("Views").AsInt32().NotNullable()
                .WithColumn("CategoryId").AsInt32().NotNullable();

            // اضافه کردن کلید خارجی
            Create.ForeignKey("FK_News_Category")
                .FromTable("News").ForeignColumn("CategoryId")
                .ToTable("Categories").PrimaryColumn("Id");
        }

        public override void Down()
        {
            // حذف کلید خارجی
          

            // حذف جدول News
            if (Schema.Table("News").Exists())
            {
                Delete.Table("News");
            }

            // حذف جدول Categories
            if (Schema.Table("Categories").Exists())
            {
                Delete.Table("Categories");
            }
        }
    }
}
