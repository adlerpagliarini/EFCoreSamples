namespace EFCoreSamples.Domain
{
    public abstract class ValueObject<TObject>
        where TObject : ValueObject<TObject>
    {
        protected ValueObject()
        {
            Validator = new ValueObjectValidator<TObject>();
        }
        protected ValueObjectValidator<TObject> Validator { get; private set; }
        public virtual bool IsValid() => true;
        public override abstract bool Equals(object obj);
        public static bool operator ==(ValueObject<TObject> a, ValueObject<TObject> b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<TObject> a, ValueObject<TObject> b) => !(a == b);
        public override abstract int GetHashCode();
    }
}
