using System;

namespace Determinant
{
    class Program
    {
        static double[,] Minor(double[,] matr, int num)
        {
            int n = matr.GetLength(0);
            int m = matr.GetLength(1);
            var minor = new double[n - 1, m - 1];

            for (var i = 0; i < n - 1; i++)
            {
                for (var j = 0; j < n - 1; j++)
                {
                    if (j >= num)
                    {
                        minor[i, j] = matr[i + 1, j + 1];
                    }
                    else
                    {
                        minor[i, j] = matr[i + 1, j];
                    }
                }
            }
            

            return minor;
        }

        static double Determinant(double[,] matr)
        {
            int n = matr.GetLength(0);
            int m = matr.GetLength(1);
            double sum = 0;

            if (n > 1)
            {
                for (var i = 0; i < n; i++)
                {
                    if ((i + 2) % 2 == 0)
                    {
                        sum += matr[0, i] * Determinant(Minor(matr, i));
                    }
                    else
                    {
                        sum += matr[0, i] * -1 * Determinant(Minor(matr, i));
                    }
                }
            }
            else
            {
                return matr[0, 0];
            }
            return sum;

        }

        static void Main(string[] args)
        {
            double[,] Matr = CreateMatrix(2, 2);
            showMatrix(Matr);
            int n = Matr.GetLength(0);
            double det = Determinant(Matr);
            Console.WriteLine(det);
        }

        static void showMatrix(double[,] matr)
        {
            Console.WriteLine(Environment.NewLine);
            for (var i = 0; i < matr.GetLength(0); i++, Console.WriteLine())
            {
                for (var j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matr[i, j]);
                }
            }
        }

        static double[,] CreateMatrix(int n, int m)
        {
            double[,] matrCreating = new double[n, m];
            for (var i = 0; i < matrCreating.GetLength(0); i++)
            {
                for (var j = 0; j < matrCreating.GetLength(1); j++)
                {
                    do Console.WriteLine($"\bA[{i + 1},{j + 1}]"); while (!double.TryParse(Console.ReadLine(), out matrCreating[i, j]));
                }
            }
            return matrCreating;
        }
    }
}
