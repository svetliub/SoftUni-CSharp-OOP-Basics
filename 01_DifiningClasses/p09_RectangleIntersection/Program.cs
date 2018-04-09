using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int n = input[0];
        int m = input[1];

        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < n; i++)
        {
            string[] commandLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string id = commandLine[0];
            double width = double.Parse(commandLine[1]);
            double height = double.Parse(commandLine[2]);
            double horisontal = double.Parse(commandLine[3]);
            double vertical = double.Parse(commandLine[4]);

            Rectangle rectangle = new Rectangle(id, width, height, horisontal, vertical);
            rectangles.Add(rectangle);
        }

        for (int i = 0; i < m; i++)
        {
            string[] intersection = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Rectangle firstRectangle = rectangles.First(r => r.Id == intersection[0]);
            Rectangle secondRectangle = rectangles.First(r => r.Id == intersection[1]);

            Console.WriteLine(firstRectangle.AreRectanglesIntersected(secondRectangle));
        }
    }
}

