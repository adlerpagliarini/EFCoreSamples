using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreSamples.Domain.Developers;

namespace EFCoreSamples.Infrastructure.Mappings
{
    public class FullStackDeveloperTypeConfiguration : IEntityTypeConfiguration<FullStackDeveloper>
    {
        public void Configure(EntityTypeBuilder<FullStackDeveloper> builder)
        {
            builder.OwnsOne(e => e.ExtraMotivation).Property(e => e.ExtraFactor).HasColumnType("varchar(50)");
            builder.ToTable(nameof(FullStackDeveloper));
        }
    }
}
