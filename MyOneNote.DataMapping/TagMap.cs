using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class TagMap
    {
        public TagMap(EntityTypeBuilder<Tag> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasOne(x => x.UserProfile).WithMany(x => x.Tags).HasForeignKey(x => x.UserProfileId);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        }
    }
}