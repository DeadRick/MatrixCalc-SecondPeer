using System;
using System.IO;

namespace Multi
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = @"C:\Users\Пользователь\source\repos\MatrixCalc\test.txt";
            string[] splitLine = path.Split();
            string[] readText = File.ReadAllLines(path);
            int lenOfFirst = readText[0].Split().Length;
            var TXTMatr = new double[lenOfFirst, lenOfFirst];
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

            for (var i = 0; i < lenOfFirst; i++)
            {
                for (var j = 0; j < lenOfFirst; j++)
                {
                    double.TryParse(emptMat[i, j], out num);
                    TXTMatr[i, j] = num;
                }
            }
            return; ;
        }
    }
}
