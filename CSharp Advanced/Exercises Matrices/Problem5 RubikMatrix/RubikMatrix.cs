using System;
using System.Linq;

namespace Problem5_RubikMatrix
{
    class RubikMatrix
    {
        private static void Main(string[] args)
        {
            var inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var r = inputArgs[0];
            var c = inputArgs[1];

            var commandCount = int.Parse(Console.ReadLine());
            int[][] matrix = new int[r][];

            int num = 1;

            for (int i = 0; i < r; i++)
            {
                matrix[i] = new int[c];
                for (int j = 0; j < c; j++)
                {
                    matrix[i][j] = num;
                    num++;
                }
            }

            for (int l = 0; l < commandCount; l++)
            {
                var commandArgs = Console.ReadLine().Split();
                var rowCol = int.Parse(commandArgs[0]);
                var direction = commandArgs[1];
                var moves = int.Parse(commandArgs[2]);

                if (direction == "down" || direction == "up")
                {
                    moves = moves % matrix.Length;
                    MoveColumnValues(rowCol, direction, moves, matrix);
                }
                else if (direction == "left" || direction == "right")
                {
                    moves = moves % matrix[0].Length;
                    MoveRowValues(rowCol, direction, moves, matrix);
                }

                //PrintMatrix(matrix);//Testing
            }

            RearrangeMatrix(matrix);
            //PrintMatrix(matrix);//Testing
        }

        private static void RearrangeMatrix(int[][] matrix)
        {
            var correctValue = 1;
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    if (matrix[r][c] != correctValue)
                    {
                        SwapValues(r, c, correctValue, matrix);
                        //Console.WriteLine();//Testing
                        //PrintMatrix(matrix);//Testing
                        //Console.WriteLine();//Testing
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    correctValue++;
                }
            }
        }

        private static void SwapValues(int r, int c, int correctValue, int[][] matrix)
        {
            var swapRowIndex = 0;
            var swapColIndex = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == correctValue)
                    {
                        swapRowIndex = row;
                        swapColIndex = col;
                        break;
                    }
                }
            }

            var swapValue = matrix[r][c];
            matrix[r][c] = matrix[swapRowIndex][swapColIndex];
            matrix[swapRowIndex][swapColIndex] = swapValue;
            Console.WriteLine($"Swap ({r}, {c}) with ({swapRowIndex}, {swapColIndex})");
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }

        private static void MoveRowValues(int rowCol, string direction, int moves, int[][] matrix)
        {
            if (moves == matrix[rowCol].Length || moves == 0)
            {
                return;
            }

            if (direction == "left")
            {
                for (int i = 0; i < moves; i++)
                {
                    var tempValue = matrix[rowCol][0];
                    for (int j = 0; j < matrix[rowCol].Length; j++)
                    {
                        if (j == matrix[rowCol].Length - 1)
                        {
                            matrix[rowCol][j] = tempValue;
                        }
                        else
                        {
                            matrix[rowCol][j] = matrix[rowCol][j + 1];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < moves; i++)
                {
                    var tempValue = matrix[rowCol][matrix[rowCol].Length - 1];
                    for (int j = matrix[rowCol].Length - 1; j >= 0; j--)
                    {
                        if (j == 0)
                        {
                            matrix[rowCol][j] = tempValue;
                        }
                        else
                        {
                            matrix[rowCol][j] = matrix[rowCol][j - 1];
                        }
                    }
                }
            }
        }

        private static void MoveColumnValues(int rowCol, string direction, int moves, int[][] matrix)
        {
            if (moves == matrix.Length || moves == 0)
            {
                return;
            }

            if (direction == "up")
            {
                for (int i = 0; i < moves; i++)
                {
                    var tempValue = matrix[0][rowCol];
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        if (j == matrix.Length - 1)
                        {
                            matrix[j][rowCol] = tempValue;
                        }
                        else
                        {
                            matrix[j][rowCol] = matrix[j + 1][rowCol];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < moves; i++)
                {
                    var tempValue = matrix[matrix.Length - 1][rowCol];
                    for (int j = matrix.Length - 1; j >= 0; j--)
                    {
                        if (j == 0)
                        {
                            matrix[j][rowCol] = tempValue;
                        }
                        else
                        {
                            matrix[j][rowCol] = matrix[j - 1][rowCol];
                        }
                    }
                }
            }
        }
    }
}