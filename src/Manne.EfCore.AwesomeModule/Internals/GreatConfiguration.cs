using Manne.EfCore.AwesomeModule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manne.EfCore.AwesomeModule.Internals
{
    internal class GreatConfiguration : IEntityTypeConfiguration<Great>
    {
        public void Configure(EntityTypeBuilder<Great> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Description)
                .HasMaxLength(50);
        }
    }
}
