namespace BooleanAlgebraSolver
{
    public sealed class BooleanAlgebraSimplifier<T> where T : IEquatable<T>
    {
        private List<Parenthesis<T>> Parenthesis { get; }

        public BooleanAlgebraSimplifier(IEnumerable<Parenthesis<T>> parenthesis)
        {
            Parenthesis = new HashSet<Parenthesis<T>>(parenthesis).ToList();
        }

        public void Solve(bool printSteps = false)
        {
            if (Parenthesis.Count == 0) return;
            while (Parenthesis.Count > 1)
            {
                foreach (var parenthesis in Parenthesis)
                {
                    parenthesis.ProcessRules();
                }

                if (printSteps)
                {
                    Print();
                }

                Multiply();
            }

            if (printSteps)
            {
                Print();
            }

            Parenthesis.First().ProcessRules();
        }

        public void Print()
        {
            Console.WriteLine(string.Join("", Parenthesis.Select(e => e.ToString())));
        }

        private void Multiply()
        {
            if (Parenthesis.Count < 2)
            {
                return;
            }

            int c = 0;

            while (c + 1 < Parenthesis.Count)
            {
                var res = Parenthesis<T>.Multiply(Parenthesis[c], Parenthesis[c + 1]);

                Parenthesis.RemoveAt(c + 1);
                Parenthesis[c] = res;
                c++;
            }

        }
    }
}