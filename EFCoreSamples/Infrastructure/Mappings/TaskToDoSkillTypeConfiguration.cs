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
            builder.HasKey(e => new { e.TaskToDoId, e.SkillId });
            builder.HasOne(e => e.TaskToDo).WithMany(e => e.TaskToDoSkills).HasForeignKey(e => e.TaskToDoId);
        }
    }
}
