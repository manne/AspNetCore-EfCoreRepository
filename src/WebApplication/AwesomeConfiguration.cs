using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication
{
    public class AwesomeConfiguration : IEntityTypeConfiguration<Awesome>
    {
        public void Configure(EntityTypeBuilder<Awesome> entity)
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.Bla)
                .HasMaxLength(10);

            entity.Property(e => e.Blub)
                .HasMaxLength(10);
        }
    }
}
