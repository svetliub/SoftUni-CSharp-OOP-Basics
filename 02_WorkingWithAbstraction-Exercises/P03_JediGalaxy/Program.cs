using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        private static int[,] matrix;
        static void Main()
        {
            int[] dimensions = ReadInput(Console.ReadLine());
            int rows = dimensions[0];
            int columns = dimensions[1];

            SetMatrix(rows, columns);

            string command;
            long sum = 0;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                var ivosCoordinates = ReadInput(command);
                int[] evilsCoordinates = ReadInput(Console.ReadLine());
                int evilX = evilsCoordinates[0];
                int evilY = evilsCoordinates[1];

                EvilMove(evilX, evilY);

                int ivoX = ivosCoordinates[0];
                int ivoY = ivosCoordinates[1];

                sum = IvoCollectSum(ivoX, ivoY, sum);
            }

            Console.WriteLine(sum);
        }

        private static long IvoCollectSum(int ivoX, int ivoY, long sum)
        {
            while (ivoX >= 0 && ivoY < matrix.GetLength(1))
            {
                if (ivoX >= 0 && ivoX < matrix.GetLength(0) && ivoY >= 0 && ivoY < matrix.GetLength(1))
                {
                    sum += matrix[ivoX, ivoY];
                }

                ivoY++;
                ivoX--;
            }
            return sum;
        }

        private static void EvilMove(int evilX, int evilY)
        {
            while (evilX >= 0 && evilY >= 0)
            {
                if (evilX >= 0 && evilX < matrix.GetLength(0) && evilY >= 0 && evilY < matrix.GetLength(1))
                {
                    matrix[evilX, evilY] = 0;
                }
                evilX--;
                evilY--;
            }
        }

        private static void SetMatrix(int rows, int columns)
        {
            matrix = new int[rows, columns];

            int value = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        private static int[] ReadInput(string input)
        {
            int[] ivoS = input.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return ivoS;
        }
    }
}
