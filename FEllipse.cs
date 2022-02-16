using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ellipse
{
    public class FEllipse
    {
        public point Centre;
        public int HorizontalRadius { get; set; }
        public int VerticalRadius { get; set; }
        public FEllipse
            (
            point Centre,
            int Horizontalradius,
            int Verticalradius
            )
        {
            if (Horizontalradius <= 0)
            {
                throw new ArgumentException("Горизонтальный радиус введён неверно");
            }
            if (Verticalradius <= 0)
            {
                throw new ArgumentException("Вертикальный радиус введён неверно");
            }

            Centre = Centre;
            HorizontalRadius = Horizontalradius;
            VerticalRadius = Verticalradius;

        }
        public double GetSquare()
        {
            return Math.Round(Math.PI * HorizontalRadius * VerticalRadius);
        }
        public double GetLenght()
        {
            return Math.Round(Math.PI * (HorizontalRadius + VerticalRadius));
        }
    }
}
