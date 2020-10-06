using EFCoreSamples.Domain.Entity;
using EFCoreSamples.Domain.ValueObjects;
using System;
using System.Collections.ObjectModel;

namespace EFCoreSamples.Domain
{
    public class TaskToDo : Identity<TaskToDo, long>
    {
        public TaskToDo(string title, DateTime start, DateTime deadLine, bool status, DevCode developerId)
        {
            Title = title;
            Start = start;
            DeadLine = deadLine;
            Status = status;
            DeveloperId = developerId;
            TaskToDoSkills = new Collection<TaskToDoSkill>();
        }

        protected TaskToDo() { }

        public string Title { get; protected set; }
        public DateTime Start { get; protected set; }
        public DateTime DeadLine { get; protected set; }
        public bool Status { get; protected set; }
        public DevCode DeveloperId { get; protected set; }

        public virtual Collection<TaskToDoSkill> TaskToDoSkills { get; protected set; }

        public void SetSkill(Skill skill)
        {
            if (skill is null) return;
            var taskToDo = new TaskToDoSkill(this, skill);
            TaskToDoSkills.Add(taskToDo);
        }
    }
}
