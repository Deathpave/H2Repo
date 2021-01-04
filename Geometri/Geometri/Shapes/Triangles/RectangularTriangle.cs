using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.Shapes.Triangles
{
//Hvor er dine kodekommentar
    class RectangularTriangle : Shape
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;
        public RectangularTriangle(double SideA, double SideB)
        {
            _sideA = SideA;
            _sideB = SideB;
            Pythagoras();
        }

        public override double CalculateArea()
        {
            return 0.5 * _sideA * _sideB;
        }

        public override double CalculateCircumference()
        {
            return _sideA + _sideB + _sideC;
        }

        private void Pythagoras()
        {
            _sideC = Math.Sqrt((_sideA * _sideA) + (_sideB * _sideB));
        }
    }
}
