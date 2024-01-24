using System;

namespace Matrix
{
    class Program
    {
        static void Main()
        {
            Console.Write("Размерность квадратной матрицы: ");
            int.TryParse(Console.ReadLine(), out int dim);
            if (dim > 0)
            {
                Matrix mat = new Matrix(dim);
                int[,] matrixResult = mat.ParallelMult(mat.matrixA, mat.matrixB);

                mat.PrintMatrix(mat.matrixA, "\nМатрица A");
                mat.PrintMatrix(mat.matrixB, "\nМатрица B");
                mat.PrintMatrix(matrixResult, "\nМатрица A * B");

                Console.WriteLine($"\nПрошло реального времени: {mat.Wtime}");
                Console.WriteLine();
                Console.WriteLine("Нажмите любую клавишу для завершения...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Размерность должна быть неотрицательным числом");
                Console.WriteLine("Нажмите любую клавишу для завершения...");
                Console.ReadKey();
            }
        }
    }
}
