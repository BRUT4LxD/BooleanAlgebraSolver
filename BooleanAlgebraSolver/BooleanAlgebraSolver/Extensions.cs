namespace BooleanAlgebraSolver
{
    internal static class Extensions
    {
        public static HashSet<T> AddRange<T>(this HashSet<T> hash, IEnumerable<T> elements)
        {
            var h = new HashSet<T>(hash);
            foreach (var item in elements)
            {
                h.Add(item);
            }

            return h;
        }

        public static void Swap<T>(this T[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
