using Area_Calculation.Lib.Figures;
using Area_Calculation.Lib.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Area_Calculation.UnitTests
{
    /// <summary>
    /// Тесты для <see cref="Circle"/>
    /// </summary>
    [TestClass]
    public sealed class CircleTests
    {
        /// <summary>
        /// Тест при корректном радиусе
        /// </summary>
        [TestMethod]
        public void Area_CorrectRadius_Success()
        {
            // Arrange
            const double radius = 100;
            IFigure circle = new Circle(radius);
            double expected = 2 * Math.PI * radius;

            // Act
            double result = circle.Area();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
    "Radius is less then 0")]
        public void Area_RadiusLessZero_Throw()
        {
            // Arrange
            const double radius = -100;
            IFigure circle = new Circle(radius);

            // Act && Assert
            circle.Area();
        }
    }
}
