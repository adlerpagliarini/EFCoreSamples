using EFCoreSamples.Domain.Enums;
using EFCoreSamples.Domain.ValueObjects;
using FluentValidation;

namespace EFCoreSamples.Domain.Developers
{
    public class BackEndDeveloper : Developer
    {
        public BackEndDeveloper(DevCode id, string name, DevType devType, bool databaseStack, string databasePreference) : base()
        {
            Id = id;
            Name = name;
            DevType = devType;
            DatabaseStack = databaseStack;
            DatabasePreference = databasePreference;
        }

        public bool DatabaseStack { get; protected set; }
        public string DatabasePreference { get; protected set; }
        public override bool IsValid()
        {
            Validator.RuleFor(e => e.DevType).Must(e => e == DevType.BackEnd).WithMessage("Must be a BackEnd Developer");
            return base.IsValid();
        }
    }
}
