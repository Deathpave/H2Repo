using Geometri.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.Shapes
{
//Hvorfor ikke bare bruger interface istedet for en abstrakt klasse?
    public abstract class Shape : ICalculateArea, ICalculateCircumference
    {
        public abstract double CalculateArea();
        public abstract double CalculateCircumference();
    }
}
