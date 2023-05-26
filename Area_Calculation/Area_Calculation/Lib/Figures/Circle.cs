using Area_Calculation.Lib.Interfaces;

namespace Area_Calculation.Lib.Figures
{
    /// <summary>
    /// Класс для круга
    /// </summary>
    public sealed class Circle : IFigure
    {
        /// <summary>
        /// Конструктор создания круга
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        public Circle(double radius = 0)
        {
            Radius = radius;
        }

        private double _radius;
 
        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius 
        {
            get
            {
                return _radius;
            }
            set
            {
                if (value > 0)
                {
                    _radius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Radius is less zero");
                }
            }
        }

        /// <inheritdoc />
        public double Area()
        {
            return 2 * Math.PI * this.Radius;
        }
    }
}
