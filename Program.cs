/*
 * interface
Opis: Twoim zadaniem jest stworzenie programu, który będzie obsługiwał różne kształty geometryczne. 
Program ma umożliwiać obliczanie pola powierzchni i obwodu dla każdego kształtu.

Wymagania:

Utwórz interfejs IShape zawierający metody CalculateArea i CalculatePerimeter.

Utwórz klasy implementujące interfejs IShape dla przynajmniej dwóch różnych kształtów (np. kwadrat, koło).

Każda klasa powinna posiadać odpowiednie pola i konstruktor(y) oraz implementacje metod CalculateArea i CalculatePerimeter.
*/
using Coding.Exercise;
using CSharpCourseMojeZadania;
using System;
using System;

namespace Coding.Exercise
{
    public interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
    }
    public class Square : IShape
    {
        public Square(double sl)
        {
            SideLength = sl;
        }
        public double SideLength { get; set; }
        public double CalculateArea()
        {
            return SideLength * SideLength;
        }

        public double CalculatePerimeter()
        {
            return 4 * SideLength;
        }
    }
    public class Circle : IShape
    {
        public Circle(double r)
        {
            Radius = r;
        }

        public double Radius { get; set; }
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(3);
        Console.WriteLine(circle.CalculateArea());
        Console.WriteLine(circle.CalculatePerimeter());
        Square square = new Square(4);
        Console.WriteLine(square.CalculateArea());
        Console.WriteLine(square.CalculatePerimeter());
    }
}


