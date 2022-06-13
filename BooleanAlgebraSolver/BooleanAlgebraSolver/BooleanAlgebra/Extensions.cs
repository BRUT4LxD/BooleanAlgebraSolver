namespace BooleanAlgebraSolver.BooleanAlgebra
{
    internal static class Extensions
    {
        public static HashSet<T> AddRange<T>(this HashSet<T> hash, IEnumerable<T> elements)
        {
            foreach (var item in elements)
            {
                hash.Add(item);
            }

            return hash;
        }

        public static void Swap<T>(this T[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
