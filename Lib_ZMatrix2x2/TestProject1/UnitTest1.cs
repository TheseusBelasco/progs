namespace Lib_ZMatrix2x2.Tests
{
    [TestFixture]
    public class ZMatrix2x2Tests
    {
        private ZMatrix2x2 matrixA;
        private ZMatrix2x2 matrixB;

        [SetUp]
        public void Setup()
        {
            matrixA = new ZMatrix2x2(new double[,] { { 1, 2 }, { 3, 4 } });
            matrixB = new ZMatrix2x2(new double[,] { { 5, 6 }, { 7, 8 } });
        }

        [Test]
        public void Constructor_InitializesMatrixCorrectly()
        {
            var expected = new double[,] { { 1, 2 }, { 3, 4 } };
            var result = matrixA.To2DArray();

            Assert.That(result[0, 0], Is.EqualTo(expected[0, 0]));
            Assert.That(result[0, 1], Is.EqualTo(expected[0, 1]));
            Assert.That(result[1, 0], Is.EqualTo(expected[1, 0]));
            Assert.That(result[1, 1], Is.EqualTo(expected[1, 1]));
        }

        [Test]
        public void RandomMatrix_ReturnsValidMatrix()
        {
            var randomMatrix = ZMatrix2x2.RandomMatrix(-10, 10);
            var values = randomMatrix.To2DArray();

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    Assert.That(values[i, j], Is.InRange(-10, 10));
        }

        [Test]
        public void Track_CalculatesTraceCorrectly()
        {
            Assert.That(matrixA.Track, Is.EqualTo(5)); // 1 + 4
        }

        [Test]
        public void Determinant_CalculatesDeterminantCorrectly()
        {
            Assert.That(matrixA.Determinant, Is.EqualTo(-2)); // 1*4 - 2*3
        }

        [Test]
        public void ToString_ReturnsCorrectFormat()
        {
            string expected = "1 2\n3 4";
            Assert.That(matrixA.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void Equals_TwoEqualMatrices_ReturnsTrue()
        {
            var sameMatrix = new ZMatrix2x2(new double[,] { { 1, 2 }, { 3, 4 } });
            Assert.That(matrixA.Equals(sameMatrix), Is.True);
        }

        [Test]
        public void Equals_TwoDifferentMatrices_ReturnsFalse()
        {
            var differentMatrix = new ZMatrix2x2(new double[,] { { 1, 2 }, { 3, 5 } });
            Assert.That(matrixA.Equals(differentMatrix), Is.False);
        }

        [Test]
        public void GetHashCode_EqualMatricesHaveSameHashCode()
        {
            var sameMatrix = new ZMatrix2x2(new double[,] { { 1, 2 }, { 3, 4 } });
            Assert.That(matrixA.GetHashCode(), Is.EqualTo(sameMatrix.GetHashCode()));
        }

        [Test]
        public void Addition_OperatorWorksCorrectly()
        {
            var expected = new ZMatrix2x2(new double[,] { { 6, 8 }, { 10, 12 } });
            var result = matrixA + matrixB;

            Assert.That(result.Equals(expected), Is.True);
        }

        [Test]
        public void MultiplyByScalar_OperatorWorksCorrectly()
        {
            var expected = new ZMatrix2x2(new double[,] { { 3, 6 }, { 9, 12 } });
            var result = matrixA * 3;

            Assert.That(result.Equals(expected), Is.True);
        }

        [Test]
        public void MultiplyByMatrix_OperatorWorksCorrectly()
        {
            var expected = new ZMatrix2x2(new double[,] { { 19, 22 }, { 43, 50 } });
            var result = matrixA * matrixB;

            Assert.That(result.Equals(expected), Is.True);
        }

        [Test]
        public void To2DArray_ReturnsCopyOfInternalMatrix()
        {
            var array = matrixA.To2DArray();
            array[0, 0] = 99;

            // ѕровер€ем, что внутренн€€ матрица не изменилась
            Assert.That(array[0, 0], Is.Not.EqualTo(matrixA.To2DArray()[0, 0]));
        }

        [Test]
        public void Constructor_ThrowsArgumentException_ForNullMatrix()
        {
            Assert.Throws<ArgumentException>(() => new ZMatrix2x2(null));
        }

        [Test]
        public void Constructor_ThrowsArgumentException_ForNon2x2Matrix()
        {
            var invalidMatrix = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            Assert.Throws<ArgumentException>(() => new ZMatrix2x2(invalidMatrix));
        }
    }
}