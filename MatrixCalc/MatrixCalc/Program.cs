using System;
using System.IO;

namespace MatrixCalc
{
    // класс с методами расширения
    static class MatrixExt
    {
        // метод расширения для получения количества строк матрицы
        public static int RowsCount(this double[,] matrix)
        {
            return matrix.GetUpperBound(0) + 1;
        }

        // метод расширения для получения количества столбцов матрицы
        public static int ColumnsCount(this double[,] matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }
    }
    class Program
    {
        /// <summary>
        /// Метод отвечают за основную логику программы.
        /// </summary>
        static void Main()
        {

            do
            {
                try
                {
                    int key = 0, numMat;
                    Console.Clear();
                    Console.WriteLine("\bМатричный калькулятор.");
                    Console.WriteLine("Сколько матриц вы будете вводить?");
                    do Console.WriteLine("\b1 или 2 матрицы?"); while (!int.TryParse(NumOfMat(), out numMat));
                    // При 1 матрице запускает логику для одной матрицы, иначе для двух.
                    if (numMat == 1)
                    {
                        ForOneMatrix(key);
                    }
                    else
                    {
                        ForTwoMatrix(key);
                    }
                    Console.WriteLine("\tДля выхода нажмите ESCAPE, чтобы продолжить нажмите на ЛЮБУЮ КЛВАИШУ.");
                }
                catch
                {
                    Console.WriteLine("Скорее всего у вас проблемы с файлом. Читайте readme.txt");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Здесь нужно указать путь к файлу. 
        /// Пример пути C:\Users\Пользователь\source\repos\MatrixCalc\test.txt 
        /// </summary>
        /// <returns>Возвращает путь</returns>
        static string GetTxt()
        {
            string path = @"C:\Users\Пользователь\source\repos\MatrixCalc\test.txt";
            return path;
        }
        /// <summary>
        /// Метод отвечает за нажатие клавиш, чтобы вдальнейшем осуществить выбор операции для одной матрицы.
        /// </summary>
        /// <param name="key">Возвращает номер операции.</param>
        /// <returns>Каждый key - своя операция.</returns>
        private static int GetOperationForOne(ref int key)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    return key = 1;
                case ConsoleKey.D2:
                    return key = 2;
                case ConsoleKey.D3:
                    return key = 3;
                case ConsoleKey.D4:
                    return key = 4;
                default:
                    Console.WriteLine("\bТакой операции не существует.");
                    return key = 0;
            }
        }
        /// <summary>
        /// Метод отвечает за нажатие клавиш, чтобы вдальнейшем осуществить выбор операции для двух матриц.
        /// </summary>
        /// <param name="key">Возвращает номер операции.</param>
        /// <returns>Каждый key - своя операция.</returns>
        private static int GetOperationForTwo(ref int key)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    return key = 1;
                case ConsoleKey.D2:
                    return key = 2;
                case ConsoleKey.D3:
                    return key = 3;
                default:
                    Console.WriteLine("\bТакой операции не существует.");
                    return key = 0;
            }
        }
        /// <summary>
        /// Метод отвечает для доступность операции при каждом случае для одной матрицы.
        /// Если матрица квадратная, то доступны 4 операции.
        /// Если матрица имеет другой размер, то всего 2.
        /// </summary>
        /// <param name="matrOne">На вход подается матрица для анализа её размеров.</param>
        static void IntroductionForOne(double[,] matrOne)
        {
            Console.WriteLine("\bДоступные операции: ");
            if (matrOne.GetLength(0) == matrOne.GetLength(1))
            {

                Console.WriteLine("\t 1. Транспонирование матрицы;");
                Console.WriteLine("\t 2. Умножение матриц на число;");
                Console.WriteLine("\t 3. След Матрицы;");
                Console.WriteLine("\t 4. Найти определитель матрицы;");
            }
            else
            {
                Console.WriteLine("\t 1. Транспонирование матрицы;");
                Console.WriteLine("\t 2. Умножение матриц на число;");
            }

        }
        /// <summary>
        /// Метод отвечает за доступность операций для двух матриц.
        /// </summary>
        /// <param name="n1">Строки первой матрцы.</param>
        /// <param name="n2">Строки второй матрицы.</param>
        /// <param name="m1">Столбцы первой матрицы.</param>
        /// <param name="m2">Столбцы второй матрицы.</param>
        static void IntroductionForTwo(int n1, int n2, int m1, int m2)
        {
            // Если кол-во столбцов первой матрицы и кол-во строк второй матрицы совпадает, то их можно умножить.
            Console.WriteLine("\bДоступные операции:");
            if ((m1 == n2) && (n1 != m2))
            {
                Console.WriteLine("\t1. Умножить матрицы;");
            }
            else if ((m1 == n2) && (n1 == m2))
            {
                Console.WriteLine("\t1. Сложить матрицы;");
                Console.WriteLine("\t2. Вычесть матрицы;");
                Console.WriteLine("\t3. Умножить матрицы;");
            }
            // Если матрицы совсем отличны друг от друга, то операций нет.
            else
            {
                Console.WriteLine("У вас не подходят матрицы!");
            }
        }
        /// <summary>
        /// Создание матрицы, где можно вводить свои значения.
        /// Ограничения созданы в целях избежать исключений.
        /// </summary>
        /// <param name="n"> Кол-во строк.</param>
        /// <param name="m"> Кол-во столбцов.</param>
        /// <param name="letter"> Буква матрицы А или B. </param>
        /// <returns></returns>
        static double[,] CreateMatrix(int n, int m, string letter)
        {
            double[,] matrCreating = new double[n, m];
            for (var i = 0; i < matrCreating.GetLength(0); i++)
            {
                for (var j = 0; j < matrCreating.GetLength(1); j++)
                {
                    do Console.WriteLine($"\bВведите элемент (от -10000 до 10000) в  матрице {letter}: столбец - {i + 1}, строка - {j + 1}]");
                    while ((!double.TryParse(Console.ReadLine(), out matrCreating[i, j])) || (matrCreating[i, j] > 10000) || ((matrCreating[i, j] < -10000)));
                }
            }
            return matrCreating;
        }
        /// <summary>
        /// Операция выводит матрицу на экран.
        /// </summary>
        /// <param name="matr">На вход подается матрица, которую нужно вывести.</param>
        static void showMatrix(double[,] matr)
        {
            Console.WriteLine(Environment.NewLine);
            for (var i = 0; i < matr.GetLength(0); i++, Console.WriteLine())
            {
                for (var j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write("{0,3}     ", matr[i, j]);
                }
            }
        }
        /// <summary>
        /// Метод считывает матрицу из файла.
        /// </summary>
        /// <param name="path">На вход подается путь файла с матрицой.</param>
        /// <returns></returns>
        static double[,] readTXT(string path)
        {
            Console.Clear();
            // path = @"C:\Users\Пользователь\source\repos\MatrixCalc\test.txt";
            // Пример пути к файлу.
            string[] splitLine = path.Split();
            string[] readText = File.ReadAllLines(path);
            int lenOfFirst = readText[0].Split().Length;
            double num;
            var emptMat = new string[lenOfFirst, lenOfFirst];
            string[] aaa = readText[0].Split();

            for (var i = 0; i < lenOfFirst - 1; i++)
            {
                string[] empty = readText[i].Split();
                for (var j = 0; j < lenOfFirst; j++)
                {
                    emptMat[i, j] = empty[j];
                }
            }
            int row = emptMat.GetLength(1);
            var TXTMatr = new double[lenOfFirst, row];
            for (var i = 0; i < lenOfFirst; i++)
            {
                for (var j = 0; j < lenOfFirst; j++)
                {
                    double.TryParse(emptMat[i, j], out num);
                    TXTMatr[i, j] = num;
                }
            }
            return TXTMatr;

        }
        

