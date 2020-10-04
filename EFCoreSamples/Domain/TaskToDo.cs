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
            Skills = new Collection<Skill>();
        }

        protected TaskToDo() { }

        public string Title { get; protected set; }
        public DateTime Start { get; protected set; }
        public DateTime DeadLine { get; protected set; }
        public bool Status { get; protected set; }
        public DevCode DeveloperId { get; protected set; }

        public virtual Collection<Skill> Skills { get; protected set; }

        public void SetSkill(Skill skill)
        {
            if (skill is null) return;
            var _skill = new Skill(skill.Title, Id);
            Skills.Add(_skill);
        }
    }
}
