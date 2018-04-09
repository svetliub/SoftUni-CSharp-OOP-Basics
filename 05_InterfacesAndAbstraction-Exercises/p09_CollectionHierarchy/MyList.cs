using System;
using System.Collections.Generic;
using System.Text;

public class MyList<T> : IAddable<T>, IRemovable<T>, IMyUseble
{
    public int Used { get; set; }

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
        int firstIndex = 0;
        T element = this.data[firstIndex];
        this.data.RemoveAt(firstIndex);

        return element;
    }
}