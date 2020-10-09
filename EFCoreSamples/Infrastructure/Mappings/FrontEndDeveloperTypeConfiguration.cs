using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreSamples.Domain.Developers;

namespace EFCoreSamples.Infrastructure.Mappings
{
    public class FrontEndDeveloperTypeConfiguration : IEntityTypeConfiguration<FrontEndDeveloper>
    {
        public void Configure(EntityTypeBuilder<FrontEndDeveloper> builder)
        {
            builder.ToTable(nameof(FrontEndDeveloper));
        }
    }
}
