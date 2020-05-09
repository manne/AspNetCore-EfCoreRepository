using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manne.EfCore.AwesomeModule
{
    public class AwesomeConfiguration : IEntityTypeConfiguration<Awesome>
    {
        public void Configure(EntityTypeBuilder<Awesome> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Bla)
                .HasMaxLength(10);

            builder.Property(e => e.Blub)
                .HasMaxLength(10);
        }
    }
}
