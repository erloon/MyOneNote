using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class ContentReviewsMap
    {
        public ContentReviewsMap(EntityTypeBuilder<ContentReviews> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasOne(x => x.Review).WithMany(x => x.ContentReviewses).HasForeignKey(x => x.ReviewId);
        }
    }
}