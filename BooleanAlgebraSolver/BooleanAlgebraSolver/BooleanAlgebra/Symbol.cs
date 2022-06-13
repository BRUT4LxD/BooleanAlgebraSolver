namespace BooleanAlgebraSolver.BooleanAlgebra
{
    public sealed class Symbol<T> : IEquatable<Symbol<T>> where T : IEquatable<T>
    {
        public T Value { get; }

        public Symbol(T value)
        {
            Value = value;
        }

        public static bool operator ==(Symbol<T> other, Symbol<T> other2) => other.Equals(other2);

        public static bool operator !=(Symbol<T> other, Symbol<T> other2) => !other.Equals(other2);

        public override bool Equals(object? obj) => ReferenceEquals(this, obj) || obj is Symbol<T> && this == obj;

        public override int GetHashCode() => Value.GetHashCode();

        public bool Equals(Symbol<T>? other) => Value.Equals(other.Value);

        public override string ToString() => Value.ToString();
    }
}
