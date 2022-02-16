using Ellipse;
class Program
{
    public static void Main(string[] args)
    {
        point Centre = new point
        {
            X = 0,
            Y = 0
        };
        int HorizontalRadius = 15;
        int VerticalRadius = 10;
        try
        {
            FEllipse ellipse = new FEllipse(Centre, HorizontalRadius, VerticalRadius);
     
            Console.WriteLine($"Площадь эллипса -> {ellipse.GetSquare()}");
            Console.WriteLine($"Длина дуги эллипса -> {ellipse.GetLenght()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}