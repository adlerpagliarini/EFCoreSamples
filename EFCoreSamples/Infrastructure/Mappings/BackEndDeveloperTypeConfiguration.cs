using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreSamples.Domain.Developers;

namespace EFCoreSamples.Infrastructure.Mappings
{
    public class BackEndDeveloperTypeConfiguration : IEntityTypeConfiguration<BackEndDeveloper>
    {
        public void Configure(EntityTypeBuilder<BackEndDeveloper> builder)
        {
            builder.ToTable(nameof(BackEndDeveloper));
        }
    }
}
