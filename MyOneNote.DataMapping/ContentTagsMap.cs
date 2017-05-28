using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class ContentTagsMap
    {
        public ContentTagsMap(EntityTypeBuilder<ContentTags> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasOne(x => x.Tag).WithMany(x => x.ContentTags).HasForeignKey(x => x.TagId);
        }
    }
}