namespace BooleanAlgebraSolver.BooleanAlgebra
{
    public sealed class Parenthesis<T> : IEquatable<Parenthesis<T>> where T : IEquatable<T>
    {
        private readonly IList<ITermRule> _rules = new List<ITermRule> { new InclusionTermRule() };

        public Term<T>[] Terms { get; private set; }

        public Parenthesis(IEnumerable<Term<T>> terms)
        {
            Terms = new HashSet<Term<T>>(terms).ToArray();
        }

        public static Parenthesis<T> Multiply(Parenthesis<T> p1, Parenthesis<T> p2)
        {
            var terms = new Term<T>[p1.Terms.Length * p2.Terms.Length];
            var c = 0;
            for (var i = 0; i < p1.Terms.Length; i++)
            {
                for (int j = 0; j < p2.Terms.Length; j++)
                {
                    var term = new Term<T>(p1.Terms[i].Symbols.AddRange(p2.Terms[j].Symbols));
                    terms[c++] = term;
                }
            }

            return new Parenthesis<T>(terms);
        }

        private static void RemoveTerm(Term<T>[] arr, int i, ref int length)
        {
            arr.Swap(i, length - 1);
            length--;
        }

        public void ProcessRules()
        {
            var length = Terms.Length;
            foreach (var rule in _rules)
            {
                for (int i = 0; i < length - 1; i++)
                {
                    for (int j = i + 1; j < length; j++)
                    {
                        if (rule.TrySimplify(Terms[i], Terms[j], out var simp))
                        {
                            RemoveTerm(Terms, j, ref length);
                            j--;
                            continue;
                        }
                        if (rule.TrySimplify(Terms[j], Terms[i], out simp))
                        {
                            RemoveTerm(Terms, i, ref length);
                            i--;
                            break;
                        }
                    }
                }
            }
            Terms = Terms[0..length];
        }

        public static bool operator ==(Parenthesis<T> other, Parenthesis<T> other2) => other.Equals(other2);

        public static bool operator !=(Parenthesis<T> other, Parenthesis<T> other2) => !other.Equals(other2);

        public override bool Equals(object? obj) => ReferenceEquals(this, obj) || obj is Parenthesis<T> && this == (Parenthesis<T>)obj;

        public override int GetHashCode() => Terms.Select(e => e.GetHashCode()).Aggregate((a, b) => a ^ b);

        public bool Equals(Parenthesis<T>? other)
            => Terms.Length == other.Terms.Length &&
            Terms.All(e => other.Terms.Any(o => o.Equals(e)));

        public override string ToString()
        {
            return "(" + string.Join(" + ", Terms.Select(e => e.ToString())) + ")";
        }
    }
}
