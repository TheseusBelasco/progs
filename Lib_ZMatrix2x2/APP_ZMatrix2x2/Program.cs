using Lib_ZMatrix2x2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_ZMatrix2x2
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix1 = ZMatrix2x2.RandomMatrix(-50, 50);
            var matrix2 = ZMatrix2x2.RandomMatrix(-50, 50);

            Console.WriteLine("Матрица 1:");
            PrintMatrix(matrix1);

            Console.WriteLine("\nМатрица 2:");
            PrintMatrix(matrix2);

            Console.WriteLine($"\nСлед матрицы: {matrix1.Track}");
            Console.WriteLine($"Определитель матрицы: {matrix1.Determinant}");

            var sum = matrix1 + matrix2;
            Console.WriteLine("\nСумма матриц:");
            PrintMatrix(sum);

            var scalarProduct = matrix1 * 3;
            Console.WriteLine("\nУмножение матрицы 1 на k, равное, к примеру, 3:");
            PrintMatrix(scalarProduct);

            var product = matrix1 * matrix2;
            Console.WriteLine("\nПроизведение матриц:");
            PrintMatrix(product);

            var sameMatrix = new ZMatrix2x2(matrix1.To2DArray());
            Console.WriteLine($"\nРавность матрицы и копии: {matrix1.Equals(sameMatrix)}");
            Console.WriteLine($"Хеш-код матрицы 1: {matrix1.GetHashCode()}");
            Console.WriteLine($"Хеш-код копии: {sameMatrix.GetHashCode()}");

            Console.ReadKey();
        }
        static void PrintMatrix(ZMatrix2x2 matrix)
        {
            Console.WriteLine(matrix.ToString());
        }

    }
}
