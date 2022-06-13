namespace BooleanAlgebraSolver.Graph
{
    public record Node<T>(T From, T To, int Value) where T : IEquatable<T>;
}
