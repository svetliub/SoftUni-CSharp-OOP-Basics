using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            SetMatrix();

            var moves = Console.ReadLine().ToCharArray();
            int[] samPosition = new int[2];
            int[] getEnemy = new int[2];
            GetSamsPosition(samPosition);

            for (int step = 0; step < moves.Length; step++)
            {
                EnemyMove();
                GetEnemyPosition(samPosition, getEnemy);

                if (IsEnemyKillSam(samPosition, getEnemy))
                {
                    return;
                }

                room[samPosition[0]][samPosition[1]] = '.';
                SamMove(moves, step, samPosition);

                room[samPosition[0]][samPosition[1]] = 'S';
                GetEnemyPosition(samPosition, getEnemy);

                if (NikoladzeDied(getEnemy, samPosition))
                {
                    return;
                }
            }
        }

        private static void SetMatrix()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }

        private static bool IsEnemyKillSam(int[] samPosition, int[] getEnemy)
        {
            if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
            {
                SamDied(samPosition);
                return true;
            }
            else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
            {
                SamDied(samPosition);
                return true;
            }
            return false;
        }

        private static bool NikoladzeDied(int[] getEnemy, int[] samPosition)
        {
            if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
            {
                room[getEnemy[0]][getEnemy[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");
                PrintMatrix();
                return true;
            }
            return false;
        }

        private static void GetEnemyPosition(int[] samPosition, int[] getEnemy)
        {
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
        }

        private static void SamDied(int[] samPosition)
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            PrintMatrix();
        }

        private static void GetSamsPosition(int[] samPosition)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void SamMove(char[] moves, int step, int[] samPosition)
        {
            switch (moves[step])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
        }

        private static void EnemyMove()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }
    }
}
