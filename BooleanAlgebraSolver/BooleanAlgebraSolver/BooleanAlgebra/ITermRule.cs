namespace BooleanAlgebraSolver.BooleanAlgebra
{
    public interface ITermRule
    {
        bool TrySimplify<T>(Term<T> term1, Term<T> term2, out Term<T>? simplified) where T : IEquatable<T>;
    }
}