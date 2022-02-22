using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ellipse
{
    public class EllipseFigure
    {
        public point centre;
        public int horizontalRadius { get; private set; }
        public int verticalRadius { get; private set; }

        public EllipseFigure(point centre, int horizontalradius, int verticalradius)
        {
            if (horizontalradius <= 0)
            {
                throw new ArgumentException("Горизонтальный радиус введён неверно");
            }
            if (verticalradius <= 0)
            {
                throw new ArgumentException("Вертикальный радиус введён неверно");
            }

            centre = centre;
            horizontalRadius = horizontalradius;
            verticalRadius = verticalradius;

        }
        public double GetSquare()
        {
            return Math.Round(Math.PI * horizontalRadius * verticalRadius);
        }
        public double GetLenght()
        {
            return Math.Round(Math.PI * (horizontalRadius + verticalRadius));
        }
    }
}
