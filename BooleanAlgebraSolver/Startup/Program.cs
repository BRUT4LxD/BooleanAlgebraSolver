using BooleanAlgebraSolver;
using BooleanAlgebraSolver.Graph;

Graph<string> g = Graph<string>.CreateCharGraphFromInput();
Console.WriteLine(g.ToString());

var d = new Djikstra<string>(g, "a", "f");
Console.WriteLine(d.Solve());

Console.WriteLine(BFS.Solve(g, "a", "f"));
Console.WriteLine(DFS.Solve(g, "a", "f"));
