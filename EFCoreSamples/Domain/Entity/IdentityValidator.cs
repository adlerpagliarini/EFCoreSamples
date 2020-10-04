using FluentValidation;

namespace EFCoreSamples.Domain.Entity
{
    public class IdentityValidator<TEntity, TId> : AbstractValidator<TEntity>
        where TEntity : Identity<TEntity, TId>
    {

    }
}
