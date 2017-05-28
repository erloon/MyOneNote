using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class LinkMap
    {
        public LinkMap(EntityTypeBuilder<Link> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.Content).IsRequired();
            entityTypeBuilder.Property(x => x.ShortDescription).HasMaxLength(250);
            entityTypeBuilder.Property(x => x.Url).HasMaxLength(200);
            entityTypeBuilder.HasOne(x => x.Category).WithMany(x => x.Links).HasForeignKey(x => x.CategoryId);
            entityTypeBuilder.HasOne(x => x.Project).WithMany(x => x.Links).HasForeignKey(x => x.ProjectId);
            entityTypeBuilder.HasOne(x => x.UserProfile).WithMany(x => x.Links).HasForeignKey(x => x.CreateBy);
        }
    }
}