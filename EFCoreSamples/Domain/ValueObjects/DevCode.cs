
using System;

namespace EFCoreSamples.Domain.ValueObjects
{
    public class DevCode : ValueObject<DevCode>, IComparable<DevCode>
    {
        public string Code { get; private set; }

        public DevCode(string code)
        {
            Code = code;
        }

        public static implicit operator DevCode(string code) => new DevCode(code);
        public static implicit operator string(DevCode code) => code.Code;
        public override bool Equals(object obj)
        {
            var compareTo = obj as DevCode;
            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Code.Equals(compareTo.Code);
        }
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Code.GetHashCode();
        }
        public override string ToString() => $"{GetType().Name} [Id={Code}]";

        public int CompareTo(DevCode other)
        {
            if (Equals(other)) return 0;

            return Code.CompareTo(other.Code);
        }        
    }
}
