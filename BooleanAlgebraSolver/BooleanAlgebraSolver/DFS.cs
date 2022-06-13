using BooleanAlgebraSolver.Graph;

namespace BooleanAlgebraSolver
{
    public class DFS
    {
        public static int Solve<T>(Graph<T> graph, T startingNode, T endingNode) where T: IEquatable<T>
        {
            var v = new HashSet<T>();
            return Solve(graph, startingNode, endingNode, 0, v);
        }

        private static int Solve<T>(Graph<T> graph, T current, T endingNode, int steps, HashSet<T> visited) where T : IEquatable<T>
        {
            if (current.Equals(endingNode)) return steps;
            if (!graph.Connections.ContainsKey(current) || visited.Contains(current)) return -1;

            visited.Add(current);

            foreach (var item in graph.Connections[current])
            {
                var r = Solve(graph, item.To, endingNode, steps + 1, visited);
                if (r != -1) return r;

            }
            return -1;
        }
    }
}
