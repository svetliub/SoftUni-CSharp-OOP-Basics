using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        AddCollection<string> addCollection = new AddCollection<string>();
        AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
        MyList<string> myList = new MyList<string>();

        List<int> addCollectionAdds = new List<int>();
        List<int> addRemoveCollectionAdds = new List<int>();
        List<int> myListAdds = new List<int>();
        
        List<string> addRemoveCollectionRemoves = new List<string>();
        List<string> myListRemoves = new List<string>();

        var input = Console.ReadLine().Split().ToArray();

        for (int i = 0; i < input.Length; i++)
        {
            var element = input[i];
            addCollectionAdds.Add(addCollection.Add(element));
            addRemoveCollectionAdds.Add(addRemoveCollection.Add(element));
            myListAdds.Add(myList.Add(element));
        }

        var numOfRemoves = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfRemoves; i++)
        {
            addRemoveCollectionRemoves.Add(addRemoveCollection.Remove());
            myListRemoves.Add(myList.Remove());
        }

        Console.WriteLine(string.Join(" ", addCollectionAdds));
        Console.WriteLine(string.Join(" ", addRemoveCollectionAdds));
        Console.WriteLine(string.Join(" ", myListAdds));
        Console.WriteLine(string.Join(" ", addRemoveCollectionRemoves));
        Console.WriteLine(string.Join(" ", myListRemoves));
    }
}