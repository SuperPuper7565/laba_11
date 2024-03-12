using laba_10;
using System;
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
namespace laba_11
{
    internal class Program
    {
        static Random random = new Random();
        static void PrintStack(Stack stack)
        {
            foreach (Shape item in stack)
            {
                Console.WriteLine(item.ToString());
            }
        }
        static void PrintSortedDictionary(SortedDictionary<Shape, Rectangle> sd)
        {
            foreach (var item in sd.Keys)
            {
                Console.WriteLine($"Ключ: {item}, значение: {sd[item]}");
            }
        }
        static double GetDouble(string message, double min, double max)
        {
            bool isConvert;
            double result;
            do
            {
                Console.WriteLine(message);
                isConvert = double.TryParse(Console.ReadLine(), out result);
                if (!isConvert || result < min || result > max)
                    Console.WriteLine("Ошибка ввода");
            }
            while (!isConvert || result < min || result > max);
            return result;
        }
        static void AllSquareAreas(Stack shapes)
        {
            Console.WriteLine("Все площади квадратов");
            int count = 0;
            foreach (Shape shape in shapes)
            {
                if (shape is Rectangle r && !(shape is Parallelepiped))
                {
                    if (r.IsSquare())
                    {
                        Console.WriteLine(r.ToString()); ;
                        count++;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine("Квадратов не обнаружено");
        }
        static void AllSquareAreas(SortedDictionary<Shape, Rectangle> sd)
        {
            Console.WriteLine("Все площади квадратов");
            int count = 0;
            foreach (var item in sd.Values)
            {
                if (item is Rectangle r && !(item is Parallelepiped))
                {
                    if (r.IsSquare())
                    {
                        Console.WriteLine(r.ToString()); ;
                        count++;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine("Квадратов не обнаружено");
        }
        static void ShapesWithRightRadius(Stack shapes)
        {
            double radius = GetDouble("Введите радиус описанной окружности", 0, 100);
            Console.WriteLine("Такой радиус описанной окружности у следующих прямоугольников:");
            int count = 0;
            foreach (Shape shape in shapes)
            {
                if (shape is Rectangle r && !(shape is Parallelepiped))
                {
                    if (Math.Pow(r.Width, 2) + Math.Pow(r.Length, 2) == Math.Pow(radius * 2, 2))
                    {
                        Console.WriteLine(r.ToString());
                        count++;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine("подходящих прямоугольников не обнаружено");
        }
        static void ShapesWithRightRadius(SortedDictionary<Shape, Rectangle> sd)
        {
            double radius = GetDouble("Введите радиус описанной окружности", 0, 100);
            Console.WriteLine("Такой радиус описанной окружности у следующих прямоугольников:");
            int count = 0;
            foreach (var item in sd.Values)
            {
                if (item is Rectangle r && !(item is Parallelepiped))
                {
                    if (Math.Pow(r.Width, 2) + Math.Pow(r.Length, 2) == Math.Pow(radius * 2, 2))
                    {
                        Console.WriteLine(r.ToString());
                        count++;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine("подходящих прямоугольников не обнаружено");
        }
        static void ShapesWithRightArea(Stack shapes)
        {
            double area = GetDouble("Введите минимально возможную для фигуры площадь", 0, 10000);
            int count = 0;
            foreach (Shape shape in shapes)
            {
                if (shape is Rectangle && !(shape is Parallelepiped) || (shape is Circle))
                {
                    if (shape.GetArea() >= area)
                    {
                        Console.WriteLine(shape.ToString());
                        count++;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine("Все фигуры меньше заданной площади");
        }
        static void ShapesWithRightArea(SortedDictionary<Shape, Rectangle> sd)
        {
            double area = GetDouble("Введите минимально возможную для фигуры площадь", 0, 10000);
            int count = 0;
            foreach (var shape in sd.Values)
            {
                if (shape is Rectangle && !(shape is Parallelepiped) || (shape is Circle))
                {
                    if (shape.GetArea() >= area)
                    {
                        Console.WriteLine(shape.ToString());
                        count++;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine("Все фигуры меньше заданной площади");
        }
        static void Find (SortedDictionary<Shape, Rectangle> sd, Rectangle find)
        {
            bool ok = sd.ContainsKey(find);
            if (ok)
                Console.WriteLine($"Элемент {find} найден");
            else
                Console.WriteLine($"Элемент {find} не найден");
        }
        static Stack CloneStack(Stack other)
        {
            Stack clone = new Stack();
            foreach (Shape item in other)
            {
                Shape item2 = new Shape(item);
                clone.Push(item2);
            }
            return clone;
        }
        static SortedDictionary<Shape, Rectangle> CloneSD(SortedDictionary<Shape, Rectangle> other)
        {
            SortedDictionary<Shape, Rectangle> clone = new SortedDictionary<Shape, Rectangle> ();
            foreach (Shape item in other.Keys)
            {
                Shape key = new Shape(item);
                Rectangle value = new Rectangle(other[item]);
                clone.Add(key, value);
            }
            return clone;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Stack universal");
            Stack stack = new Stack();
            for (int i = 0; i < 10; i++)
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        {
                            Circle c = new Circle();
                            c.RandomInit();
                            stack.Push(c);
                            break;
                        }
                    case 2:
                        {
                            Rectangle r = new Rectangle();
                            r.RandomInit();
                            stack.Push(r);
                            break;
                        }
                    case 3:
                        {
                            Parallelepiped p = new Parallelepiped();
                            p.RandomInit();
                            stack.Push(p);
                            break;
                        }
                }
            }
            PrintStack(stack);
            Console.WriteLine("Добавьте элемент");
            Circle c1 = new Circle();
            c1.Init();
            stack.Push(c1);
            PrintStack(stack);
            Console.WriteLine("Удалите элемент");
            Circle c2 = new Circle();
            c2.Init();
            Stack temp = new Stack();
            while (stack.Count > 0)
            {
                Shape s = stack.Pop() as Shape;
                if (!s.Equals(c2 as Shape))
                    temp.Push(s);
            }
            while (temp.Count > 0)
            {
                Shape s = temp.Pop() as Shape;
                stack.Push(s);
            }
            PrintStack(stack);
            AllSquareAreas(stack);
            ShapesWithRightArea(stack);
            ShapesWithRightRadius(stack);
            Stack stack2 = CloneStack(stack);
            stack2.Push(new Circle());
            PrintStack(stack2);
            Console.WriteLine();
            PrintStack(stack);
            Console.WriteLine("SortedDictionary<K,T>");
            SortedDictionary<Shape, Rectangle> sd = new SortedDictionary<Shape, Rectangle>();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Rectangle value = new Rectangle();
                    value.RandomInit();
                    Shape key = value.GetBase;
                    sd.Add(key, value);
                }
                catch (Exception e)
                {
                    i--;
                }
            }
            PrintSortedDictionary(sd);
            Console.WriteLine("Добавьте элемент");
            Rectangle r1 = new Rectangle();
            r1.Init();
            sd.Add(r1.GetBase, r1);
            PrintSortedDictionary(sd);
            Console.WriteLine("Удалите элемент");
            Rectangle r2 = new Rectangle();
            r2.Init();
            sd.Remove(r2.GetBase);
            PrintSortedDictionary(sd);
            Find(sd, r1);
            Find(sd, r2);
            AllSquareAreas(sd);
            ShapesWithRightArea(sd);
            ShapesWithRightRadius(sd);
            SortedDictionary<Shape, Rectangle> sd2 = CloneSD(sd);
            sd2.Add(r2.GetBase, r2);
            PrintSortedDictionary(sd2);
            Console.WriteLine();
            PrintSortedDictionary(sd);
            SortedSet<Shape> set1 = new SortedSet<Shape>();
            SortedSet<string> set2 = new SortedSet<string>();
            HashSet<Shape> set3 = new HashSet<Shape>();
            HashSet<string> set4 = new HashSet<string>();
            TestCollections testCollections = new TestCollections(1000);
            testCollections.FindFirst();
            testCollections.FindMiddle();
            testCollections.FindLast();
            testCollections.FindNot();
        }
    }
}
