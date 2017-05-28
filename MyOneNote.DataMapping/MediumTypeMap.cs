using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class MediumTypeMap
    {
        public MediumTypeMap(EntityTypeBuilder<MediumType> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.Name).HasMaxLength(200);
            entityTypeBuilder.HasOne(x => x.UserProfile)
                .WithMany(x => x.MediumTypes)
                .HasForeignKey(x => x.CreateBy);
        }
    }
}