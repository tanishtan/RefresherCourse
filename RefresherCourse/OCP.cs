using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefresherCourse
{
  /*  public interface IShape//instead of differntly writing
    {
        double Area();
    
        //no need to add the functions separetely
    }*/
    public abstract class IShape//instead of differntly writing
    {
        
        public abstract double Area();
    }

    public class Square:IShape
        {
            public int Length { get; set; }
            public Square(int length)
            {
                Length = length;
            }
        public override double Area()
        {
            return Math.Pow(Length, 2);
        }
        }

        public class Circle:IShape
        {
            public double Radius { get; set; }
            public Circle(double radius)
            {
                Radius = radius;
            }
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
    public class AreaCalculator//Extending from same base and 
    {
        public List<object> Shapes { get; set; }
        public AreaCalculator(List<object> shapes)
        {
            Shapes = shapes;
        }   

        public double SumofAreas()
        {
            double sum = 0;
            foreach(var shape in Shapes)
            {
                /*  if(shape is Square s) sum+=s.Area();
                  else if(shape is Circle circle) sum+=circle.Area();
  */
                if (shape is IShape s) sum += s.Area();
            }
            return sum;
        }
    }
    internal class OCP
    {
        internal static void Test()
        {
            List<object> list = new List<object> { new Square(10), new Circle(10), new Circle(5), new Square(4) };
            AreaCalculator calc = new AreaCalculator(list);
            Console.WriteLine(calc.SumofAreas());
        }
    }
}
