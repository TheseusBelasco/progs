using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_ZMatrix2x2
{
    public struct ZMatrix2x2
    {
        private static readonly Random random = new Random();
        private readonly double[,] matrix;

        public ZMatrix2x2(double[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
                throw new ArgumentException("Матрица должна быть размером 2x2");

            this.matrix = new double[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    this.matrix[i, j] = matrix[i, j];
        }

        public static ZMatrix2x2 RandomMatrix(int min = -100, int max = 100)
        {
            var mat = new double[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    mat[i, j] = random.Next(min, max + 1);

            return new ZMatrix2x2(mat);
        }

        public double Track => matrix[0, 0] + matrix[1, 1];

        public double Determinant => matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        public override string ToString()
        {
            return $"{matrix[0, 0]} {matrix[0, 1]}\n{matrix[1, 0]} {matrix[1, 1]}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ZMatrix2x2 other))
                return false;

            return
                Math.Abs(matrix[0, 0] - other.matrix[0, 0]) < 1e-13 &&
                Math.Abs(matrix[0, 1] - other.matrix[0, 1]) < 1e-13 &&
                Math.Abs(matrix[1, 0] - other.matrix[1, 0]) < 1e-13 &&
                Math.Abs(matrix[1, 1] - other.matrix[1, 1]) < 1e-13;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + matrix[0, 0].GetHashCode();
                hash = hash * 23 + matrix[0, 1].GetHashCode();
                hash = hash * 23 + matrix[1, 0].GetHashCode();
                hash = hash * 23 + matrix[1, 1].GetHashCode();
                return hash;
            }
        }

        public static ZMatrix2x2 operator +(ZMatrix2x2 a, ZMatrix2x2 b)
        {
            return new ZMatrix2x2(new double[,]
            {
                { a.matrix[0, 0] + b.matrix[0, 0], a.matrix[0, 1] + b.matrix[0, 1] },
                { a.matrix[1, 0] + b.matrix[1, 0], a.matrix[1, 1] + b.matrix[1, 1] }
            });
        }

        public static ZMatrix2x2 operator *(ZMatrix2x2 a, int scalar)
        {
            return new ZMatrix2x2(new double[,]
            {
                { a.matrix[0, 0] * scalar, a.matrix[0, 1] * scalar },
                { a.matrix[1, 0] * scalar, a.matrix[1, 1] * scalar }
            });
        }

        public static ZMatrix2x2 operator *(ZMatrix2x2 a, ZMatrix2x2 b)
        {
            return new ZMatrix2x2(new double[,]
            {
                { a.matrix[0, 0] * b.matrix[0, 0] + a.matrix[0, 1] * b.matrix[1, 0],
                  a.matrix[0, 0] * b.matrix[0, 1] + a.matrix[0, 1] * b.matrix[1, 1] },
                { a.matrix[1, 0] * b.matrix[0, 0] + a.matrix[1, 1] * b.matrix[1, 0],
                  a.matrix[1, 0] * b.matrix[0, 1] + a.matrix[1, 1] * b.matrix[1, 1] }
            });
        }
        public double[,] To2DArray()
        {
            var arr = new double[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    arr[i, j] = matrix[i, j];
            return arr;
        }
    }
}
