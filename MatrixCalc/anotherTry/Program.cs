using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrices
{
    class Matrix
    {
        /// <summary>
        /// Поиск определителя матрицы
        /// </summary>
        /// <param name="matrix"></param>
        static public double GetDeterminant(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new Exception("Матрица должна быть квадратной!");
            /// Если матрица 2Г—2, то возвращаем определитель по формуле Крамера
            if (matrix.GetLength(0) == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            int sign = 1;//Знак минора
            double result = 0;
            int j = 0;//Номер столбца, по которому раскладывается матрица
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                /// Если номер столбца и строки одновременно чётные, то
                /// знак будет «+», иначе — «-»
                sign = ((i + 1) % 2 == (j + 1) % 2) ? 1 : -1;
                result += sign * matrix[i, j] * GetDeterminant(GetMinorMatrix(matrix, i, j));
            }
            return result;
        }
        /// <summary>
        /// Метод для вычисления минорной матрицы для заданного элемента
        /// </summary>
        /// <param name="matrix">Исходная матрица</param>
        /// <param name="row">Номер строки</param>
        /// <param name="col">Номер столбца</param>
        /// 
        private static int minorN, minorM;

        private static double[,] minor;
        static public double[,] GetMinorMatrix(double[,] matrix, int row, int col)
        {
            minorN = matrix.GetLength(0) - 1;
            minorM = matrix.GetLength(1) - 1;
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int m = 0, k;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row) continue;
                k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == col) continue;
                    result[m, k++] = matrix[i, j];
                }
                m++;
            }
            minor = result;
            return result;
        }

        public static double[,] GetMatrix(int N, int M)
        {
            double[,] a = new double[N, M];
            Console.WriteLine("Введите элементы матрицы размерности {0}на{1}", N, M);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    a[i, j] = double.Parse(Console.ReadLine());
                }
            }
            return a;
        }

        public static void ShowMinor()
        {
            if (minor != null)
            {
                Console.WriteLine("\nМинор введенной матрицы:");
                for (int i = 0; i < minorN; i++)
                {
                    for (int j = 0; j < minorM; j++)
                    {
                        Console.Write("{0} ", minor[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("Минор матрицы ещё неопределен");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            double[,] a = Matrix.GetMatrix(3, 3);
            double det = Matrix.GetDeterminant(a);
            Matrix.GetMinorMatrix(a, 1, 1);
            Console.WriteLine("\nОпределитель введенной матрицы {0}", det);
            Matrix.ShowMinor();
            Console.ReadLine();
        }
    }
}