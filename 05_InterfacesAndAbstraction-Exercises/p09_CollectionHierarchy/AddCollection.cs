using System.Collections.Generic;

public class AddCollection<T> : IAddable<T>
{
    List<T> data = new List<T>();

    public int Add(T element)
    {
        this.data.Add(element);

        return this.data.Count - 1;
    }
}
