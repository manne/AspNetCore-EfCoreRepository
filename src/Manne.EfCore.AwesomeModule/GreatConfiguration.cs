using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manne.EfCore.AwesomeModule
{
    public class GreatConfiguration : IEntityTypeConfiguration<Great>
    {
        public void Configure(EntityTypeBuilder<Great> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .HasMaxLength(50);
        }
    }
}
