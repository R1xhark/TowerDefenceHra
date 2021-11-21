using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Resources
{
	internal class Vector
	{
		public double X { get; }
		public double Y { get; }

		public double Magnitude => System.Math.Sqrt(X * X + Y * Y);

		public Vector(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double Distance(Vector vector)
		{
			return System.Math.Sqrt(
				(X - vector.X) * (X - vector.X) +
				(Y - vector.Y) * (Y - vector.Y));
		}

		public Vector Normalize()
		{
			var inverse = 1 / Magnitude;
			return new Vector(X * inverse, Y * inverse);
		}

		public double Angle(Vector other)
		{
			return this == other ? 0 : System.Math.Acos(System.Math.Min(1.0f, Normalize().DotProduct(other.Normalize()))) / System.Math.PI * 180;
		}

		public double DotProduct(Vector other)
		{
			return X * other.X + Y * other.Y;
		}

		#region Operators

		public static Vector operator +(Vector v1, Vector v2)
		{
			return new Vector(v1.X + v2.X, v1.Y + v2.Y);
		}

		public static Vector operator -(Vector v1, Vector v2)
		{
			return new Vector(v1.X - v2.X, v1.Y - v2.Y);
		}

		public static Vector operator *(Vector v, double scale)
		{
			return new Vector(v.X * scale, v.Y * scale);
		}

		public static Vector operator *(double scale, Vector v)
		{
			return v * scale;
		}

		public static Vector operator /(Vector v, double scale)
		{
			return new Vector(v.X / scale, v.Y / scale);
		}

		public static Vector operator -(Vector v)
		{
			return new Vector(-v.X, -v.Y);
		}

		public static bool operator ==(Vector v1, Vector v2)
		{
			return Equals(v1, v2);
		}

		public static bool operator !=(Vector v1, Vector v2)
		{
			return !(v1 == v2);
		}

		protected bool Equals(Vector other)
		{
			return X.Equals(other.X) && Y.Equals(other.Y);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Vector)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X.GetHashCode() * 397) ^ Y.GetHashCode();
			}
		}

		#endregion
	}
}