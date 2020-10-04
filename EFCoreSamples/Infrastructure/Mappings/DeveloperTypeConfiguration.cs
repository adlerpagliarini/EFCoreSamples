using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using EFCoreSamples.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EFCoreSamples.Domain.Developers;

namespace EFCoreSamples.Infrastructure.Mappings
{
    public class DeveloperTypeConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            var codeComparer = new ValueComparer<DevCode>((c1, c2) =>
                c1 == c2,
                hash => hash == null ? 0 : hash.GetHashCode(),
                obj => new DevCode(obj.Code));

            var codeConverter = new ValueConverter<DevCode, string>(obj => obj.Code, code => new DevCode(code));

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasConversion(codeConverter)
                .Metadata.SetValueComparer(codeComparer);

            builder.Property(p => p.Name).HasColumnType("varchar(50)").IsRequired();

            // Relations
            builder.HasMany(t => t.TasksToDo).WithOne().HasForeignKey(k => k.DeveloperId);
        }
    }
}
