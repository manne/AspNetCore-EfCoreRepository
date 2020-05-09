using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manne.EfCore.AwesomeModule.Internals
{
    internal class AwesomeConfiguration : IEntityTypeConfiguration<Awesome>
    {
        public void Configure(EntityTypeBuilder<Awesome> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder.Property(e => e.Bla)
                .HasMaxLength(10);

            builder.Property(e => e.Blub)
                .HasMaxLength(10);
        }
    }
}
