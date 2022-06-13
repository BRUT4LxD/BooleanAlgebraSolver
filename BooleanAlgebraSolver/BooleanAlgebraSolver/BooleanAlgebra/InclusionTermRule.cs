namespace BooleanAlgebraSolver.BooleanAlgebra
{
    public class InclusionTermRule : ITermRule
    {
        public bool TrySimplify<T>(Term<T> term1, Term<T> term2, out Term<T>? simplified) where T : IEquatable<T>
        {
            if (!term1.Symbols.Except(term2.Symbols).Any())
            {
                simplified = term1;
                return true;
            }

            simplified = null;
            return false;
        }
    }
}
