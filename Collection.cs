using laba_10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_11
{
    public class TestCollections
    {
        public SortedSet<Shape> set1 = new SortedSet<Shape>();
        SortedSet<string> set2 = new SortedSet<string>();
        HashSet<Shape> set3 = new HashSet<Shape>();
        HashSet<string> set4 = new HashSet<string>();
        Rectangle first, last, middle, absent;
        Stopwatch timer = new Stopwatch();
        public TestCollections(int length)
        {
            while (set1.Count < length) 
            {
                Rectangle r = new Rectangle();
                r.RandomInit();
                if (!set1.Contains(r))
                {
                    set1.Add(r);
                    set2.Add(r.ToString());
                    set3.Add(r);
                    set4.Add(r.ToString());
                    if (set1.Count == 1)
                        first = r.Clone() as Rectangle;
                    if (set1.Count == length / 2)
                        middle = r.Clone() as Rectangle;
                    if (set1.Count == length)
                        last = r.Clone() as Rectangle;
                }
            }
        }
        public void FindFirst()
        {
            Console.WriteLine("ПЕРВЫЙ ЭЛЕМЕНТ");
            Console.WriteLine($"Коллекция 1, длина: {set1.Count}");
            timer.Restart();
            set1.Contains(first);
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 2, длина: {set2.Count}");
            timer.Restart();
            set2.Contains(first.ToString());
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 3, длина: {set3.Count}");
            timer.Restart();
            set3.Contains(first);
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 4, длина: {set4.Count}");
            timer.Restart();
            set4.Contains(first.ToString());
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
        }
        public void FindMiddle()
        {

            Console.WriteLine("СРЕДНИЙ ЭЛЕМЕНТ");
            Console.WriteLine($"Коллекция 1, длина: {set1.Count}");
            timer.Restart();
            set1.Contains(middle);
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 2, длина: {set2.Count}");
            timer.Restart();
            set2.Contains(middle.ToString());
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 3, длина: {set3.Count}");
            timer.Restart();
            set3.Contains(middle);
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 4, длина: {set4.Count}");
            timer.Restart();
            set4.Contains(middle.ToString());
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
        }
        public void FindLast()
        {

            Console.WriteLine("ПОСЛЕДНИЙ ЭЛЕМЕНТ");
            Console.WriteLine($"Коллекция 1, длина: {set1.Count}");
            timer.Restart();
            set1.Contains(last);
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 2, длина: {set2.Count}");
            timer.Restart();
            set2.Contains(last.ToString());
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 3, длина: {set3.Count}");
            timer.Restart();
            set3.Contains(last);
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 4, длина: {set4.Count}");
            timer.Restart();
            set4.Contains(last.ToString());
            timer.Stop();
            Console.WriteLine($"Объект найден, время поиска: {timer.ElapsedTicks} ");
        }
        public void FindNot()
        {
            Rectangle r = new Rectangle();
            Console.WriteLine("НЕСУЩЕСТВУЮЩИЙ ЭЛЕМЕНТ");
            Console.WriteLine($"Коллекция 1, длина: {set1.Count}");
            timer.Restart();
            set1.Contains(r);
            timer.Stop();
            Console.WriteLine($"Объект не найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 2, длина: {set2.Count}");
            timer.Restart();
            set2.Contains(r.ToString());
            timer.Stop();
            Console.WriteLine($"Объект не найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 3, длина: {set3.Count}");
            timer.Restart();
            set3.Contains(r);
            timer.Stop();
            Console.WriteLine($"Объект не найден, время поиска: {timer.ElapsedTicks} ");
            Console.WriteLine($"Коллекция 4, длина: {set4.Count}");
            timer.Restart();
            set4.Contains(r.ToString());
            timer.Stop();
            Console.WriteLine($"Объект не найден, время поиска: {timer.ElapsedTicks} ");
        }
    }
}
