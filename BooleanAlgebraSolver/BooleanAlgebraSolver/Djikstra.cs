using BooleanAlgebraSolver.Graph;

namespace BooleanAlgebraSolver
{
    public class Djikstra<T> where T : IEquatable<T>
    {
        public Graph<T> Graph { get; init; }

        public T Start { get; init; }

        public T End { get; init; }

        private readonly List<Node<T>> _candidates = new();

        public Djikstra(Graph<T> graph, T start, T end)
        {
            Graph = graph;
            Start = start;
            End = end;
        }

        public int Solve()
        {
            var hash = new HashSet<T>(Graph.Connections.Keys);

            foreach (var node in Graph.Connections.SelectMany(e => e.Value).Select(e => e.To))
            {
                hash.Add(node);
            }

            var minTable = new int[hash.Count];

            for (int i = 0; i < minTable.Length; i++) minTable[i] = int.MaxValue;

            var mappings = hash
                .Select((node, index) => (node, index))
                .ToDictionary(e => e.node, e => e.index);

            if (!Graph.Connections.ContainsKey(Start))
            {
                Console.WriteLine("Not existing strating point");
            }
            _candidates.AddRange(Graph.Connections[Start]);

            minTable[mappings[Start]] = 0;

            int steps = 0;
            while (_candidates.Count != 0)
            {
                steps++;
                Node<T> min = _candidates.MinBy(e => e.Value)!;
                _candidates.Remove(min);

                var index = mappings[min.To];

                if (min.To.Equals(End))
                {
                    Console.WriteLine("Steps: " + steps);
                    return min.Value;
                }

                if (minTable[index] < min.Value || !Graph.Connections.ContainsKey(min.From))
                {
                    continue;
                }

                minTable[index] = min.Value;

                var cands = Graph.Connections[min.To]
                    .Select(e => new Node<T>(e.From, e.To, e.Value + min.Value))
                    .ToList();

                _candidates.AddRange(cands);
            }

            Console.WriteLine("Steps: " + steps);

            return -1;
        }
    }
}
