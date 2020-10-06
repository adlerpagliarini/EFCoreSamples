using EFCoreSamples.Domain.Entity;
using FluentValidation;
using System.Collections.ObjectModel;

namespace EFCoreSamples.Domain
{
    public class TaskToDoSkill : Identity<TaskToDoSkill, long>
    {
        public TaskToDoSkill(TaskToDo taskToDo, Skill skill)
        {
            TaskToDo = taskToDo;
            Skill = skill;
        }
        protected TaskToDoSkill()
        {

        }

        public long SkillId { get; protected set; }
        public long TaskToDoId { get; protected set; }
        public virtual Skill Skill { get; protected set; }
        public virtual TaskToDo TaskToDo { get; protected set; }
    }
}
