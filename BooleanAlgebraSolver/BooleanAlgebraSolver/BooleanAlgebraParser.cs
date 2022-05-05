namespace BooleanAlgebraSolver
{
    public sealed class BooleanAlgebraParser
    {
        public static List<Parenthesis<char>> ReadCharEquation()
        {
            var results = new List<Parenthesis<char>>();
            Console.WriteLine("Write parethesis one by one without ( and ), instead + place space. ");
            Console.WriteLine("Entering empty line ends the input.");
            while (true)
            {
                var line = Console.ReadLine();

                if (line == null || string.Empty == line) return results;

                var terms = line.Split(' ').Select(e => new Term<char>(e.Select(d => new Symbol<char>(d))));

                results.Add(new Parenthesis<char>(terms));
            }
        }
    }
}