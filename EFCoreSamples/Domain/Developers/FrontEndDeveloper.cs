using EFCoreSamples.Domain.Enums;
using EFCoreSamples.Domain.ValueObjects;
using FluentValidation;

namespace EFCoreSamples.Domain.Developers
{
    public class FrontEndDeveloper : Developer
    {
        public FrontEndDeveloper(DevCode id, string name, DevType devType, bool mobileStack, string mobileSystem) : base()
        {
            Id = id;
            Name = name;
            DevType = devType;
            MobileStack = mobileStack;
            MobileSystem = mobileSystem;
        }

        public bool MobileStack { get; protected set; }
        public string MobileSystem { get; protected set; }
        public override bool IsValid()
        {
            Validator.RuleFor(e => e.DevType).Must(e => e == DevType.FrontEnd).WithMessage("Must be a FrontEnd Developer");
            return base.IsValid();
        }
    }
}
