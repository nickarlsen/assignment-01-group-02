namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items) 
    {

        foreach (IEnumerable<T> i in items) 
        {
            foreach (T v in i) 
            {
                yield return v;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) 
    {
        foreach (var v in items)
        {
            if (predicate(v))
            {
                yield return v;
            }
        }
    }
}