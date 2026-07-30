using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.task
{
    struct Point
    {
        double x, y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Rectangle
    {
        public Point TopLeft { get; }
        private double _width, _height;
        public Rectangle(double x, double y, double width, double height)
        {
            TopLeft = new Point(x, y);

            if (width < 0)
            {
                throw new ArgumentOutOfRangeException("Недопустимое значение ширины");
            }
            else
                this._width = width;
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException("Недопустимое значение высоты");
            }
            else
                this._height = height;
        }
        public double Area
        {
            get { return _height * _width; }
        }
        public double Perimeter
        {
            get { return (_height + _width) * 2; }
        }

        public static Rectangle ReadRectangle()
        {
            Console.WriteLine("Внесите параметры прямоугольника. Введите координаты левого верхнего угла прямоугольника (X,Y)");
            string[] coordinates = Console.ReadLine().Split();
            double x = double.Parse(coordinates[0]);
            double y = double.Parse(coordinates[1]);
            Console.WriteLine("Введите ширину и длинну");
            string[] widthAndHeight = Console.ReadLine().Split();
            double width = double.Parse(widthAndHeight[0]);
            double height = double.Parse(widthAndHeight[1]);
            return new Rectangle(x, y, width, height);
        }

        public static void DisplayInfoAboutRectangle(Rectangle rectangle)
        {
            Console.WriteLine($"Периметр прямоугольника: {rectangle.Perimeter}");
            Console.WriteLine($"Площадь прямоугольника: {rectangle.Area}");
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Сколько объектов вы хотите создать?");
                int amountOfRectangles = int.Parse(Console.ReadLine());
                Rectangle[] rectangles = new Rectangle[amountOfRectangles];
                for (int i = 0; i < amountOfRectangles; i++)
                {
                    rectangles[i] = Rectangle.ReadRectangle();
                }
                Console.WriteLine("Что вы желаете сделать? 1 - отобразить все объекты, 2 - показать прямоугольник с наибольшей площадью, 3 - показать прямоугольник с наибольшим периметром");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        for (int i = 0; i < amountOfRectangles; i++)
                        {
                            Rectangle.DisplayInfoAboutRectangle(rectangles[i]);
                        }
                        break;
                    case "2":
                        double maxArea = rectangles[0].Area;
                        int maxAreaRectangle = 0;
                        for (int i = 0; i < amountOfRectangles; i++)
                        {
                            if (maxArea < rectangles[i].Area)
                            {
                                maxArea = rectangles[i].Area;
                                maxAreaRectangle = i + 1;
                            }
                        }
                        Console.WriteLine($"Прямоугольник с наибольшей площадью: {maxAreaRectangle}.\nЕго площадь: {maxArea}");
                        break;
                    case "3":
                        double maxPerimeter = rectangles[0].Perimeter;
                        int maxPerimeterRectangle = 0;
                        for (int i = 0; i < amountOfRectangles; i++)
                        {
                            if (maxPerimeter < rectangles[i].Perimeter)
                            {
                                maxPerimeter = rectangles[i].Perimeter;
                                maxPerimeterRectangle = i + 1;
                            }
                        }
                        Console.WriteLine($"Прямоугольник с наибольшим периметром: {maxPerimeterRectangle}.\nЕго периметр: {maxPerimeter}");
                        break;
                    default:
                        break;
                }

            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}
