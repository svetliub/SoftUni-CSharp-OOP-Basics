using System;
using System.Collections.Generic;
using System.Text;

public class AddRemoveCollection<T> : IAddable<T>, IRemovable<T>
{
    List<T> data = new List<T>();

    public int Add(T element)
    {
        List<T> newList = new List<T>();
        newList.Add(element);
        for (int i = 0; i < this.data.Count; i++)
        {
            newList.Add(this.data[i]);
        }

        this.data = newList;
        return 0;
    }

    public T Remove()
    {
        int lastIndex = this.data.Count - 1;
        T element = this.data[lastIndex];
        this.data.RemoveAt(lastIndex);

        return element;
    }
}