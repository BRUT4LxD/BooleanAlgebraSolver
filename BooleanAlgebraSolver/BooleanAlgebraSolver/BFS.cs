using BooleanAlgebraSolver.BooleanAlgebra;
using BooleanAlgebraSolver.Graph;

namespace BooleanAlgebraSolver
{
    public class BFS
    {
        public static int Solve<T>(Graph<T> graph, T startingNode, T endingNode) where T: IEquatable<T>
        {
            var steps = 0;
            var q = new Queue<T>();

            q.Enqueue(startingNode);

            var visited = new HashSet<T>();
            while(q.Count > 0)
            {
                var nodes = new List<T>(q);
                q.Clear();

                var cands = new HashSet<T>();
                foreach (var node in nodes)
                {
                    if(node.Equals(endingNode))
                    {
                        return steps;
                    }

                    cands.AddRange(graph.Connections[node].Where(e => !visited.Contains(e.To)).Select(e => e.To));
                }

                foreach (var cand in cands)
                {
                    q.Enqueue(cand);
                }
                visited.AddRange(nodes);
                steps++;
            }

            return -1;
        }
    }
}
