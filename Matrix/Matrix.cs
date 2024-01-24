using System;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix
    {
        readonly int matrixDim; // размерность

        // исходные матрицы и произведение
        public readonly int[,] matrixA;
        public readonly int[,] matrixB;
        public int[,] matrixAB;
        public TimeSpan Wtime {get;set;}
        static Random rnd = new Random();
        DateTime startTime;

        // Конструктор
        public Matrix(int d)
        {
            matrixDim = d;
            matrixA = new int[d, d];
            matrixB = new int[d, d];
            matrixAB = new int[d, d];

            // Создаём две матрицы и заполняем случайными числами 1..10
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    matrixA[i, j] = rnd.Next(0, 11);
                    matrixB[i, j] = rnd.Next(0, 11);
                }
            }
        }

        // ****************************************
        // * Распараллеливание операции умножения *
        // ****************************************
        public int[,] ParallelMult(int[,] matrixA, int[,] matrixB)
        {
            startTime = DateTime.Now; // Время начала расчёта

            Parallel.For(0, matrixDim, iline => {
                Parallel.For(0, matrixDim, i => MultMatrix(matrixAB, i, iline, matrixDim));
            });

            Wtime = DateTime.Now - startTime; // Прошедшее время
            return matrixAB;
        }

        // Умножение двух квадратных матриц
        private void MultMatrix(int[,] result, int i, int line, int len)
        {
            for (int j = 0; j < len; j++)
            {
                result[line, i] += matrixA[line, j] * matrixB[j, i];
            }
        }

        // Выходные данные
        public void PrintMatrix(int[,] matrix, string name)
        {
            Console.WriteLine($"{name}\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine("");
            }
        }
    }
}
