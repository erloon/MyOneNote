using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class ReviewMap
    {
        public ReviewMap(EntityTypeBuilder<Review> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasOne(x => x.UserProfile).WithMany(x => x.Reviews).HasForeignKey(x => x.CreateBy);
        }
    }
}