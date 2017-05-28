using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class RatingMap
    {
        public RatingMap(EntityTypeBuilder<Rating> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasOne(x => x.UserProfile).WithMany(x => x.Ratings).HasForeignKey(x => x.CreateBy);
            entityTypeBuilder.HasOne(x => x.Score).WithMany(x => x.Ratings).HasForeignKey(x => x.ScoreId);
        }
    }
}