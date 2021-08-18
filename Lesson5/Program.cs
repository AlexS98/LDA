using System;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] field = new int[4, 4];
            while (CanPlay(field))
            {
                Console.Clear();
                SetRandomNumbers(field, 4);
                DisplayMatrix(field);
                ApplyAction(field, GetDirection());
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }

        #region 2048
        static bool CanPlay(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    if (field[i, k] == 0 ||
                        AnyEqualWithFirst(
                            field[i, k],
                            GetCellValue(field, i - 1, k),
                            GetCellValue(field, i + 1, k)
                            ) ||
                        AnyEqualWithFirst(
                            field[i, k],
                            GetCellValue(field, i, k + 1),
                            GetCellValue(field, i, k - 1)
                            )
                        )
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool AnyEqualWithFirst(params int[] numbers)
        {
            for (int k = 1; k < numbers.Length; k++)
            {
                if (numbers[0] == numbers[k])
                {
                    return true;
                }
            }
            return false;
        }

        static int GetCellValue(int[,] field, int x, int y)
        {
            if (x >= 0 && x < field.GetLength(0) &&
                y >= 0 && y < field.GetLength(1))
            {
                return field[x, y];
            }

            return -1;
        }

        // w - 0, a - 1, s - 2, d - 3
        static void ApplyAction(int[,] field, int direction)
        {
            switch (direction)
            {
                case 0: // up
                    {
                        for (int i = 0; i < field.GetLength(1); i++)
                        {
                            int[] column = new int[field.GetLength(0)];
                            for (int k = 0; k < field.GetLength(0); k++)
                            {
                                column[k] = field[k, i];
                            }
                            column = CalculateNumbers(column);
                            for (int k = 0; k < field.GetLength(0); k++)
                            {
                                field[k, i] = column[k];
                            }
                        }
                        break;
                    }
                case 1: // l
                    {
                        for (int i = 0; i < field.GetLength(0); i++)
                        {
                            int[] row = new int[field.GetLength(1)];
                            for (int k = 0; k < field.GetLength(1); k++)
                            {
                                row[k] = field[i, k];
                            }
                            int[] newRow = CalculateNumbers(row);
                            for (int k = 0; k < field.GetLength(1); k++)
                            {
                                field[i, k] = newRow[k];
                            }
                        }
                        break;
                    }
                case 2: // d
                    {
                        for (int i = 0; i < field.GetLength(1); i++)
                        {
                            int[] column = new int[field.GetLength(0)];
                            for (int k = 0; k < field.GetLength(0); k++)
                            {
                                column[k] = field[field.GetLength(0) - 1 - k, i];
                            }
                            column = CalculateNumbers(column);
                            for (int k = 0; k < field.GetLength(0); k++)
                            {
                                field[field.GetLength(0) - 1 - k, i] = column[k];
                            }
                        }
                        break;
                    }
                case 3: // r
                    {
                        for (int i = 0; i < field.GetLength(0); i++)
                        {
                            int[] row = new int[field.GetLength(1)];
                            for (int k = 0; k < field.GetLength(1); k++)
                            {
                                row[k] = field[i, field.GetLength(1) - 1 - k];
                            }
                            int[] newRow = CalculateNumbers(row);
                            for (int k = 0; k < field.GetLength(1); k++)
                            {
                                field[i, field.GetLength(1) - 1 - k] = newRow[k];
                            }
                        }
                        break;
                    }
            }
        }

        // qwe : 5 : - : 1 : 0

        static void SetRandomNumbers(int[,] field, int count = 2)
        {
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                bool fieldNotUpdated = false;

                // stop if full
                foreach (var item in field)
                {
                    if (item == 0)
                    {
                        fieldNotUpdated = true;
                        break;
                    }
                }

                int x = 0;
                int y = 0;
                do
                {
                    x = r.Next(0, field.GetLength(0));
                    y = r.Next(0, field.GetLength(1));
                    if (field[x, y] == 0)
                    {
                        field[x, y] = 2;
                        fieldNotUpdated = false;
                    }
                }
                while (fieldNotUpdated);
            }
        }

        static int GetDirection()
        {
            ConsoleKey[] possibleKeys = { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };

            do
            {
                Console.Write("Input direction: ");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine();

                for (int i = 0; i < possibleKeys.Length; i++)
                {
                    if (input.Key == possibleKeys[i])
                    {
                        return i;
                    }
                }

                Console.WriteLine("Wrong input.");
            }
            while (true);
        }

        static void DisplayMatrix(int[,] matrix)
        {
            string sep = new string('_', matrix.GetLength(1) * 8 + 1);

            for (int i = 0; i < matrix.GetLength(0); i++) // [0;4]
            {
                Console.WriteLine(sep);
                for (int k = 0; k < matrix.GetLength(1); k++) // [0;14]
                {
                    ToConsole($"|{matrix[i, k]}\t", GetColor(matrix[i, k]));
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(sep);
        }

        static int[] CalculateNumbers(params int[] line)
        {
            //remove empty
            for (int k = 0; k < line.Length - 1; k++)
            {
                for (int i = 1; i < line.Length; i++)
                {
                    if (line[i - 1] == 0 && line[i] != 0)
                    {
                        line[i - 1] = line[i];
                        line[i] = 0;
                    }
                }
            }
            // calculate
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == line[i + 1])
                {
                    line[i] = line[i + 1] + line[i];
                    line[i + 1] = 0;
                }
            }

            // 2 2 2 2 => 4 0 4 0 => 4 4 0 0

            //remove empty
            for (int k = 0; k < line.Length - 1; k++)
            {
                for (int i = 1; i < line.Length; i++)
                {
                    if (line[i - 1] == 0 && line[i] != 0)
                    {
                        line[i - 1] = line[i];
                        line[i] = 0;
                    }
                }
            }
            return line;
        }



        static void ToConsole(string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }

        static ConsoleColor GetColor(int n)
        {
            ConsoleColor result = ConsoleColor.White;
            switch (n)
            {
                case 2: return ConsoleColor.Green;
                case 4: return ConsoleColor.Red;
                case 8: return ConsoleColor.Yellow;
                case 16: return ConsoleColor.Cyan;
                case 32: return ConsoleColor.DarkMagenta;
                case 64: return ConsoleColor.DarkRed;
                case 128: return ConsoleColor.DarkGreen;
                case 256: return ConsoleColor.DarkBlue;
            }

            return result;
        }

        #endregion
    }
}
