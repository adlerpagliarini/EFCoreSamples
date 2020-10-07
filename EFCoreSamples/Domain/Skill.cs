using EFCoreSamples.Domain.Entity;
using FluentValidation;
using System.Collections.ObjectModel;

namespace EFCoreSamples.Domain
{
    public class Skill : Identity<Skill, long>
    {
        public Skill(string title)
        {
            Title = title;
        }

        protected Skill() { }

        public string Title { get; protected set; }

        public virtual Collection<TaskToDo> TasksToDo { get; protected set; }

        public override bool IsValid()
        {
            Validator.RuleFor(e => e.Title).NotEmpty();
            return Validator.Validate(this).IsValid;
        }
    }
}
