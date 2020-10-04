using FluentValidation;

namespace EFCoreSamples.Domain
{
    public class ValueObjectValidator<TObject>: AbstractValidator<TObject> 
        where TObject : ValueObject<TObject>
    {

    }
}
