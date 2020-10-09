using EFCoreSamples.Domain.Enums;
using EFCoreSamples.Domain.ValueObjects;
using FluentValidation;
using System;

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

        public ExtraMotivation ExtraMotivation { get; protected set; }

        public void SetMotivation(ExtraMotivation extraMotivation)
        {
            ExtraMotivation = extraMotivation;
        }

        public override void HowIAm()
        {
            Console.WriteLine($"I'm a {nameof(FullStackDeveloper)} and I've preference for {CloudPreference} provider.");
        }

        public override bool IsValid()
        {
            Validator.RuleFor(e => e.DevType).Must(e => e == DevType.Fullstack).WithMessage("Must be a FullStack Developer");
            return base.IsValid();
        }
    }
}
