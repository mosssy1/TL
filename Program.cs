using Ellipse;
class Program
{
    public static void Main(string[] args)
    {
        point centre = new point
        {
            X = 5,
            Y = 5
        };
        int horizontalradius = 3;
        int verticalradius = 4;
        try
        {
            EllipseFigure ellipse = new EllipseFigure(centre, horizontalradius, verticalradius);
     
            Console.WriteLine($"Площадь эллипса -> {ellipse.GetSquare()}");
            Console.WriteLine($"Длина дуги эллипса -> {ellipse.GetLenght()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}