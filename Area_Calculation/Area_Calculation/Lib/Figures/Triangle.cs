using Area_Calculation.Lib.Interfaces;
using Newtonsoft.Json.Linq;

namespace Area_Calculation.Lib.Figures
{
    /// <summary>
    /// Класс для треугольника
    /// </summary>
    public class Triangle: IFigure
    {
        private const int _countSide = 3;
        private double[] _sides = new double[_countSide];
        private int _hypotenuse = -1;

        /// <summary>
        /// Конструктор для треугольника
        /// </summary>
        /// <param name="sides"> Стороны треугольника </param>
        public Triangle(double[] sides)
        {
            Sides = sides;
            IsRight = CheckSqrtSides();
        }

        /// <summary>
        /// Стороны треугольника
        /// </summary>
        public double[] Sides
        { 
            get
            {
                return _sides;
            }
            set
            {
                if(value.Length != 3)
                {
                    throw new IndexOutOfRangeException("The number of elements in the array is less or more than 3");
                }

                bool check = value.Aggregate(true, (any, val) => any && (val > 0));

                if (check)
                {
                    _sides = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("One or more elements are less zero");
                }
            }
        }

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        public bool IsRight { get; }

        /// <inheritdoc />
        public double Area()
        {
            if(_hypotenuse!= -1)
            {
                return _sides[(_hypotenuse + 1) % _countSide] * _sides[(_hypotenuse + 2) % _countSide] / 2;
            }

            CheckCorrect();

            double semiPer = _sides.Sum() / 2;
            double multiplySides = _sides.Select(x => semiPer - x).Aggregate(1d, (a, b) => a * b); 

            return Math.Sqrt(semiPer * multiplySides);
        }

        private bool CheckSqrtSides() 
        {
            for(int i = 0; i < _countSide; i++)
            {
                bool check = Math.Pow(_sides[i], 2) == Math.Pow(_sides[(i + 1) % _countSide], 2) + Math.Pow(_sides[(i + 2) % _countSide], 2);
                if (check)
                {
                    _hypotenuse = i;
                    return true;
                }
            }
            return false;
        }

        private void CheckCorrect()
        {
            for (int i = 0; i < _countSide; i++)
            {
                bool check = _sides[i] >= _sides[(i + 1) % _countSide] + _sides[(i + 2) % _countSide];
                if (check) throw new InvalidOperationException("It is not a correct triangle");
            }
        }
    }
}
