using EFCoreSamples.Domain.Entity;
using FluentValidation;

namespace EFCoreSamples.Domain
{
    public class Skill : Identity<Skill, long>
    {
        public Skill(string title, long taskToDoId)
        {
            Title = title;
            TaskToDoId = taskToDoId;
        }

        protected Skill() { }
        public string Title { get; protected set; }
        public long TaskToDoId { get; protected set; }
        public override bool IsValid()
        {
            Validator.RuleFor(e => e.Title).NotEmpty();
            return Validator.Validate(this).IsValid;
        }
    }
}
