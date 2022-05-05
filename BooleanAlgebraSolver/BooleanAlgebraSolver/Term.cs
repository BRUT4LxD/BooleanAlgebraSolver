namespace BooleanAlgebraSolver
{
    public sealed class Term<T> : IEquatable<Term<T>> where T : IEquatable<T>
    {
        public HashSet<Symbol<T>> Symbols { get; }

        public Term(IEnumerable<Symbol<T>> symbols)
        {
            Symbols = new HashSet<Symbol<T>>(symbols);
        }

        public static bool operator ==(Term<T> other, Term<T> other2) => other.Equals(other2);

        public static bool operator !=(Term<T> other, Term<T> other2) => !other.Equals(other2);

        public override bool Equals(object? obj) => ReferenceEquals(this, obj) || obj is Term<T> && this == obj;

        public override int GetHashCode() => Symbols.Select(e => e.GetHashCode()).Aggregate((a, b) => a ^ b);

        public bool Equals(Term<T>? other)
            => Symbols.Count == other.Symbols.Count &&
            Symbols.All(e => other.Symbols.Any(o => o.Equals(e)));

        public override string ToString()
        {
            return string.Join("", Symbols.Select(e => e.ToString()));
        }

    }
}