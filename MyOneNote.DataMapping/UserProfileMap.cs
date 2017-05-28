using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class UserProfileMap
    {
        public UserProfileMap(EntityTypeBuilder<UserProfile> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.Organization).HasMaxLength(250);
            entityTypeBuilder.Property(x => x.Specialization).HasMaxLength(200);
        }
    }
}