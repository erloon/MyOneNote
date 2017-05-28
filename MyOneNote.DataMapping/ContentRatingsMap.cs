using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class ContentRatingsMap
    {
        public ContentRatingsMap(EntityTypeBuilder<ContentRatings> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasOne(x => x.Rating).WithMany(x => x.ConentRatings).HasForeignKey(x => x.RatingId);
        }
    }
}