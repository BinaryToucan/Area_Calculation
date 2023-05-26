using Area_Calculation.Lib.Figures;
using Area_Calculation.Lib.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Area_Calculation.UnitTests
{
    /// <summary>
    /// Тесты для <see cref="Triangle"/>
    /// </summary>
    [TestClass]
    public sealed class TriangleTests
    {
        /// <summary>
        /// Тест при корректных данных
        /// </summary>
        [TestMethod]
        public void Area_CorrectData_Success()
        {
            // Arrange
            double[] sides = { 4, 3, 2 };

            IFigure triangle = new Triangle(sides);

            double expected = TriangleArea(sides);

            // Act
            double result = triangle.Area();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Метод Area должен верно рассчитать площадь для прямоугольного треугольника
        /// </summary>
        [TestMethod]
        public void Area_RightTriangle_Throw()
        {
            // Arrange
            double[] sides = { 5, 3, 4 };

            Triangle triangle = new Triangle(sides);

            double expected = TriangleArea(sides);

            // Act
            double result = triangle.Area();

            // Assert
            bool isRight = triangle.IsRight;

            Assert.IsTrue(isRight);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Метод Area должен вызывать ошибку при хотя бы одной отрицательном значении 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
    "One or more elements are less zero")]
        public void Area_SideLessZero_Throw()
        {
            // Arrange
            double[] sides = { -4, 3, 2 };

            // Act && Assert
            IFigure triangle = new Triangle(sides);
        }

        /// <summary>
        /// Метод Area должен вызывать ошибку если невозможно построить треугольник
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
    "It is not a correct triangle")]
        public void Area_ImposibleTriangle_Throw()
        {
            // Arrange
            double[] sides = { 14, 3, 2 };

            IFigure triangle = new Triangle(sides);

            // Act && Assert
            triangle.Area();
        }

        /// <summary>
        /// Метод Area должен вызывать ошибку если было передано меньше трех элементов
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
    "The number of elements in the array is less or more than 3")]
        public void Area_LessInputArray_Throw()
        {
            // Arrange
            double[] sides = { 14, 3};

            // Act && Assert
            IFigure triangle = new Triangle(sides);
        }

        /// <summary>
        /// Метод Area должен вызывать ошибку если было передано больше трех элементов
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
    "The number of elements in the array is less or more than 3")]
        public void Area_MoreInputArray_Throw()
        {
            // Arrange
            double[] sides = { 14, 3, 4, 5};

            // Act && Assert
            IFigure triangle = new Triangle(sides);
        }


        private double TriangleArea(double[] sides)
        {
            double semiPer = sides.Sum() / 2;
            double multiplySides = sides.Select(x => semiPer - x).Aggregate(1d, (a, b) => a * b);

            return Math.Sqrt(semiPer * multiplySides);
        }
    }
}
