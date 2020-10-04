using EFCoreSamples.Domain.Enums;
using EFCoreSamples.Domain.ValueObjects;
using FluentValidation;

namespace EFCoreSamples.Domain.Developers
{
    public class FullStackDeveloper : Developer
    {
        public FullStackDeveloper(DevCode id, string name, DevType devType, string cloudPreference) : base()
        {
            Id = id;
            Name = name;
            DevType = devType;
            CloudPreference = cloudPreference;
        }

        public string CloudPreference { get; protected set; }

        public override bool IsValid()
        {
            Validator.RuleFor(e => e.DevType).Must(e => e == DevType.Fullstack).WithMessage("Must be a FullStack Developer");
            return base.IsValid();
        }
    }
}
