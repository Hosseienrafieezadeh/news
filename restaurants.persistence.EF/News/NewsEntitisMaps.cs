using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using News.Entitis.Categorys;
using News.Entitis.News;

public class NewsEntitisMaps : IEntityTypeConfiguration<Newss>
{
    public void Configure(EntityTypeBuilder<Newss> builder)
    {
        builder.ToTable("News");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Content)
            .IsRequired();

        builder.Property(e => e.Image)
            .HasMaxLength(255);

        // تنظیمات مربوط به CategoryId
        builder.Property(e => e.CategoryId)
            .IsRequired();

        // تنظیم رابطه بین News و Category
        builder.HasOne<Category>()
            .WithMany(c => c.Newsses) // باید مجموعه‌ای از Newsها را مشخص کنید
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // یا DeleteBehavior.Cascade، بسته به نیاز
    }
}
