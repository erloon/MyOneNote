using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class NoteMap
    {
        public NoteMap(EntityTypeBuilder<Note> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.Content).IsRequired();
            entityTypeBuilder.Property(x => x.ShortDescription).HasMaxLength(250);
            entityTypeBuilder.Property(x => x.Title).HasMaxLength(250);

            entityTypeBuilder.HasOne(x => x.Category).WithMany(x => x.Notes).HasForeignKey(x => x.CategoryId);
            entityTypeBuilder.HasOne(x => x.Project).WithMany(x => x.Notes).HasForeignKey(x => x.ProjectId);
            entityTypeBuilder.HasOne(x => x.UserProfile).WithMany(x => x.Notes).HasForeignKey(x => x.CreateBy);
        }
    }
}