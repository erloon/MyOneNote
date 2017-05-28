using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class ProjectMap
    {
        public ProjectMap(EntityTypeBuilder<Project> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            entityTypeBuilder.HasOne(x => x.UserProfile).WithMany(x => x.Projects).HasForeignKey(x => x.UserProfileId);
        }
    }
}