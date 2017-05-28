using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class CategoryMap
    {
        public CategoryMap(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.Name).HasMaxLength(200);
            entityBuilder.HasOne(x => x.UserProfile).WithMany(x => x.Categories).HasForeignKey(x => x.CreateBy);
        }
    }
}