using EFCoreSamples.Domain.Entity;
using EFCoreSamples.Domain.Enums;
using EFCoreSamples.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EFCoreSamples.Domain
{
    public class Developer : Identity<Developer, DevCode>
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

        protected Developer()
        {
            _tasksToDo = new Collection<TaskToDo>();
        }

        public void AddItemToDo(TaskToDo todo)
        {
            var _todo = new TaskToDo(todo.Title, todo.Start, todo.DeadLine, todo.Status, todo.DeveloperId);
            _tasksToDo.Add(_todo);
        }
    }
}