        /// <summary>
        /// Считает кол-во матриц.
        /// </summary>
        /// <returns>Возвращает кол-во матриц.</returns>
        static string NumOfMat()
        {
            switch (Console.ReadKey().Key)
            {
                case (ConsoleKey.D1):
                    return "1";
                case (ConsoleKey.D2):
                    return "2";
                case (ConsoleKey.D3):
                    return "3";
                default:
                    return null;
            }
        }
        /// <summary>
        /// Логика для 1 матрицы.
        /// Вызов всех доступных функций.
        /// </summary>
        /// <param name="key">На вход принимает ключ к операциям.</param>
        static void ForOneMatrix(int key)
        {
            int n, m;
            Console.Write("\bЕсли вы хотите считать матрицу из файла, то введите любое число от 1 до 10 в длину и ширину ");
            Console.WriteLine("и нажмите на 3.");
            do Console.Write("\bВведите кол-во строк матрицы от 1 до 10: "); while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 10);
            do Console.Write("\bВведите кол-во столбцов матрицы от 1 до 10: "); while (!int.TryParse(Console.ReadLine(), out m) || m < 1 || n > 10);
            Console.WriteLine("Нажмите 1 для того, чтобы получить рандомную матрицу.");
            Console.WriteLine("Нажмите 2 для того, чтобы ввести значения вручную.");
            Console.WriteLine("Нажмите 3 для того, чтобы ввести матрицу из файла.");
            string status = NumOfMat();
            if (status == "1")
            {
                double[,] oneMatr = RandomMatr(n, m);
                IntroductionForOne(oneMatr);
                if (n != m)
                {
                    while ((key == 0) || (key == 4)) GetOperationForOne(ref key);
                    showMatrix(oneMatr);
                    if (key == 1) TranspMatr(oneMatr);
                    if (key == 2) MultiMatr(oneMatr);

                }
                else
                {
                    while (key == 0) GetOperationForOne(ref key);
                    showMatrix(oneMatr);
                    if (key == 1) TranspMatr(oneMatr);
                    if (key == 2) MultiMatr(oneMatr);
                    if (key == 3) TrailMatr(oneMatr);
                    if (key == 4) GetDet(oneMatr);
                }
            }
            else if (status == "2")
            {
                double[,] oneMatr = CreateMatrix(n, m, "A");
                IntroductionForOne(oneMatr);
                if (n != m)
                {
                    while ((key == 0) || (key == 4)) GetOperationForOne(ref key);
                    showMatrix(oneMatr);
                    if (key == 1) TranspMatr(oneMatr);
                    if (key == 2) MultiMatr(oneMatr);

                }
                else
                {
                    while (key == 0) GetOperationForOne(ref key);
                    showMatrix(oneMatr);
                    if (key == 1) TranspMatr(oneMatr);
                    if (key == 2) MultiMatr(oneMatr);
                    if (key == 3) TrailMatr(oneMatr);
                    if (key == 4) GetDet(oneMatr);
                }
            }
            else if (status == "3")
            {
                TXTOperation(key);
            }
        }

        static void TXTOperation(int key)
        {
            string path = GetTxt();

            if (File.Exists(path))
            {
                double[,] txtMatr = readTXT(path);
                int n = txtMatr.GetLength(0);
                int m = txtMatr.GetLength(1);

                IntroductionForOne(txtMatr);
                if (n != m)
                {
                    while ((key == 0) || (key == 4)) GetOperationForOne(ref key);
                    showMatrix(txtMatr);
                    if (key == 1) TranspMatr(txtMatr);
                    if (key == 2) MultiMatr(txtMatr);

                }
                else
                {
                    while (key == 0) GetOperationForOne(ref key);
                    showMatrix(txtMatr);
                    if (key == 1) TranspMatr(txtMatr);
                    if (key == 2) MultiMatr(txtMatr);
                    if (key == 3) TrailMatr(txtMatr);
                    if (key == 4) GetDet(txtMatr);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\bОшибка! Читайте readme.txt, чтобы узнать как вводить правильный путь!");
            }
        }
        /// <summary>
        /// Логика для двух матриц. Запускает доступные операции.
        /// </summary>
        /// <param name="key">На вход принимает ключ.</param>
        static void ForTwoMatrix(int key)
        {
            int n1, m1, n2, m2, flagForRandom = -1;
            do Console.Write("\bВведите кол-во строки первой матрицы: "); while (!int.TryParse(Console.ReadLine(), out n1) || n1 < 1 || n1 > 10);
            do Console.Write("\bВведите кол-во столбцы первой матрицы: "); while (!int.TryParse(Console.ReadLine(), out m1) || m1 < 1 || m1 > 10);
            do Console.Write("\bВведите кол-во строки второй матрицы: "); while (!int.TryParse(Console.ReadLine(), out n2) || n2 < 1 || n2 > 10);
            do Console.Write("\bВведите кол-во столбцы второй матрицы: "); while (!int.TryParse(Console.ReadLine(), out m2) || m2 < 1 || m2 > 10);
            double[,] firstMatr;
            double[,] secondMatr;
            Console.WriteLine("Нажмите 1 для того, чтобы создать рандомную матрицу.");
            Console.WriteLine("Нажмите 2 для того, чтобы ввести значения вручную.");
            do
            {
                string status = NumOfMat();
                if (status == "1")
                {
                    flagForRandom = 1;
                }
                else if (status == "2")
                {
                    flagForRandom = 0;
                }
                else
                {
                    Console.WriteLine("Нажмите 1 для того, чтобы создать рандомную матрицу.");
                    Console.WriteLine("Нажмите 2 для того, чтобы ввести значения вручную.");
                    flagForRandom = -1;
                }
            } while (flagForRandom == -1);

            if (flagForRandom == 1)
            {
                firstMatr = RandomMatr(n1, m1);
                secondMatr = RandomMatr(n2, m2);
                IntroductionForTwo(n1, n2, m1, m2);

                if ((m1 == n2) && (n1 != m2))
                {
                    while (key == 0) GetOperationForTwo(ref key);
                    if (key == 1) DoubleMatr(firstMatr, secondMatr);
                }
                else if ((m1 == n2) && (n1 == m2))
                {
                    while (key == 0) GetOperationForTwo(ref key);
                    if (key == 1) PlusMatr(firstMatr, secondMatr);
                    if (key == 2) MinusMatr(firstMatr, secondMatr);
                    if (key == 3) DoubleMatr(firstMatr, secondMatr);
                }
                else
                {
                    Console.WriteLine("С такими матрицами нет операций.");
                }
            }
            else if (flagForRandom == 0)
            {
                firstMatr = CreateMatrix(n1, m1, "A");
                secondMatr = CreateMatrix(n2, m2, "B");
                IntroductionForTwo(n1, n2, m1, m2);

                if ((m1 == n2) && (n1 != m2))
                {
                    while (key == 0) GetOperationForTwo(ref key);
                    if (key == 1) DoubleMatr(firstMatr, secondMatr);
                }
                else if ((m1 == n2) && (n1 == m2))
                {
                    while (key == 0) GetOperationForTwo(ref key);
                    if (key == 1) PlusMatr(firstMatr, secondMatr);
                    if (key == 2) MinusMatr(firstMatr, secondMatr);
                    if (key == 3) DoubleMatr(firstMatr, secondMatr);
                }
                else
                {
                    Console.WriteLine("С такими матрицами нет операций.");
                }
            }
        }
        /// <summary>
        /// Создание рандомно сгенерированого массива.
        /// </summary>
        /// <param name="n">Строки матрицы</param>
        /// <param name="m">Столбцы матрицы</param>
        /// <returns></returns>
        static double[,] RandomMatr(int n, int m)
        {
            double[,] randomMatr = new double[n, m];
            // Создание метода для рандомныхх чисел.
            var rnd = new Random();
            for (var i = 0; i < randomMatr.GetLength(0); i++)
            {
                for (var j = 0; j < randomMatr.GetLength(1); j++)
                {
                    randomMatr[i, j] = rnd.Next(-100, 100);
                }
            }
            return randomMatr;
        }
        /// <summary>
        /// Транспонирование матрицы. Меняте сроки со столбцами.
        /// </summary>
        /// <param name="matr">Матрица, которую нужно перевернуть</param>
        static void TranspMatr(double[,] matr)
        {
            Console.Clear();
            Console.WriteLine("Текущая матрица:");
            showMatrix(matr);
            Console.WriteLine("Транспонированная матрица: ");
            int n = matr.GetLength(0);
            int m = matr.GetLength(1);
            double[,] transpMatr = new double[m, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    transpMatr[j, i] = matr[i, j];
                }
            }
            showMatrix(transpMatr);
        }
        /// <summary>
        /// Умножение матрицы на число.
        /// </summary>
        /// <param name="matr">Умножаемая матрица.</param>
        static void MultiMatr(double[,] matr)
        {
            Console.Clear();
            int n = matr.GetLength(0);
            int m = matr.GetLength(1);
            double multiNum;
            do Console.WriteLine("\bВведите число на которое вы хотите умножить матрицу"); while (!double.TryParse(Console.ReadLine(), out multiNum));
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    matr[i, j] *= multiNum;
                }
            }
            showMatrix(matr);
        }
        /// <summary>
        /// Поиск следа матрицы.
        /// </summary>
        /// <param name="matr">Матрица, след которой нужно найти</param>
        static void TrailMatr(double[,] matr)
        {
            Console.Clear();
            showMatrix(matr);
            double trail = 0;
            int n = matr.GetLength(0);
            for (var i = 0; i < n; i++)
            {
                trail += matr[i, i];
            }
            Console.WriteLine($"След матрицы: {trail}");
        }
        /// <summary>
        /// Операция сложения двух матриц.
        /// </summary>
        /// <param name="FirstMatr">Первая матрица.</param>
        /// <param name="secondMatr">Вторая матрица.</param>
        static void PlusMatr(double[,] FirstMatr, double[,] secondMatr)
        {
            int n = FirstMatr.GetLength(0);
            int m = FirstMatr.GetLength(1);
            double[,] matrC = new double[n, m];
            Console.Clear();
            showMatrix(FirstMatr);
            showMatrix(secondMatr);
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    matrC[i, j] = FirstMatr[i, j] + secondMatr[i, j];
                }
            }
            Console.WriteLine("Сумма матриц: ");
            showMatrix(matrC);
        }
        /// <summary>
        /// Разность двух матриц.
        /// </summary>
        /// <param name="FirstMatr">Первая матрица.</param>
        /// <param name="secondMatr">Вторая матрица.</param>
        static void MinusMatr(double[,] FirstMatr, double[,] secondMatr)
        {
            int n = FirstMatr.GetLength(0);
            int m = FirstMatr.GetLength(1);
            double[,] matrC = new double[n, m];
            Console.Clear();
            showMatrix(FirstMatr);
            showMatrix(secondMatr);
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    matrC[i, j] = FirstMatr[i, j] - secondMatr[i, j];
                }
            }
            Console.WriteLine("Сумма матриц: ");
            showMatrix(matrC);
        }
        /// <summary>
        /// Умножение матриц.
        /// </summary>
        /// <param name="firstMatr">Первая матрица.</param>
        /// <param name="secondMatr">Вторая матрица.</param>
        static void DoubleMatr(double[,] firstMatr, double[,] secondMatr)
        {
            Console.Clear();
            int n1 = firstMatr.GetLength(0);
            int m1 = firstMatr.GetLength(1);
            int n2 = secondMatr.GetLength(0);
            int m2 = secondMatr.GetLength(1);

            showMatrix(firstMatr);
            showMatrix(secondMatr);
            
            var matrixC = new double[firstMatr.RowsCount(), secondMatr.ColumnsCount()];
            // Создание третьей матрицы нужного для умножения размера.
            for (var i = 0; i < firstMatr.RowsCount(); i++)
            {
                for (var j = 0; j < secondMatr.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < firstMatr.ColumnsCount(); k++)
                    {
                        matrixC[i, j] += firstMatr[i, k] * secondMatr[k, j];
                    }
                }
            }
            Console.WriteLine("Результат умножения: ");
            showMatrix(matrixC);
        }
        /// <summary>
        /// Поиск минора матрицы.
        /// </summary>
        /// <param name="matr">Матрица из которой нужно получить минор.</param>
        /// <param name="num">Номер столбца, который подлежит обнулению.</param>
        /// <returns>Возвращает минор.</returns>
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
        /// <summary>
        /// Поиск детерминанта матрицы.
        /// </summary>
        /// <param name="matr"> Матрица, которой детерминат нужно получить.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Вывод определителя.
        /// </summary>
        /// <param name="matr">МНа вход подается матрица, которую нужно найти.</param>
        /// <returns></returns>
        static double GetDet(double[,] matr)
        {
            double det = Determinant(matr);
            Console.WriteLine($"Определитель: {det}");
            return det;
        }
    }
}
