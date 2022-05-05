namespace BooleanAlgebraSolver
{
    public class SameTermRule : ITermRule
    {
        public bool TrySimplify<T>(Term<T> term1, Term<T> term2, out Term<T>? simplified) where T : IEquatable<T>
        {
            if (term1.Equals(term2))
            {
                simplified = term1;
                return true;
            }
            simplified = null;
            return false;
        }
    }
}