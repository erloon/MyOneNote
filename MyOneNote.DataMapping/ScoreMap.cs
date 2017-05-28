using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOneNote.Data.Entity;

namespace MyOneNote.EntityMap
{
    public class ScoreMap
    {
        public ScoreMap(EntityTypeBuilder<Score> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.Rate).HasMaxLength(10).IsRequired();
        }
    }
}