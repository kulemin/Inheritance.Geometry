using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Geometry
{
	public abstract class Body
	{
        public abstract double GetVolume();
        public static double GetCube(double size)
        {
            return size * size * size;
        }

        public static double GetSqr(double size)
        {
            return size * size;
        }

        public abstract void Accept(IVisitor visitor);
    }

	public class Ball : Body
	{
		public double Radius { get; set; }

        public override double GetVolume()
        {
            return 4.0 * Math.PI * GetCube(Radius) / 3;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

	public class Cube : Body
	{
		public double Size { get; set; }

        public override double GetVolume()
        {
            return GetCube(Size);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

	public class Cyllinder : Body
	{
		public double Height { get; set; }
		public double Radius { get; set; }

        public override double GetVolume()
        {
            return Math.PI * GetSqr(Radius) * Height;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IVisitor
    {
        void Visit(Ball ball);
        void Visit(Cube cube);
        void Visit(Cyllinder cyllinder);
    }

	public class SurfaceAreaVisitor : IVisitor
	{
		public double SurfaceArea { get; private set; }

        public void Visit(Ball ball)
        {
            SurfaceArea = 4 * Math.PI * GetSqr(ball.Radius);
        }

        public void Visit(Cube cube)
        {
            SurfaceArea = 6 * GetSqr(cube.Size);
        }

        public void Visit(Cyllinder cyllinder)
        {
            SurfaceArea = 2* Math.PI * cyllinder.Radius * (cyllinder.Radius + cyllinder.Height);
        }

        public static double GetCube(double size)
        {
            return size * size * size;
        }

        public static double GetSqr(double size)
        {
            return size * size;
        }
    }

	public class DimensionsVisitor : IVisitor
	{
		public Dimensions Dimensions { get; private set; }

        public void Visit(Ball ball)
        {
            Dimensions =  new Dimensions(ball.Radius * 2, ball.Radius * 2);
        }

        public void Visit(Cube cube)
        {
            Dimensions = new Dimensions(cube.Size, cube.Size);
        }

        public void Visit(Cyllinder cyllinder)
        {
            Dimensions = new Dimensions(cyllinder.Radius * 2, cyllinder.Height);
        }
    }
}
