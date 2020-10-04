namespace EFCoreSamples.Domain.Entity
{
    public abstract class Identity<TEntity, TId>
        where TEntity : Identity<TEntity, TId>
    {
        protected Identity()
        {
            Validator = new IdentityValidator<TEntity, TId>();
        }
        public TId Id { get; protected set; }
        protected IdentityValidator<TEntity, TId> Validator { get; private set; }
        public virtual bool IsValid() => true;
        public override bool Equals(object obj)
        {
            var compareTo = obj as Identity<TEntity, TId>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Identity<TEntity, TId> a, Identity<TEntity, TId> b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Identity<TEntity, TId> a, Identity<TEntity, TId> b) => !(a == b);

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString() => $"{GetType().Name} [Id={Id}]";
    }
}
