namespace BooleanAlgebraSolver
{
    public sealed class BooleanAlgebraSimplifier<T> where T : IEquatable<T>
    {
        private List<Parenthesis<T>> Parenthesis { get; }

        public BooleanAlgebraSimplifier(IEnumerable<Parenthesis<T>> parenthesis)
        {
            Parenthesis = new HashSet<Parenthesis<T>>(parenthesis).ToList();
        }

        public void Solve()
        {
            if (Parenthesis.Count == 0) return;
            while (Parenthesis.Count > 1)
            {
                foreach (var parenthesis in Parenthesis)
                {
                    parenthesis.ProcessRules();
                }

                MultiplyFirstTwo();
            }

            Parenthesis.First().ProcessRules();
        }

        public void Print()
        {
            Console.WriteLine(string.Join("", Parenthesis.Select(e => e.ToString())));
        }

        private void MultiplyFirstTwo()
        {
            if (Parenthesis.Count < 2)
            {
                return;
            }

            var res = Parenthesis<T>.Multiply(Parenthesis[0], Parenthesis[1]);

            Parenthesis.RemoveAt(0);
            Parenthesis[0] = res;
        }
    }
}