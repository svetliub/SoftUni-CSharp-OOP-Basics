using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] inputDate1 = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
        string[] inputDate2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        DateTime firstDate = new DateTime(int.Parse(inputDate1[0]), int.Parse(inputDate1[1]), int.Parse(inputDate1[2]));
        DateTime secondDate = new DateTime(int.Parse(inputDate2[0]), int.Parse(inputDate2[1]), int.Parse(inputDate2[2]));
        DateModifier modifier = new DateModifier();

        Console.WriteLine(modifier.dayDifferenceTwoDates(firstDate, secondDate));
    }
}

