using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreSamples.Domain;

namespace EFCoreSamples.Infrastructure.Mappings
{
    public class TaskToDoTypeConfiguration : IEntityTypeConfiguration<TaskToDo>
    {
        public void Configure(EntityTypeBuilder<TaskToDo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Title).HasColumnType("varchar(50)").IsRequired();
            builder.Property(p => p.DeadLine).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.HasMany(e => e.Skills).WithMany(e => e.TasksToDo)
                .UsingEntity<TaskToDoSkill>(
                e => e.HasOne(p => p.Skill).WithMany().HasForeignKey(p => p.SkillsId),
                e => e.HasOne(p => p.TaskToDo).WithMany().HasForeignKey(p => p.TasksToDoId));
        }
    }
}
