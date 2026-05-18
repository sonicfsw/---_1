using System;

// Класс Point описывает точку на плоскости с декартовыми координатами X и Y.
public class Point
{
    // Координата точки по оси X
    // private set означает, что изменить координату можно только внутри класса Point
    public double X { get; private set; }

    // Координата точки по оси Y.
    public double Y { get; private set; }

    // Конструктор создает новую точку с заданными координатами.
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Метод перемещает точку вдоль оси X на указанное расстояние.
    // Если distance положительное, точка движется вправо.
    // Если distance отрицательное, точка движется влево.
    public void MoveX(double distance)
    {
        X += distance;
    }

    // Метод перемещает точку вдоль оси Y на указанное расстояние.
    // Если distance положительное, точка движется вверх.
    // Если distance отрицательное, точка движется вниз.
    public void MoveY(double distance)
    {
        Y += distance;
    }

    // Метод вычисляет расстояние от текущей точки до начала координат (0; 0).
    // Используется формула: sqrt(X^2 + Y^2).
    public double DistanceToOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    // Метод вычисляет расстояние от текущей точки до другой точки.
    // Используется формула: sqrt((x1 - x2)^2 + (y1 - y2)^2).
    public double DistanceTo(Point other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;

        return Math.Sqrt(dx * dx + dy * dy);
    }

    // Метод возвращает строковое представление точки.
    // Благодаря этому объект Point удобно выводить через Console.WriteLine.
    public override string ToString()
    {
        return $"({X}; {Y})";
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Введите координаты первой точки.");
            Point firstPoint = ReadPoint();

            Console.WriteLine("Введите координаты второй точки.");
            Point secondPoint = ReadPoint();

            Console.WriteLine("Введите расстояние для перемещения первой точки.");
            double moveByX = ReadDouble("По оси X: ");
            double moveByY = ReadDouble("По оси Y: ");

            // Выводим начальные координаты точек.
            Console.WriteLine($"Первая точка: {firstPoint}");
            Console.WriteLine($"Вторая точка: {secondPoint}");

            // Выводим расстояние от первой точки до начала координат
            // и расстояние между первой и второй точкой.
            Console.WriteLine($"Расстояние от первой точки до начала координат: {firstPoint.DistanceToOrigin():F2}");
            Console.WriteLine($"Расстояние между точками: {firstPoint.DistanceTo(secondPoint):F2}");

            // Перемещаем первую точку на расстояния, введенные пользователем.
            firstPoint.MoveX(moveByX);
            firstPoint.MoveY(moveByY);

            // Выводим координаты первой точки после перемещения.
            Console.WriteLine($"Первая точка после перемещения: {firstPoint}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: нужно вводить числовые значения.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: введенное число слишком большое или слишком маленькое.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
        }
    }

    // Метод считывает координаты точки с клавиатуры и создает объект Point.
    private static Point ReadPoint()
    {
        double x = ReadDouble("X: ");
        double y = ReadDouble("Y: ");

        return new Point(x, y);
    }

    // Метод считывает одно вещественное число с клавиатуры.
    private static double ReadDouble(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new FormatException();
        }

        return double.Parse(input);
    }
}
