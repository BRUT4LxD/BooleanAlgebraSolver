using System.Text;

namespace BooleanAlgebraSolver.Graph
{
    public class Graph<T> where T : IEquatable<T>
    {
        public IDictionary<T, List<Node<T>>> Connections { get; private set; } = new Dictionary<T, List<Node<T>>>();

        public Graph(IDictionary<T, List<Node<T>>> connections)
        {
            Connections = connections;
        }

        public Graph(IEnumerable<Node<T>> connections, bool includeEmptyConnections= false)
        {
            foreach (var node in connections)
            {
                if (!Connections.ContainsKey(node.From))
                {
                    Connections.Add(node.From, new());
                }

                Connections[node.From].Add(node);
            }

            if (!includeEmptyConnections) return;

            var h = new HashSet<T>(connections.Where(e => !Connections.ContainsKey(e.To)).Select(e => e.To));

            foreach (var item in h)
            {
                Connections.Add(item, new List<Node<T>>());
            }
        }

        public static Graph<string> CreateCharGraphFromInput()
        {
            var nodes = new List<Node<string>>();

            while (true)
            {
                var line = Console.ReadLine()?.Split(' ');
                if (line == null || line.Length == 1) break;

                nodes.Add(new Node<string>(line[0], line[2], int.Parse(line[1])));
            }

            return new Graph<string>(nodes);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var lines = Connections.Select(e => $"Key {e.Key.ToString()}: {string.Join(",", e.Value.Select(y => y.To.ToString()))}");

            foreach (var line in lines) sb.AppendLine(line);

            return sb.ToString();
        }
    }
}
