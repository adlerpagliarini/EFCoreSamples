using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreSamples.Domain;

namespace EFCoreSamples.Infrastructure.Mappings
{
    public class TaskToDoSkillTypeConfiguration : IEntityTypeConfiguration<TaskToDoSkill>
    {
        public void Configure(EntityTypeBuilder<TaskToDoSkill> builder)
        {
            builder.Ignore(e => e.Id);
            builder.HasKey(e => new { e.SkillsId, e.TasksToDoId });
            builder.ToTable("SkillTaskToDo");
        }
    }
}
