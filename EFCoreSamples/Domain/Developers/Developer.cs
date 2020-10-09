using EFCoreSamples.Domain.Entity;
using EFCoreSamples.Domain.Enums;
using EFCoreSamples.Domain.ValueObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EFCoreSamples.Domain.Developers
{
    public abstract class Developer : Identity<Developer, DevCode>
    {
        public Developer(DevCode id, string name, DevType devType)
        {
            Id = id;
            Name = name;
            DevType = devType;
            _tasksToDo = new Collection<TaskToDo>();
        }

        public string Name { get; protected set; }
        public DevType DevType { get; protected set; }
        private ICollection<TaskToDo> _tasksToDo { get; set; }
        public virtual IReadOnlyCollection<TaskToDo> TasksToDo { get { return _tasksToDo as Collection<TaskToDo>; } }
        public Motivation Motivation { get; protected set; }

        protected Developer()
        {
            _tasksToDo = new Collection<TaskToDo>();
        }

        public void AddItemToDo(TaskToDo todo)
        {
            var _todo = new TaskToDo(todo.Title, todo.Start, todo.DeadLine, todo.Status, todo.DeveloperId);
            todo.Skills.ToList().ForEach(e => _todo.SetSkill(e));
            _tasksToDo.Add(_todo);
        }

        public void SetMotivation(Motivation motivation)
        {
            var _motivation = new Motivation(motivation.Factor, Id);
            Motivation = _motivation;
        }

        public abstract void HowIAm();
    }
}
